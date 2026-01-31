using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchbox
{
    internal static class CoverHelper
    {
        public static string BaseDir =>
            AppDomain.CurrentDomain.BaseDirectory;

        public static string AssetsFolder =>
            Path.Combine(BaseDir, "Assets");

        public static string CoversFolder =>
            Path.Combine(AssetsFolder, "Covers");

        public static string DefaultCoverPath =>
            Path.Combine(CoversFolder, "default_cover.jpg");

        public static string GetCover(string coverPath)
        {
            if (string.IsNullOrWhiteSpace(coverPath))
                return DefaultCoverPath;

            if (Path.IsPathRooted(coverPath) && File.Exists(coverPath))
                return coverPath;

            string candidate1 = Path.Combine(CoversFolder, coverPath);
            if (File.Exists(candidate1))
                return candidate1;

            string candidate2 = Path.Combine(AssetsFolder, coverPath);
            if (File.Exists(candidate2))
                return candidate2;

            return DefaultCoverPath;
        }
    }
}
