using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; 
using System.Threading.Tasks;
using FlatTest.Models; 
 
namespace FlatTest.Service 
{ 
    public class StoryService 
    {
        private ApplicationDbContext _context; 
 
        public StoryService(ApplicationDbContext context) 
        { 
            _context = context; 
        }

        public Story AddStory(string content, string title, string description, DateTime postedon, int userID) 
        {
            var blog = _context.Stories.Add(new Story { Content = content, Title = title, Description= description, PostedOn = postedon, UserID = userID }); 
            _context.SaveChanges(); 
 
            return blog; 
        }

        public List<Story> GetAllStories() 
        { 
            var query = from b in _context.Stories 
                        orderby b.Title 
                        select b; 
 
            return query.ToList(); 
        }

        public async Task<List<Story>> GetAllStoriesAsync() 
        {
            var query = from b in _context.Stories
                        orderby b.Title 
                        select b; 
 
            return await query.ToListAsync(); 
        } 
    } 
}