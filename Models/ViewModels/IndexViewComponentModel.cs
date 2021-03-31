using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mike10.Models.ViewModels
{
    public class IndexViewComponentModel
    {
        // The IEnumberable is only pulled in the index page with the following statement
        // "@foreach (var x in Model.XXXXXXXXXXXX)"
        public IEnumerable<Teams> Teams { get; set; }

        //this one is used to set how many pages there are
        public PagingInfo PagingInfo { get; set; }
    }
}
