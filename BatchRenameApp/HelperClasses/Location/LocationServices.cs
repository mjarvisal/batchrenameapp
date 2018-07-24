﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml;
using System.IO.Compression;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BatchRenameApp
{
    public struct LocationStorage
    {
        public double TopLat;
        public double TopLon;
        public double BottomLat;
        public double BottomLon;
        public string[] Names;
    }

    class LocationServices
    {
        ArrayList SavedLocations = new ArrayList();

        public void SearchforLocation(double[] Coordinates, int zoom)
        {
            string geoLocationCity = "";
            string geoLocationboundingbox = "";
            string geoLocationCountry = "";
            do
            {
                NumberFormatInfo nfi = new NumberFormatInfo
                {
                    NumberDecimalSeparator = "."
                };
                String url = String.Format("http://nominatim.openstreetmap.org/reverse?format=xml&lat={0}&lon={1}&zoom={2}&addressdetails=1", Coordinates[0].ToString(nfi), Coordinates[1].ToString(nfi), zoom.ToString());

                Uri address = new Uri(url);

                WebClient client = new WebClient();
                client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:61.0) Gecko/20100101 Firefox/61.0";
                client.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                client.Headers["Accept-Language"] = "en-us,en;q=0.5";
                client.Headers["Accept-Encoding"] = "gzip, deflate, br";
                client.Headers["Accept-Charset"] = "ISO-8859-1,utf-8;q=0.7,*;q=0.7";
                XmlReader xmlreader;

                byte[] response = client.DownloadData(address);

                MemoryStream responseStream = new MemoryStream(response);

                try
                {
                    xmlreader = XmlReader.Create(responseStream);
                    while (xmlreader.Read())
                    {
                        switch (xmlreader.Name.ToString().ToLower())
                        {
                            case "result":
                                string Attribute = xmlreader.GetAttribute("boundingbox");
                                if (Attribute != null)
                                {
                                    geoLocationboundingbox = Attribute;
                                }
                                break;
                            case "country":
                                geoLocationCountry = xmlreader.ReadElementContentAsString();
                                break;
                            case "city":
                                geoLocationCity = xmlreader.ReadElementContentAsString();
                                break;
                            case "town":
                                geoLocationCity = xmlreader.ReadElementContentAsString();
                                break;
                        }
                    }
                    zoom--;
                }
                catch (Exception)
                {

                }

            } while (geoLocationCity == "");
            SaveLocation(geoLocationboundingbox, geoLocationCountry, geoLocationCity);
        }

        public void SaveLocation(string boundingbox, string country, string city)
        {
            string[] names = { country, city };
            LocationStorage SavedLocation = new LocationStorage();
            string[] Coordinates = boundingbox.Split(',');

            SavedLocation.TopLat = Convert.ToDouble(Coordinates[1]);
            SavedLocation.TopLon = Convert.ToDouble(Coordinates[2]);
            SavedLocation.BottomLat = Convert.ToDouble(Coordinates[0]);
            SavedLocation.BottomLon = Convert.ToDouble(Coordinates[3]);
            SavedLocation.Names = names;
            SavedLocations.Add(SavedLocation);
        }

        public int GetSavedLocationIndex(double[] Coordinates)
        {
            double lat = Coordinates[0];
            double lon = Coordinates[1];
            foreach (LocationStorage SavedLocation in SavedLocations)
            {
                if (SavedLocation.TopLon <= lon && SavedLocation.BottomLon >= lon
                  && SavedLocation.TopLat >= lat && SavedLocation.BottomLat <= lat)
                {
                    return SavedLocations.IndexOf(SavedLocation);
                }

            }
            return int.MaxValue;
        }

        public string[] GetLocationNames(int index)
        {
            LocationStorage SavedLocation = (LocationStorage)SavedLocations[index];
            return SavedLocation.Names;
        }

    }
}
