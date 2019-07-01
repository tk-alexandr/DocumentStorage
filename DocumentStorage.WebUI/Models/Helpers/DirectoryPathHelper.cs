using System;

namespace DocumentStorage.WebUI.Models.Helpers
{
    public class DirectoryPathHelper
    {
        public static string GetRelativePath(string fileFullName, Func<string, string> mapPath){

            string fileExtention = fileFullName.Substring(fileFullName.LastIndexOf('.'));
            string fileName = fileFullName.Substring(0, fileFullName.LastIndexOf('.'));
            string directoryPath = @"~/App_Data/Files/";
            string relativePath;


            if (System.IO.File.Exists(mapPath(directoryPath + fileFullName)))
            {
                int i = 1;
                while (System.IO.File.Exists(mapPath(directoryPath + fileName + "(" + i + ")" + fileExtention)))
                    i++;

                relativePath = directoryPath + fileName + "(" + i + ")" + fileExtention;
            }
            else
            {
                relativePath = directoryPath + fileFullName;

            }

            return relativePath;
        }
    }
}