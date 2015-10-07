using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticZoomUWPApp1.Model
{
    public class LiveStreamModel
    {
        public List<SubItem> schedule { get; set; }
    }

    public class SubItem
    {
        public string @event { get; set; }
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
    }
}
