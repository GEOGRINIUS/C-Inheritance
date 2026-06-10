using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    class AcademyMember : Human
    {
        public string Speciality { get; set; }
        public AcademyMember
        (
            string lastName, string firstName, int age,
            string speciality
        ): base(lastName, firstName, age)
        {
            this.Speciality = speciality;
        }
        public AcademyMember(Human human, string speciality) : base(human)
        {
            this.Speciality = speciality;
        }
        public AcademyMember(AcademyMember other):base(other)
        {
            this.Speciality = other.Speciality;
        }
        ~AcademyMember()
        { 
        }

        public override string ToString()
        {
            return base.ToString() + $"{Speciality.PadRight(22)}";
        }
        public override string ToFileSrting()
        {
            return base.ToFileSrting()+$",{Speciality}";
        }
        public override Human Init(string[] values)
        {
            base.Init(values);
            this.Speciality = values[4];
            return this;
        }
    }
}
