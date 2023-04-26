using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
   
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Group { get; set; }

        //Constructor
        public Student(string name, DateTime dateOfBirth, string group)
        {
            Name = Name;
            Group = Group;
            DateOfBirth = dateOfBirth;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide a path to your Desktop:");
            string? filePath = Console.ReadLine();
            Console.WriteLine("Provide a path to your .dat file:");
            string? datfilePath = Console.ReadLine();
            
            //Creating a new folder on desktop named "Students"
            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            dirInfo.CreateSubdirectory("Students");

            BinaryFormatter formatter = new BinaryFormatter();
            //DeSerializing .dat file
            using (var fs = new FileStream(datfilePath, FileMode.OpenOrCreate))
            {
                Student[] students = (Student[])formatter.Deserialize(fs);
                for (int i = 0; i < students.Length; i++)
                {
                    string a = filePath + "/" + students[i].Group + ".txt";
                    using (FileStream filestream = new FileStream(a, FileMode.Append))
                    {
                        using (StreamWriter sw = new StreamWriter(filestream))
                        {
                            sw.WriteLine($"{students[i].Name}, {students[i].DateOfBirth}");
                        }
                    }
                }
            }

        }
    }
}


      



       

           
            
            
            
            
            
            


            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
         
   