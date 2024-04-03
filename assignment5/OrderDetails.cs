using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    internal class OrderDetails
    {
        public string commdityName { get; set; }
        public OrderDetails(string com, int ammount,double money)
        {
            this.commdityName = com;
            this.ammount = ammount;
            this.commdityMoney = money;
        }

        public double commdityMoney { get; set; }
        public int ammount{ get; set; }

        public override string ToString()
        {
            return $"commdityName:{commdityName};\n ammount:{ammount};\ncommdityMoney:{commdityMoney}";
        }

        public override bool Equals(object? obj)
        {
            if(obj is OrderDetails orderObj)return commdityMoney == orderObj.commdityMoney && 
                    commdityName == orderObj.commdityName && ammount == orderObj.ammount;
            return false;
        }
    }
}
