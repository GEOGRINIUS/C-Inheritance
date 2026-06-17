using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractBaseClass
{
    class Vehicle
    {
        public int Speed { get; set; }
        public abstract void Move();    
        //Абстрактный класс, потому что объявляется метод.
    }
}
