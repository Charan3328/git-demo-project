using System;
using System.IO;

namespace Retrieve_Student_Data_from_a_Text_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Training\SimplilearnAssignment\student_list.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.ReadKey();
        }
    }
}
