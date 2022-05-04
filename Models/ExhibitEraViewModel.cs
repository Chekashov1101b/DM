using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DM.Models
{
    public class ExhibitEraViewModel
    {
            public List<Data.Entity.Exhibit> Exhibits { get; set; }
            public SelectList Era { get; set; }
            public int ExhibitEra { get; set; }
            public string SearchString { get; set; }

    }
}
