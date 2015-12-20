using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;

namespace APIDataObjects
{
    public class PositionData : IMessage
    {
        public PositionData(OptionContract optionContract, int position, double averageCost)
        {
            OptionContract = optionContract;
            Position = position;
            AverageCost = averageCost;
        }

        public OptionContract OptionContract { get; set; }
        public int Position { get; set; }
        public double AverageCost { get; set; }
    }
}
