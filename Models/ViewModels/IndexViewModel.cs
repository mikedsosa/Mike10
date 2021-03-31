using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mike10.Models.ViewModels
{
    public class IndexViewModel
    {
        // The IEnumberable is only pulled in the index page with the following statement
        // "@foreach (var x in Model.XXXXXXXXXXXX)"
        public List<Bowlers> Bowlers { get; set; }

        //this one is used to set how many pages there are
        public PagingInfo PagingInfo { get; set; }
        public string Type { get; set; }
    }
}
