using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pic7
{
    public class BonusCard
    {
        public string Number { get; set; }
        public int Bonuses { get; set; }

        public BonusCard() { }
        public BonusCard(string number, int bonuses)
        {
            this.Bonuses = bonuses;
            this.Number = number;
        }
        
    }
}
