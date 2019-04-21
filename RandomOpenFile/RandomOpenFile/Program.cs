using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace RandomOpenFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string selfName = Process.GetCurrentProcess().MainModule.FileName;
            DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = currentDirectory.GetFiles();
            List<string> fileNames = new List<string>();
            foreach (var tmp in files)
            {
                fileNames.Add(tmp.FullName);
            }
            fileNames.Remove(selfName);
            int randomNumber = new Random().Next(0, fileNames.Count);
            if (randomNumber == 0)
            {
                System.Environment.Exit(1);
            }
            try
            {
                Process.Start(fileNames[randomNumber]);
            }
            catch
            {
                System.Environment.Exit(1);
            }
            finally
            {
                System.Environment.Exit(0);
            }
        }
    }
}
