using System;

namespace CPlanner.Client.Models
{
    public class EventViewModel
    {
       public long Id { get; set; }
       
       
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public string Title { get; set; }

        public LocationViewModel Location { get; set; }
        
        
    }
}