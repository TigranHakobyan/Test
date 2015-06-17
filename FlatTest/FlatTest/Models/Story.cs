using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlatTest.Models
{
    public class Story
    {
        public Story() 
        {
 
        }
        public int StoryID { get; set; }
        public string Title {get; set; }
        public string Description {get; set; }

        public string Content {get; set; }

        public DateTime PostedOn {get; set; }

        public virtual int UserID { get; set; }
        public virtual User User { get; set; }

        //public virtual int GroupID { get; set; }
        //public virtual Group Group { get; set; }
        
    }
}