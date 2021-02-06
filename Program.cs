using System;
using System.IO;

namespace photo_organizer
{
    class Program
    {
        public const string originPath = @"C:\Pictures\Backup";
        public const string destinationPath = @"C:\Pictures\Photos Organizer";
        public static int filesCounter = 0;
        
        public static void Main(string[] args)
        {
            StartProcess();
        }

        private static void StartProcess()
        {
            string[] pathList = Directory.GetFiles(originPath);
            ProcessPath(pathList);

            pathList = Directory.GetDirectories(originPath);
            ProcessPath(pathList);

            Console.WriteLine("Files copied: {0}", filesCounter.ToString());
        }

        private static void ProcessPath(string[] path)
        {
            foreach (string file in path)
            {
                if (File.Exists(file))
                {
                    ProcessFile(file);
                }
                else if (Directory.Exists(file))
                {
                    ProcessDirectory(file);
                }
                else
                {
                    Console.WriteLine("Invalid file or directory: {0}", file);
                }
            }
        }

        private static void ProcessDirectory(string directory)
        {
            string[] fileList = Directory.GetFiles(directory);
            foreach (string file in fileList)
                ProcessFile(file);

            string[] folderList = Directory.GetDirectories(directory);
            foreach (string folder in folderList)
                ProcessDirectory(folder);
        }

        private static void ProcessFile(string file)
        {
            DateTime dateFileCreated = File.GetLastWriteTime(file) <= File.GetCreationTime(file) ? File.GetLastWriteTime(file) : File.GetCreationTime(file);

            string fullYear = dateFileCreated.Year.ToString();
            string year = dateFileCreated.Year.ToString().Substring(2, 2);
            string month = dateFileCreated.Month.ToString();
            string day = dateFileCreated.Day.ToString();

            string newPath = Path.Combine(fullYear, year + '.' + month, year + '.' + month + '.' + day);

            CreateDirectory(newPath);

            CopyFile(file, newPath);
        }

        private static void CreateDirectory(string path)
        {
            string newPath = Path.Combine(destinationPath, path);

            try
            {
                if (Directory.Exists(newPath))
                    return;

                Directory.CreateDirectory(newPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Create directory failed: {0}", e.ToString());
            }
            finally { }
        }
        
        private static void CopyFile(string file, string newPath)
        {
            try
            {
                File.Copy(file, Path.Combine(destinationPath, newPath, Path.GetFileName(file)), false);
                filesCounter++;
                Console.WriteLine("{0}: {1}", filesCounter, file);
            }
            catch (Exception e)
            {
                Console.WriteLine("Copy file failed: {0}", e.ToString());
            }
            finally { }
        }        
    }
}
