using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBaseClass
{
    class Bike:GroundVehicle
    {
        //Конкретный класс, по скольку опеределяет абстрактный метод.
        public override void Move()
        {
            Console.WriteLine($"{GetType()} ездит на двух колесах");
        }
    }
}
