using System;
using System.Collections.Generic;
using System.IO;

namespace RainbowSchool
{
    class StoringAndUpdatingTeacherRecords
    {
        static void Main(string[] args)
        {
            string teacher_id;
            string teacher_name;
            string class_number;
            string section_name;
            string path = "D:\\Training\\Files\\teachers_details.txt";
            string[] teacher;

            StreamWriter SW = null;
            //StreamReader SR = null;


            void insert_record()
            {

                jump1:string[] lines = File.ReadAllLines(path);
                Console.WriteLine("enter the teacher id\t");
                teacher_id = Console.ReadLine();
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Split(",")[0] == teacher_id)
                    {
                        Console.WriteLine("This id already exists , please enter new ID");
                        goto jump1;
                    }
                }
                // getting the input from user to insert 
                Console.WriteLine("enter the teacher name\t");
                teacher_name = Console.ReadLine();
                Console.WriteLine("enter the class\t");
                class_number = Console.ReadLine();
                Console.WriteLine("enter the section\t");
                section_name = Console.ReadLine();
                // inserting into the file 
                using (FileStream filestream_w = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    SW = new StreamWriter(filestream_w);
                    //SW.Write("\n" +teacher_id + "," + teacher_name + "," + class_number + "," + section_name);
                    SW.WriteLine(teacher_id + "," + teacher_name + "," + class_number + "," + section_name);
                    SW.Flush(); 
                }
            }


            //updating the file 
            void update_record(string update_id)
            {
                int found_id = 0;
                string[] lines = File.ReadAllLines(path);
                teacher = new string[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    teacher[i] = lines[i];
                }
                //Console.WriteLine("teachers list before updating");
                //for (int i = 0; i < teacher.Length; i++)
                //{
                        
                //    Console.WriteLine(teacher[i]); 
                //}
                for (int i = 0; i < lines.Length; i++)
                {
                    if(lines[i].Split(",")[0]== update_id)
                    {
                        found_id++;
                        Console.WriteLine("enter the teacher name\t");
                        teacher_name = Console.ReadLine();
                        Console.WriteLine("enter the class\t");
                        class_number = Console.ReadLine();
                        Console.WriteLine("enter the section\t");
                        section_name = Console.ReadLine();
                        lines[i] = update_id + "," + teacher_name + "," + class_number + "," + section_name;
                        teacher[i] = lines[i];
                        Console.WriteLine("updated content");
                        Console.WriteLine(lines[i]);
                        //Console.WriteLine(teacher[i]);
                        break;
                    }
                }
                if (found_id == 0)
                {
                    Console.WriteLine("this id does not exist , please enter correct id\t");
                    update_id = Console.ReadLine();
                    update_record(update_id);
                }
                using (FileStream filestream_w = new FileStream(path, FileMode.Open, FileAccess.Write))
                {
                    SW = new StreamWriter(filestream_w);
                    //Console.WriteLine("teachers list after updating");
                    //for (int i = 0; i < teacher.Length; i++)
                    //{ 
                    //    Console.WriteLine(teacher[i]);
                    //}
                    for (int i = 0; i < teacher.Length; i++)
                    {
                        SW.WriteLine(teacher[i]);
                        SW.Flush();
                    } 
                }
            }

            void display_all()
            {
                string[] lines = File.ReadAllLines(path);
                Console.WriteLine("displaying all records");
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }

            }

            void display_by_id()
            {
                string display_id;
                jump3: Console.WriteLine("enter the id you want to display");
                display_id = Console.ReadLine();
                int found_dispid = 0;
                string[] lines = File.ReadAllLines(path);
                //Console.WriteLine("displaying all records");
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Split(",")[0]== display_id)
                    {
                        found_dispid++;
                        Console.WriteLine(lines[i]);
                    }
                        
                }
                if (found_dispid == 0)
                {
                    Console.WriteLine("entered incorrect id ,Please enter correct id");
                    goto jump3;
                }
            }
            Console.WriteLine("welcome to rainbow school.");
      jump2:Console.WriteLine("enter your choice to execute\n1.insert new teacher record\n2.update an existing teacher record\n3.display all the teachers list\n4.display the list by id\n5.exit\n");


            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    insert_record();
                    break;
                case 2:
                    Console.WriteLine("enter the id of the teacher u want to update\t");
                    string update_id = Console.ReadLine();
                    update_record(update_id);
                    break;
                case 3:
                    display_all();
                    break;
                case 4:
                    display_by_id();
                    break;
                case 5:
                    Console.WriteLine("Thank you");
                    break;
                default:
                    Console.WriteLine("please enter the correct option");
                    break;
            }
            if(option!=5)
            {
                Console.WriteLine("Do you wish to continue?(y/n)");
                string response = Console.ReadLine();
                if (response.ToUpper() == "Y")
                    goto jump2;
            }
            Console.ReadKey();
        }
    }
}
