using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlatTest.Models;


namespace FlatTest.DAL
{
    
     public class FlatTestInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<FlatTestContext>
    {
         
         protected override void Seed(FlatTestContext context)
        {
            var groups = new List<Group>
            {
                new Group{ GroupName ="Admin", Description="Admin Group"},
                new Group{ GroupName ="Account", Description="Account Group"},
                new Group{ GroupName ="Client", Description="Clients Group"}
            };

            groups.ForEach(s => context.Groups.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User{UserID=1050,UserName="User1",GroupID=1,},
                new User{UserID=4022,UserName="User2",GroupID=3,},
                new User{UserID=4041,UserName="User3",GroupID=3,},
                new User{UserID=1045,UserName="User4",GroupID=2,},
                new User{UserID=3141,UserName="User5",GroupID=2,},
                new User{UserID=2021,UserName="User6",GroupID=3,},
                new User{UserID=2042,UserName="User7",GroupID=2,}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var stories = new List<Story>
            {
                new Story{UserID=1050,Description="aaa1",Title="Title1", PostedOn=DateTime.Now},
                new Story{UserID=4022,Description="aaa2",Title="Title2", PostedOn=DateTime.Now},
                new Story{UserID=4041,Description="aaa3",Title="Title3", PostedOn=DateTime.Now},
                new Story{UserID=1045,Description="aaa4",Title="Title4", PostedOn=DateTime.Now},
                new Story{UserID=3141,Description="aaa5",Title="Title5", PostedOn=DateTime.Now},
                new Story{UserID=2021,Description="aaa6",Title="Title6", PostedOn=DateTime.Now},
                new Story{UserID=1050,Description="aaa7",Title="Title7", PostedOn=DateTime.Now},
                new Story{UserID=1050,Description="aaa8",Title="Title8", PostedOn=DateTime.Now},
                new Story{UserID=4022,Description="aaa9",Title="Title9", PostedOn=DateTime.Now},
                new Story{UserID=4041,Description="aaa0",Title="Title0", PostedOn=DateTime.Now},
                new Story{UserID=1045,Description="aaa1",Title="Title1", PostedOn=DateTime.Now},
                new Story{UserID=3141,Description="aaa2",Title="Title2", PostedOn=DateTime.Now}
            };
            stories.ForEach(s => context.Stories.Add(s));
            context.SaveChanges();
        }
    }
}