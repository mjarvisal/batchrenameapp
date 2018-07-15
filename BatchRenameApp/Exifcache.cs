using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BatchRenameApp
{
    public class Exifcache
    {
        internal static Dictionary<string, double[]> SavedExifData = new Dictionary<string, double[]>();

        internal static void SaveGPS(double[] Coordinates, string path)
        {
            try
            {
                SavedExifData.Add(path, Coordinates);
            }
            catch (ArgumentException)
            {
                Debug.Print("exifcache, Key already exists");
            }
        }

        internal static double[] GetSavedGPS(string path)
        {
            if (SavedExifData.TryGetValue(path, out double[] output))
            {
                return output;
            }
            else
            {
                return new double[] { -360.0, -360.0 };
            }

        }

        internal static bool IsGPSsaved(string path)
        {
            return SavedExifData.ContainsKey(path);
        }
    }
}
