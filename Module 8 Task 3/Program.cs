using System;
using System.IO;

namespace FolderReport
{
    class Program
    {
              
        static void Main(string[] args)
        {
            
            Console.WriteLine("Paste the link to the Folder you would like to clean:");
            string? Link = Console.ReadLine();
            float initialSize = Sizer(Link);  //Assigns size of folder before cleanup
            
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
            float newSize = Sizer(Link);

            Console.WriteLine("Initial Folder size:{0}", initialSize);
            Console.WriteLine("Size of cleaned up files:{0}", initialSize);//I figured it should always be equal to initia size:)
            Console.WriteLine("Current folder size:{0}", newSize);
            Console.ReadKey();
        }
        static float Sizer(string Link)
        {
             
            float folderSize = 0.0f;
            try
            {
                if (!Directory.Exists(Link))
                { return folderSize; }
                else
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(Link))
                        {
                            if (File.Exists(file))
                            {
                                FileInfo finfo = new FileInfo(file);
                                folderSize += finfo.Length;
                            }
                        }

                        foreach (string dir in Directory.GetDirectories(Link))
                            folderSize += Sizer(dir);
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
            }
            return folderSize;
        }
    }
}






