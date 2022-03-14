using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jargon
{
    class JarPassword
    {
        public string ORIGIN { get; set; }
        public string NAME { get; set; }
        public string VALUE { get; set; }


        public JarPassword(string _o,string _n,string _v)
        {
            this.ORIGIN = _o;
            this.NAME = _n;
            this.VALUE = _v;
        }
    
    }
}
