
using System.ComponentModel.DataAnnotations;


namespace Todolist.Models
{
    public class MyList
    {
        public int ListID { get; set; }
        
        [Display(Name="Name")]
        public string ListName { get; set; }

        [Display(Name = "Description")]
        public string ListDescription { get; set; }

        public int UserID { get; set; }
    }
}