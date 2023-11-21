using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pic7
{
    public partial class BonusCardSystem : XMLWorker<BonusCard>
    {

        public BonusCardSystem() { }
        public List<BonusCard> bonusCards { get; set; }

        public delegate bool ValidationDelegate(string str);

        public bool ValidateLength(string str)
        {
            return str.Length == 10;
        }


    }
}
