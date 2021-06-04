using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CPlanner.Client.Models
{
    public class CustomerViewModel
    {
        public long Id { get; set; }
        
        
        [Required(ErrorMessage = "Please Enter a name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public List<EventViewModel> Events { get; set; }
          
    }
}