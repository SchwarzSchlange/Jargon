using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jargon
{
    class JarHistory
    {
        public string url;
        public string title;
        public string visit_count;
        public string last_visit_time;


        public JarHistory(string u,string t,string v,string l)
        {
            this.url = u;
            this.title = t;
            this.visit_count = v;
            this.last_visit_time = l;
        }
    }
}
