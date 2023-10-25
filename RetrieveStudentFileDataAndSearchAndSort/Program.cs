using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveStudentFileDataAndSearchAndSort
{
    internal class Program
    {
     static  List<Student> list = new List<Student>();
        public static void  reaFileData()
        {
          string dir= Directory.GetCurrentDirectory();
            string filneName =Path.Combine(dir,"..","student.txt");
            Console.WriteLine(filneName);
            if (File.Exists(filneName))
            {
                string[] lines= File.ReadAllLines(filneName);
                foreach(string line in lines)
                {
                    string[] word = line.Split(',');
                    Student student = new Student();
                    student.StudentID = int.Parse(word[0]);
                    student.Name = word[1];
                   student.Grade = int.Parse(word[2]);
                    list.Add(student);
                }

            }
            else
            {
                Console.WriteLine("File not exist...");
            }
        }
        public static void BubbleSort()
        {
           for(int i = 0; i < list.Count; i++) { 
            for(int j = 0; j < list.Count-i-1; j++)
                {
                    if (string.Compare(list[j].Name, list[j+1].Name) > 0)
                    {
                        // Swap students[j] and students[j+1]
                        Student temp = list[j];
                        list[j] = list [j + 1];
                        list[j + 1] = temp;
                    }
                
                }
            }
        }

        public static void printStudent()
        {
            foreach(Student student in list)
            {

        Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}, Grade: {student.Grade}");
            }
        }
        public static void searchStudentByName()
        {
            Console.WriteLine("Enter student Name :");
            string name=Console.ReadLine();
            Console.WriteLine($"You entered: {name}");
            Student student=list.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase) );
            if (student != null)
            {
                Console.WriteLine($"Student found - ID: {student.StudentID}, Name: {student.Name}, Grade: {student.Grade}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Student data  Without Sorting :");
            reaFileData();
              printStudent();
            Console.WriteLine();

            option();

         
        }
        public static void option()
        {
            while (true)
            {
                Console.WriteLine("Enter 1 to sort the student . ");
                Console.WriteLine("Enter 2 to search the student .");
                Console.WriteLine("Enter 3 to Exit .");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        BubbleSort();
                        printStudent();
                        break;
                    case 2:
                        searchStudentByName();
                        break;
                    case 3:
                        break;
                }
            }
        }
    }
}
