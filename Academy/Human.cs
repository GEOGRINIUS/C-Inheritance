//#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    class Human
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public Human(string lastName, string firstName, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
#if DEBUG
            Console.WriteLine($"HConstructor:{GetHashCode()}"); 
#endif
        }
        public Human(Human other)
        {
            this.LastName = other.LastName;
            this.FirstName = other.FirstName;
            this.Age = other.Age;
        }
        ~Human()
        {
#if DEBUG
            Console.WriteLine($"HDestructor:\t{GetHashCode()}"); 
#endif
        }

        //                              Methods:
        public void Info()
        {
#if DEBUG
            Console.WriteLine($"{LastName} {FirstName} {Age}"); 
#endif
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{LastName.PadRight(12)} {FirstName.PadRight(12)} {Age.ToString().PadLeft(2).PadRight(3)}"; 
        }
        public virtual string ToFileSrting()
        {
            return $"{this.GetType().ToString().Split('.').Last()}:{LastName},{FirstName},{Age}";
        }
        public virtual Human Init(string[] values)
        {
            this.LastName =             values[1];
            this.FirstName =            values[2];
            this.Age = Convert.ToInt32(values[3]);
            return this;
        }
    }
}
