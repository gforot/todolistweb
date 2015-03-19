using System.ComponentModel.DataAnnotations;

namespace Todolist.Models
{
    public class MyUser
    {
        public int UserID { get; set; }
        
        [Display(Name="User")]
        public string UserName { get; set; }
        
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}