using AbstractBaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_base_class
{
    class Plane: AirVehicle
    {
        public override void TopUp()
        {
            Console.WriteLine($"{GetType()} взлетает на высокой скорости, поэтому нужна взлётная полоса");
        }
        public override void Land()
        {
            Console.WriteLine($"{GetType()} Приземляется на высокой скорости, поэтому нужна взлётная полоса");
        }
        public override void Move()
        {
            TopUp();
            Console.WriteLine($"{GetType()} Летит на выокой скорости");
            Land();
        }
    }
}
