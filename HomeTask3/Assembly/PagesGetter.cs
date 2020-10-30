using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3.Assembly
{
    public class PagesGetter
    {
        public static T GetPages<T>() where T : new()
        {
            var page = new T();
            return page;
        }
    }
}
