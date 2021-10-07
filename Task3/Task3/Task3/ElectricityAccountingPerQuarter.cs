using System;
using System.Text;

namespace Task3
{
    public class ElectricityAccountingPerQuarter:ElectricityAccounting
    {
        private const int monthsInQuarter = 3;
        public Quarter CurrentQuarter { get; private set; }
        public ElectricityAccountingPerMonth[] Electricity { get; private set; }

        public ElectricityAccountingPerQuarter(Quarter quarter,double inputIndicator1,
            double outputIndictor1, double inputIndicator2, double outputIndictor2,
            double inputIndicator3, double outputIndictor3)
        {
            CurrentQuarter = quarter;
            Electricity = new ElectricityAccountingPerMonth[monthsInQuarter];
            double[] init = { inputIndicator1, outputIndictor1, inputIndicator2, outputIndictor2, inputIndicator3, outputIndictor3 };
            int firstMonth;
            switch (CurrentQuarter)
            {
                case Quarter.I:
                    firstMonth = 1;
                    break;
                case Quarter.II:
                    firstMonth = 4;
                    break;
                case Quarter.III:
                    firstMonth = 7;
                    break;
                case Quarter.IV:
                    firstMonth = 10;
                    break;
                default:
                    throw new FormatException();
            }
            for (int i = 0, j = 0; i < Electricity.Length; i++, j += 2)
            {
                Electricity[i] = new ElectricityAccountingPerMonth((Month)firstMonth, init[j], init[j + 1]);
                firstMonth++;
            }
        }

        public override string ToString()
        {
            StringBuilder temp=new StringBuilder("Quarter: "+Enum.GetName(CurrentQuarter.GetType(),CurrentQuarter)+"\n");
            for (int i = 0; i < monthsInQuarter; i++)
            {
                temp.Append( Electricity[i]);
            }
            return temp.ToString(); 
        }
        public override double CountConsumedElectricity()
        {
            double res = 0;
            for (int i = 0; i < monthsInQuarter; i++)
            {
                res+=Electricity[i].CountConsumedElectricity();
            }
            return res;
        }
    }
}
