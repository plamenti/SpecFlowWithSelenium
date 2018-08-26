using System.Configuration;
using System.IO;

namespace SeleniumTaskAmazon.Helpers
{
    public class IOManager
    {
        private const string ImagesFolderPartialName = "Images";
        private const string ReportsFolderPartialNameKey = "reports";

        public static string CreateReportsDirectory()
        {
            string folderName = GetReportsFolderName();
            try
            {
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
            }
            catch (IOException ex)
            {

            }

            return folderName;
        }

        public static string CreateImagesDirectory()
        {
            string folderName = GetImagesFolderName();

            try
            {
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
            }
            catch (IOException ex)
            {

            }

            return folderName;

        }

        private static string GetReportsFolderName()
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string reportsFolderName = ConfigurationManager.AppSettings.Get(ReportsFolderPartialNameKey);
            string folderName = Path.Combine(projectPath, reportsFolderName);
            return folderName;
        }

        private static string GetImagesFolderName()
        {
            string reportsFolder = GetReportsFolderName();
            string folderName = Path.Combine(reportsFolder, ImagesFolderPartialName);

            return folderName;
        }
    }
}
