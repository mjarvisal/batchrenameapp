using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BatchRenameApp
{
    class ProcessStrings
    {
        public volatile string output;

        private static Regex r = new Regex(":");
        private string filense = string.Empty;
        private string fileext = string.Empty;
        private LocationServices savedLocations = new LocationServices();
        private static string lastvalidFunction = "x";

        internal string[] exifEnumTypes = Enum.GetNames(typeof(ExifLib.ExifTags));

        //retrieves the datetime WITHOUT loading the whole image
        private static DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                try
                {
                    using (Image myImage = Image.FromStream(fs, false, false))
                    {
                        PropertyItem propItem = myImage.GetPropertyItem(36867);
                        string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                        return DateTime.Parse(dateTaken);
                    }
                }
                catch (Exception)
                {
                    return DateTime.MaxValue;
                }
        }

        private Double[] GetGPSLocationFromImage(string path)
        {
            Double[] output = new Double[2] { -360.0d, -360.0d };
            double[] lat = null;
            double[] lon = null;
            if (Exifcache.IsGPSsaved(path))
            {
                return Exifcache.GetSavedGPS(path);
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        ExifLib.ExifReader exifReader = new ExifLib.ExifReader(fs);
                        exifReader.GetTagValue<double[]>(ExifLib.ExifTags.GPSLatitude, out lat);
                        exifReader.GetTagValue<double[]>(ExifLib.ExifTags.GPSLongitude, out lon);
                    }
                    catch
                    {

                    }
                }
                if (!(lat == null) || !(lon == null))
                {
                    output[0] = lat[0] + lat[1] / 60 + lat[2] / 3600;
                    output[1] = lon[0] + lon[1] / 60 + lon[2] / 3600;
                }
                Exifcache.SaveGPS(output, path);
                return output;
            }
        }

        private string EvaluateFunctionString(string sFunction, int number)
        {
            string expression = "x";
            string lastvalidexpression = "x";
            Regex allowedRegex = new Regex(@"[^x0-9()*/+-\^]");
            string numberformat = Properties.Settings.Default.NumberFormat.ToLower();

            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl { Language = "VBScript" };
            if (sFunction.Length > 0)
            {
                if (allowedRegex.IsMatch(sFunction))
                {
                    lastvalidexpression = lastvalidFunction.Replace("x", number.ToString());
                }
                else
                {
                    expression = sFunction.Replace("x", number.ToString());
                    lastvalidexpression = lastvalidFunction.Replace("x", number.ToString());
                }
            }
            else
            {
                sFunction = "x";
                expression = sFunction.Replace("x", number.ToString());
            }

            object result = null;

            try
            {
                if (allowedRegex.IsMatch(sFunction))
                {
                    result = sc.Eval(lastvalidexpression);

                }
                else
                {
                    result = sc.Eval(expression);
                    lastvalidFunction = sFunction;
                }
            }
            catch (Exception)
            {
                result = sc.Eval(lastvalidexpression);
            }
            if (result != null)
            {
                double doubleresult = Convert.ToDouble(result);
                // @TODO
                // Evaluate that the string format is valid
                if (numberformat.Contains("d") || numberformat.Contains("x"))
                {
                    int numberresult = Convert.ToInt32(doubleresult);
                    return numberresult.ToString(numberformat);
                }
                else
                    return doubleresult.ToString(numberformat);
            }
            else
                return "0";
        }

        public void ProcessPatterns(int number, string replacetext, string function, FileInfo file)
        {
            output = replacetext;
            string dateformat = Properties.Settings.Default.DateFormat;
            string timeformat = Properties.Settings.Default.TimeFormat;
            string date = file.CreationTime.ToString(dateformat);
            string time = file.CreationTime.ToString(timeformat);
            String[] imagedatetime = { "%datetaken", "%timetaken" };
            String[] fileparts = { "%file%", "%ext%" };
            if (fileparts.Any(output.Contains))
            {
                Regex extension = new Regex("[.](.){3,4}$");
                try
                {
                    Match fileextregex = extension.Match(file.Name);
                    int index = fileextregex.Index;
                    int lenght = fileextregex.Length;
                    filense = file.Name.Remove(index, lenght);
                    fileext = fileextregex.Value;
                }
                catch
                {
                    output = null;
                }
                output = output.Replace("%ext%", fileext);
                output = output.Replace("%file%", filense);
            }
            List<string> foundTags = new List<string>();

            foreach (string enumType in exifEnumTypes)
            {

                if (output.Contains("%" + enumType + "%"))
                {
                    foundTags.Add(enumType);
                }
            }

            using (FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    ExifLib.ExifReader exifReader = new ExifLib.ExifReader(fs);

                    foreach (string enumType in foundTags)
                    {
                        try
                        {
                            Enum.TryParse(enumType, out ExifLib.ExifTags tag);
                            exifReader.GetTagValue(tag, out object result);
                            switch (enumType)
                            {
                                case "DateTimeOriginal":
                                    DateTime origDate = DateTime.Parse(result.ToString());
                                    output = output.Replace("%" + enumType + "%", "" + origDate.ToString(dateformat + " " + timeformat));
                                    break;
                                default:
                                    output = output.Replace("%" + enumType + "%", "" + result.ToString());
                                    break;
                            }

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                            output =  null;
                        }
                    }
                }
                catch { }
            }

            try
            {
                output = output.Replace("%folder%", file.Directory.Name);
                output = output.Replace("%datecreated%", date);
                output = output.Replace("%timecreated%", time);
                output = output.Replace("%datenow%", DateTime.Now.ToString(dateformat));
                output = output.Replace("%timenow%", DateTime.Now.ToString(timeformat));
                output = output.Replace("%fnc%", EvaluateFunctionString(function, number));

                if (output.Contains("%loc%"))
                {
                    double[] location = GetGPSLocationFromImage(file.FullName);

                    if (location[0] > -360.0 && location[1] > -360.0)
                    {
                        string[] LocationNames = new string[] { "", "" };
                        int savedLocationindex = savedLocations.GetSavedLocationIndex(location);
                        if (savedLocationindex == int.MaxValue)
                        {
                            savedLocations.SearchforLocation(location, 14);
                            savedLocationindex = savedLocations.GetSavedLocationIndex(location);
                            if (savedLocationindex == int.MaxValue)
                            {
                                savedLocations.SearchforLocation(location, 10);
                                savedLocationindex = savedLocations.GetSavedLocationIndex(location);
                            }
                            LocationNames = savedLocations.GetLocationNames(savedLocationindex);
                        }
                        else
                        {
                            LocationNames = savedLocations.GetLocationNames(savedLocationindex);
                        }
                        string geoLocationCountry = LocationNames[0];
                        string geoLocationCity = LocationNames[1];
                        string geoLocation = string.Format("{0},{1}", geoLocationCity, geoLocationCountry);
                        output = output.Replace("%loc%", geoLocation);
                    }
                    else
                    {
                        output = output.Replace("%loc%", "");
                    }
                }

                if (imagedatetime.Any(replacetext.Contains))
                {
                    DateTime dateTime = GetDateTakenFromImage(file.FullName);
                    if (dateTime == DateTime.MaxValue)
                    {
                        output = output.Replace("%datetaken%", "%datetaken%");
                        output = output.Replace("%timetaken%", "%timetaken%");
                    }
                    else
                    {
                        output = output.Replace("%datetaken%", dateTime.ToString(dateformat));
                        output = output.Replace("%timetaken%", dateTime.ToString(timeformat));
                    }

                }
                else
                {
                    output = output.Replace("%datetaken%", "%datetaken%");
                    output = output.Replace("%timetaken%", "%timetaken%");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                output =  null;
            }
        }
    }

}
