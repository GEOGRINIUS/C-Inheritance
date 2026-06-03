//#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    class Teacher: AcademyMember
    {
        public int Experience { get; set; }
        public Teacher
        (
            string lastName, string firstName, int age,
            string speciality, int experience
        ) : base(lastName, firstName, age, speciality)
        {
            this.Experience = experience;
#if DEBUG
            Console.WriteLine($"TConstructor:\t{GetHashCode()}"); 
#endif
        }
        ~Teacher()
        {
#if DEBUG
            Console.WriteLine($"TDestructor:\t{GetHashCode()}"); 
#endif
        }

        public override string ToString()
        {
            return base.ToString() + $" {Experience}";
        }

    }
}
