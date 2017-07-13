using System;
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
            Random rnd = new Random();
            
            string localFile = FileGestor.getLocalFolder() + newFile ;
            localFile = localFile.Replace(' ', '_');
            bool isCopied = false;
            do
            {
                try
                {
                    File.Copy(oldFile, localFile + Path.GetExtension(oldFile));
                    isCopied = true;
                }
                catch (Exception e)
                {
                    localFile = localFile + "" + rnd.Next() % 10;
                }
            } while (!isCopied);
            return localFile + Path.GetExtension(oldFile);
        }
    }

}