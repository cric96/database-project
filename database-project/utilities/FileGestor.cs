using System;
using DevExpress.Xpo;
using System.IO;

namespace database_project.utilities
{

    public static class FileGestor
    {
        private static string DIRECTORY_PATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.Ricettario\\";
        public static String getLocalFolder()
        {
            if(!Directory.Exists(DIRECTORY_PATH))
            {
                Directory.CreateDirectory(DIRECTORY_PATH);
            }
            return DIRECTORY_PATH;
        }

        public static String copyFileToLocalFolder(string oldFile, string newFile)
        {
            string localFile = FileGestor.getLocalFolder() + newFile + Path.GetExtension(oldFile);
            localFile = localFile.Replace(' ', '_');
            File.Copy(oldFile, localFile);
            return localFile;
        }
    }

}