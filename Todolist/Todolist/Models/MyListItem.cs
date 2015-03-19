using System.ComponentModel.DataAnnotations;

namespace Todolist.Models
{
    public class MyListItem
    {
        public int ListID { get; set; }
        [Display(Name="Description")]
        public string ItemDescription { get; set; }
        public int ListItemID { get; set; }
    }
}