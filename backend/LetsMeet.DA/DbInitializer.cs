using System;
using System.Linq;
using LetsMeet.DA.Enums;
using LetsMeet.DA.Interfaces;
using LetsMeet.DA.Models;
using Microsoft.EntityFrameworkCore;

namespace LetsMeet.DA
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.Migrate();
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User()
                {
                    Id = "a",
                    UserName = "lillie.mccullou@hotmail.com"
                });
                _context.Users.Add(new User()
                {
                    Id = "b",
                    UserName = "mckayla.may@yahoo.com"
                });
                _context.Users.Add(new User()
                {
                    Id = "c",
                    UserName = "khalid1983@gmail.com"
                });
                _context.Users.Add(new User()
                {
                    Id = "d",
                    UserName = "brendon_conr@hotmail.com"
                });
                _context.Users.Add(new User()
                {
                    Id = "e",
                    UserName = "peter.larki10@hotmail.com"
                });
                _context.Users.Add(new User()
                {
                    Id = "f",
                    UserName = "giuseppe2012@gmail.com"
                });
                _context.Users.Add(new User()
                {
                    Id = "g",
                    UserName = "krystel.kli@gmail.com"
                });
                _context.Users.Add(new User()
                {
                    Id = "h",
                    UserName = "roma_herma3@yahoo.com"
                });
                _context.Users.Add(new User()
                {
                    Id = "i",
                    UserName = "alvis_barto2@hotmail.com"
                });
                _context.Users.Add(new User()
                {
                    Id = "j",
                    UserName = "consuelo.hami@yahoo.com"
                });
                _context.SaveChanges();
            }

            if (!_context.Events.Any())
            {
                _context.Events.Add(new Event()
                {
                    Address = "Pawleys Island, 4677  Camden Place",
                    Category = Category.Lifestyle,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(10),
                    EndDate = DateTime.Now.AddDays(10).AddHours(2),
                    HostId = "a",
                    Title = "World-Wide Comedy Open Mic Night"
                });

                _context.Events.Add(new Event()
                {
                    Address = "Fremont, 633  Green Avenue",
                    Category = Category.Tech,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(11),
                    EndDate = DateTime.Now.AddDays(11).AddHours(2),
                    HostId = "i",
                    Title = "AZURE CAMP with XPLUS"
                });

                _context.Events.Add(new Event()
                {
                    Address = "Topeka, 368  Dog Hill Lane",
                    Category = Category.Lifestyle,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(12),
                    EndDate = DateTime.Now.AddDays(12).AddHours(6),
                    HostId = "b",
                    Title = "Pineapple Event"
                });

                _context.Events.Add(new Event()
                {
                    Address = "Davenport, 1857  Pyramid Valley Road",
                    Category = Category.Socializing,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(13),
                    EndDate = DateTime.Now.AddDays(13).AddHours(1),
                    HostId = "c",
                    Title = "Comedy Overboard!"
                });
                _context.Events.Add(new Event()
                {
                    Address = "Daytona Beach, 4307  Willis Avenue",
                    Category = Category.Lifestyle,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(14),
                    EndDate = DateTime.Now.AddDays(14).AddHours(1),
                    HostId = "e",
                    Title = "Yoga & Meditation Classes"
                });
                _context.Events.Add(new Event()
                {
                    Address = "Millington, 3650  Gladwell Street",
                    Category = Category.Writing,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(14),
                    EndDate = DateTime.Now.AddDays(14).AddHours(1),
                    HostId = "f",
                    Title = "The Hidden Heroes 3.0"
                });
                _context.Events.Add(new Event()
                {
                    Address = "Lake Charles, 2981  Sarah Drive",
                    Category = Category.Tech,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(11),
                    EndDate = DateTime.Now.AddDays(11).AddHours(1),
                    HostId = "g",
                    Title = "_pureCodeArt"
                });
                _context.Events.Add(new Event()
                {
                    Address = "Daytona Beach, 4307  Willis Avenue",
                    Category = Category.Tech,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(9),
                    EndDate = DateTime.Now.AddDays(9).AddHours(1),
                    HostId = "i",
                    Title = "Coding Dojo"
                });
                _context.Events.Add(new Event()
                {
                    Address = "Denver, 3285  Columbia Road",
                    Category = Category.FashionBeauty,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(5),
                    EndDate = DateTime.Now.AddDays(5).AddHours(1),
                    HostId = "h",
                    Title = "SW developement MeetUp..."
                });
                _context.Events.Add(new Event()
                {
                    Address = "Newark, 4362  Caynor Circle",
                    Category = Category.Tech,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi. Cras vel lorem. Etiam pellentesque aliquet tellus. Phasellus pharetra nulla ac diam. Quisque semper justo at risus. Donec venenatis, turpis vel hendrerit interdum, dui ligula ultricies purus, sed posuere libero dui id orci. Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu, vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. Phasellus congue lacus eget neque. Phasellus ornare, ante vitae consectetuer consequat, purus sapien ultricies dolor, et mollis pede metus eget nisi. Praesent sodales velit quis augue. Cras suscipit, urna at aliquam rhoncus, urna quam viverra nisi, in interdum massa nibh nec erat.",
                    StartDate = DateTime.Now.AddDays(15),
                    EndDate = DateTime.Now.AddDays(15).AddHours(1),
                    HostId = "j",
                    Title = "Simplicity vs simplification"
                });
                _context.SaveChanges();
            }

            if (!_context.Participants.Any())
            {
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "g"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "f"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "b"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "c"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "d"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "a"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "i"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "b"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "d"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "e"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "f"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "h"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "c"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 3,
                    UserId = "h"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 4,
                    UserId = "g"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 4,
                    UserId = "c"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 4,
                    UserId = "b"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 5,
                    UserId = "d"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 5,
                    UserId = "i"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 6,
                    UserId = "j"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 7,
                    UserId = "c"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 7,
                    UserId = "d"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 7,
                    UserId = "a"
                }); _context.Participants.Add(new Participant()
                {
                    EventId = 7,
                    UserId = "i"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 7,
                    UserId = "g"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 7,
                    UserId = "e"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 8,
                    UserId = "j"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 8,
                    UserId = "b"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 9,
                    UserId = "a"
                });
                _context.SaveChanges();
            }
        }
    }
}