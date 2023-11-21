using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pic7
{
    public static class BonusCardExtensions
    {
        public static string ShowCard(this BonusCard card)
        {
            return "Card number: " + card.Number + "\n" + "Bonuses left: " + card.Bonuses + "\n";
        }

    }
}
