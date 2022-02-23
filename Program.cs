using System;
using System.IO;

namespace PhotoOrganizer
{
    internal class Program
    {
        public static string[] duplicateFiles = { };
        public static string DestinationPath { get; set; }
        public static int FilesCounter { get; set; }
        public static string SourcePath { get; set; }

        public static void Main(string[] args)
        {
            Console.WriteLine("Type the source folder path:");
            SourcePath = Console.ReadLine(); DestinationPath = Path.Combine(SourcePath, "PhotoOrganizer");

            StartProcess();
            ShowDuplicateFiles();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        private static void CopyFile(string file, string path)
        {
            try
            {
                string newPath = Path.Combine(DestinationPath, path, Path.GetFileName(file));

                File.Copy(file, newPath, false);
                FilesCounter++;
                Console.WriteLine("{0}: {1}", FilesCounter, file);
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("already exists"))
                {
                    Array.Resize(ref duplicateFiles, duplicateFiles.Length + 1);
                    duplicateFiles[duplicateFiles.GetUpperBound(0)] = file;
                }
                else
                {
                    Console.WriteLine(e.Message);
                }
            }
            finally { }
        }

        private static void CreateDirectory(string path)
        {
            try
            {
                string newPath = Path.Combine(DestinationPath, path);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { }
        }

        private static void ProcessDirectory(string directory)
        {
            if (!directory.Contains("PhotoOrganizer"))
            {
                string[] fileList = Directory.GetFiles(directory);
                foreach (string file in fileList)
                {
                    ProcessFile(file);
                }

                string[] folderList = Directory.GetDirectories(directory);
                foreach (string folder in folderList)
                {
                    ProcessDirectory(folder);
                }
            }
        }

        private static void ProcessFile(string file)
        {
            FileAttributes attributes = File.GetAttributes(file);
            if ((attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
            {
                DateTime fileDate = File.GetLastWriteTime(file) <= File.GetCreationTime(file) ? File.GetLastWriteTime(file) : File.GetCreationTime(file);

                string fullYear = fileDate.Year.ToString();
                string year = fileDate.Year.ToString().Substring(2, 2);
                string month = fileDate.Month.ToString();
                string day = fileDate.Day.ToString();

                string newPath = Path.Combine(fullYear, year + '.' + month, year + '.' + month + '.' + day);

                CreateDirectory(newPath);
                CopyFile(file, newPath);
            }
        }

        private static void ProcessPath(string[] path)
        {
            foreach (string file in path)
            {
                if (File.Exists(file))
                {
                    ProcessFile(file);
                }
                else
                {
                    if (Directory.Exists(file))
                    {
                        ProcessDirectory(file);
                    }
                    else
                    {
                        Console.WriteLine("Invalid path: {0}", file);
                    }
                }
            }
        }

        private static void ShowDuplicateFiles()
        {
            foreach (string file in duplicateFiles)
            {
                Console.WriteLine("File already exists: {0}", file);
            }
        }

        private static void StartProcess()
        {
            try
            {
                string[] pathList = { };

                pathList = Directory.GetFiles(SourcePath);
                ProcessPath(pathList);

                pathList = Directory.GetDirectories(SourcePath);
                ProcessPath(pathList);

                Console.WriteLine("Files successfully copied: {0} to {1}", FilesCounter, DestinationPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { }
        }
    }
}