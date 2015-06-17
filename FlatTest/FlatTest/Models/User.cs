using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlatTest.Models
{
    public class User
    {
        public User() 
        {
 
        }
        public int UserID { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public virtual ICollection<Story> Stories { get; set; }

        public virtual int GroupID { get; set; }
        public virtual Group Group { get; set; }
    }

}