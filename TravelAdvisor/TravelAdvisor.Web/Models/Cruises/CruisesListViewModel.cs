using System.Collections.Generic;

namespace TravelAdvisor.Web.Models.Cruises
{
    public class CruisesListViewModel
    {
        public IEnumerable<CruiseItemViewModel> Cruises { get; set; }
    }
}