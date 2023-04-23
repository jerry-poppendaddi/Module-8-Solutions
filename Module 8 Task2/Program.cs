using System;
using System.IO;
namespace DirectorySizer
{
    class Program
    {
        static float Sizer(string folder)
        {
            Console.WriteLine("Paste the link to the Directory the size of which you would like to be displayed:");
            string? Link = Console.ReadLine();
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

