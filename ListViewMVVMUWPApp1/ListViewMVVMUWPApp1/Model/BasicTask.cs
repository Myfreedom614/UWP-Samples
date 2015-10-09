using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMVVMUWPApp1.Model
{
    public class BasicTask
    {
        public string Title { get; set; }

        public static BasicTask Default = new BasicTask()
        {
            Title = "Default Task"
        };
    }
}
