//#define INHERITANCE_PART_1
//#define INHERITANCE_PART_2
#define INHERITANCE_PART_3
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
        //1) Upcast:
        Human[] group = new Human[]
            {
                new Student("Vercatty", "Tommy", 30, "Auto", "Vice", 91, 98),
                new Teacher("Diaz", "Ricardo", 45, "Weapons distribution", 20),
                new Graduate("Rosendetg", "Ken", 35, "Law", "Vice", 32, 25, "How to make money"),
                new Teacher("Colonel", "Cortez", 50, "Weapons distribution", 25)
            };
            for(int i=0; i<group.Length; i++)
            {
                Console.WriteLine(group[i]);
            }

            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
            Console.WriteLine(Directory.GetCurrentDirectory());
            string filename = "Group.csv";
            StreamWriter writer = new StreamWriter(filename);
            foreach(Human h in group)
            {
                writer.WriteLine(h.ToFileSrting()+";");
            }
            writer.Close();
            Process.Start("notepad", filename);//csv -- Comma-Separated Values (Значение, разделёно запятыми.)
        }
    }
}
