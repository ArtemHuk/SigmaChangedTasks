using System;
namespace Task3
{
    public class ElectricityAccountingPerMonth:ElectricityAccounting
    {
        public  Month CurrentMonth
        {
            get;
            private set;
        }
        private double inputIndicator;
        private double outputIndicator;
        public ElectricityAccountingPerMonth(Month month,double inputIndicator,double outputIndicator)
        {
            CurrentMonth = month;
            this.inputIndicator = inputIndicator;
            this.outputIndicator = outputIndicator;
        }
        public override string ToString()
        {
            return String.Format($"{Enum.GetName(CurrentMonth.GetType(),CurrentMonth),-6} {inputIndicator,-6} {outputIndicator,-6}\n");
        }
        public override double CountConsumedElectricity()
        {
            return outputIndicator - inputIndicator;
        }
    }
}
