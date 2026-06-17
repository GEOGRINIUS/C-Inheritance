using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBaseClass
{
    class Car:GroundVehicle
    {
        public override void Move()
        {
            Console.WriteLine($"{GetType()} Ездит на четырёх колёсах");
        }
    }
}
