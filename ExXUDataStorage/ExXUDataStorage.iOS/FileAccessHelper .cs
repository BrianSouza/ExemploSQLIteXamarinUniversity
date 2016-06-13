
using System.Collections.Generic;
using System.Text;

namespace ExXUDataStorage.iOS
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string docfolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libfolder = System.IO.Path.Combine(docfolder, "..", "Library");

            if(!System.IO.Directory.Exists(libfolder))
            {
                System.IO.Directory.CreateDirectory(libfolder);

            }

            return System.IO.Path.Combine(libfolder);
        }
    }
}
