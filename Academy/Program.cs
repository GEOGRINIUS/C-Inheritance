//#define INHERITANCE_PART_1
//#define INHERITANCE_PART_2
//#define WRITE_TO_FILE
#define READ_TO_FILE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Academy
{
    class Program
    {
        static void Main(string[] args)
        {
#if INHERITANCE_PART_1
            Human human = new Human("Henriksson", "Martin", 35);
            human.Info();
            Console.WriteLine(human);

            Student student = new Student
                (
                "Pinkman", "Jessie", 22,
                "Chemistry", "WW_220", 90, 95
                );
            Console.WriteLine(student);

            Teacher teacher = new Teacher
                (
                "White", "Walter", 50,
                "Chemistry", 25
                );
            Console.WriteLine(teacher);

            Graduate graduate = new Graduate("Rosenberg", "Ken", 35, "Law", "Vice", 32, 25, "How to make money");
            Console.WriteLine(graduate);
#endif

#if INHERITANCE_PART_2
            Human human = new Human("Vercetty", "Tommy", 30);
            Console.WriteLine(human);

            Student student = new Student(human, "Auto", "Vice", 95, 98);
            Console.WriteLine(student);

            Graduate graduate = new Graduate(student, "How to make money");
            Console.WriteLine(graduate);
#endif

#if WRITE_TO_FILE
            //1) Upcast:
            Human[] group = new Human[]
                {
                new Student("Vercatty", "Tommy", 30, "Auto", "Vice", 91, 98),
                new Teacher("Diaz", "Ricardo", 45, "Weapons distribution", 20),
                new Graduate("Rosendetg", "Ken", 35, "Law", "Vice", 32, 25, "How to make money"),
                new Teacher("Colonel", "Cortez", 50, "Weapons distribution", 25)
                };
            Print(group);
            Save(group, "Group.csv");
             

#endif

            Human[] group = Load("Group.csv");
            Print(group);

        }
        static void Print(Human[] group)
        {
            for (int i = 0; i < group.Length; i++)
            {
                Console.WriteLine(group[i]);
            }
        }
        static void Save(Human[] group, string filename)
        {
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            Console.WriteLine(Directory.GetCurrentDirectory());
            //string filename = "Group.csv";
            StreamWriter writer = new StreamWriter(filename);
            foreach (Human h in group)
            {
                writer.WriteLine(h.ToFileSrting() + ";");
            }
            writer.Close();
            Process.Start("notepad", filename);//csv -- Comma-Separated Values (Значение, разделёно запятыми.) 
            
        }
        static Human[] Load(string filename)
        {
            List<Human> group = new List<Human>();
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            StreamReader reader = new StreamReader(filename);
            while(!reader.EndOfStream)
            {
                string record = reader.ReadLine();
                Console.WriteLine(record);
                group.Add(Factory(record.Split(':').First()).Init(record.Split(":,;".ToCharArray())));
            }
            reader.Close();
            return group.ToArray();
        }
        static Human Factory(string type)
        {
            Human human = null;
            switch(type)
            {
                case "Student": human = new Student("", "", 0, "", "", 0, 0);       break;
                case "Graduate": human = new Graduate("", "", 0, "", "", 0, 0, ""); break;
                case "Teacher": human = new Teacher("", "", 0, "", 0);              break;
            }
            return human;
        }
    }
}
