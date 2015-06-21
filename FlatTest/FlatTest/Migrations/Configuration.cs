namespace FlatTest.Migrations
{
    using FlatTest.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
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
                new User{UserID=1,UserName="User1",GroupID=1,},
                new User{UserID=2,UserName="User2",GroupID=3,},
                new User{UserID=3,UserName="User3",GroupID=3,},
                new User{UserID=4,UserName="User4",GroupID=2,},
                new User{UserID=5,UserName="User5",GroupID=2,},
                new User{UserID=6,UserName="User6",GroupID=3,},
                new User{UserID=7,UserName="User7",GroupID=2,}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var stories = new List<Story>
            {
                new Story{UserID=1,Description="aaa1",Title="Title1",Content="Content1", PostedOn=DateTime.Now},
                new Story{UserID=2,Description="aaa2",Title="Title2",Content="Content2", PostedOn=DateTime.Now},
                new Story{UserID=3,Description="aaa3",Title="Title3",Content="Content3", PostedOn=DateTime.Now},
                new Story{UserID=4,Description="aaa4",Title="Title4",Content="Content4", PostedOn=DateTime.Now},
                new Story{UserID=5,Description="aaa5",Title="Title5",Content="Content5", PostedOn=DateTime.Now},
                new Story{UserID=7,Description="aaa6",Title="Title6",Content="Content6", PostedOn=DateTime.Now},
                new Story{UserID=1,Description="aaa7",Title="Title7",Content="Content7", PostedOn=DateTime.Now},
                new Story{UserID=1,Description="aaa8",Title="Title8",Content="Content8", PostedOn=DateTime.Now},
                new Story{UserID=2,Description="aaa9",Title="Title9",Content="Content9", PostedOn=DateTime.Now},
                new Story{UserID=3,Description="aaa0",Title="Title0",Content="Content0", PostedOn=DateTime.Now},
                new Story{UserID=4,Description="aaa1",Title="Title1",Content="Content1", PostedOn=DateTime.Now},
                new Story{UserID=6,Description="aaa2",Title="Title2",Content="Content2", PostedOn=DateTime.Now}
            };
            stories.ForEach(s => context.Stories.Add(s));
            context.SaveChanges();
        }
    }
}
