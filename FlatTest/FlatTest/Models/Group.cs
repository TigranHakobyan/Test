using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlatTest.Models
{
    public class Group
    {
        public Group() 
        {
 
        }
        public int GroupID { get; set; }
                
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Story> Stories { get; set; }
        
    }
}