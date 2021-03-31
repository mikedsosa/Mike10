using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mike10.Models;

namespace Mike10.Components
{
    public class BowlingTeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public BowlingTeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            return View(context.Teams
                .Distinct()
                .OrderBy(b => b));
        }
    }
}
