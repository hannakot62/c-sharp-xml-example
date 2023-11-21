using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pic7
{
    public class XMLWorker <T>
    {
        protected virtual List<T> GetData(string filepath) { return null; }
        protected virtual void SetData(List<T> list, string filepath) { }

    }
}
