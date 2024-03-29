﻿using System;
using System.IO;

namespace FolderPurge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paste the link to the Folder you would like to clean:");
            string? Link = Console.ReadLine();
            try
            {
                if (Directory.Exists(Link))
                {
                    foreach (string link in Directory.GetFiles(Link))
                    {
                        try
                        {
                            DirectoryInfo dirInfo = new DirectoryInfo(Link);

                            if (dirInfo.LastAccessTime > DateTime.Now.Subtract(TimeSpan.FromMinutes(30)))
                            { dirInfo.Delete(true); }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Directory Doesnt Exist");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unable to access {0}", e.Message);
            }
        }
    }
}





