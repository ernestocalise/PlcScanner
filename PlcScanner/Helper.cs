using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PlcScanner
{
    public static class Helper
    {
        private static string GetBasePath()
        {
            string FolderPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments), "PlcScanner");
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            return FolderPath;
        }
        private static string GetProjectFolder(string projectName)
        {
            var FolderPath = Path.Combine(GetBasePath(), projectName);
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            return FolderPath;
        }
        private static string GetClientFolder(string projectName)
        {
            var FolderPath = Path.Combine(GetProjectFolder(projectName), "Client");
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            return FolderPath;
        }
        private static string GetServerFolder(string projectName)
        {
            var FolderPath = Path.Combine(GetProjectFolder(projectName), "Server");
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            return FolderPath;
        }
        private static string GetServerCertificateFolder(string projectName)
        {
            var FolderPath = Path.Combine(GetServerFolder(projectName), "Certificates");
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            return FolderPath;
        }
        public static string GetServerCertificateSubfolder(string projectName, string folderName)
        {
            var FolderPath = Path.Combine(GetServerCertificateFolder(projectName), folderName);
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            FolderPath = Path.Combine(FolderPath, "certs");
            if(!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            return FolderPath;
        }
        public static string RenameProjectPath(string oldProjectName, string newProjectName)
        {
            var OldFolderPath = GetProjectFolder(oldProjectName);
            Directory.Move(GetProjectFolder(oldProjectName), Path.Combine(GetBasePath(), newProjectName));
            return Path.Combine(GetBasePath(), newProjectName);
        }
        private static string GetRoutinesPath(string projectName)
        {
            var FolderPath = Path.Combine(GetProjectFolder(projectName), "Routines");
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            return FolderPath;
        }
        public static string GetPath(PathType PathType, string ProjectName = "")
        {
            switch (PathType)
            {
                case PathType.Base:
                    return GetBasePath();
                case PathType.ProjectFolder:
                    return GetProjectFolder(ProjectName);
                case PathType.MAIN:
                    return GetProjectFolder("MAIN");
                case PathType.Client:
                    return GetClientFolder(ProjectName);
                case PathType.Server:
                    return GetServerFolder(ProjectName);
                case PathType.ServerCertificates:
                    return GetServerCertificateFolder(ProjectName);
                case PathType.Routines:
                    return GetRoutinesPath(ProjectName);
                default:
                    return GetBasePath();
            }
        }
        public static string GetLogPath(string path)
        {
            var FolderPath = Path.Combine(path, "Log");
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            return FolderPath;
        }
        public static bool CopyFolder(string sourcePath, string targetPath)
        {
            try
            {

                if (!Directory.Exists(sourcePath))
                {
                    throw new Exception($"Source folder [{sourcePath}] does not exists!");
                }
                if (!Directory.Exists(targetPath))
                    Directory.CreateDirectory(targetPath);
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                }

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to copy folder! Error [{ex.Message}]");
            }
        }
        public static void CopyFile(string sourceFile, string targetPath, bool overwrite)
        {
            if (File.Exists(sourceFile))
            {
                string fileName = Path.GetFileNameWithoutExtension(sourceFile);
                string ext = Path.GetExtension(sourceFile);
                string fullFileName = $"{fileName}{ext}";
                int retry = 1;
                if (!overwrite)
                {
                    while(File.Exists(Path.Combine(targetPath, fullFileName)))
                    {
                        fullFileName = $"{fileName}_{retry}{ext}";
                    }
                }
                File.Copy(sourceFile, Path.Combine(targetPath, fullFileName));
            }
        }
        public static string ToUpperCamelCase(string input)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

            string output = ti.ToTitleCase(input.Trim());
            output = output.Replace(" ", "");
            return output;
        }
    }
    public enum PathType
    {
        Base = 0,
        ProjectFolder = 1,
        MAIN = 2,
        Client = 3,
        Server = 4,
        ServerCertificates = 5,
        Routines = 6,
    }
}
