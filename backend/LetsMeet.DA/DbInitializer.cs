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
                    UserName = "Username1"
                });
                _context.Users.Add(new User()
                {
                    Id = "b",
                    UserName = "Username2"
                });
                _context.Users.Add(new User()
                {
                    Id = "c",
                    UserName = "Username3"
                });
                _context.Users.Add(new User()
                {
                    Id = "d",
                    UserName = "Username4"
                });
                _context.Users.Add(new User()
                {
                    Id = "e",
                    UserName = "Username5"
                });
                _context.SaveChanges();
            }

            if (!_context.Events.Any())
            {
                _context.Events.Add(new Event()
                {
                    //Id = 1,
                    Address = "Address1",
                    Category = Category.Tech,
                    Description = "Description1",
                    StartDate = DateTime.Now.AddDays(10),
                    EndDate = DateTime.Now.AddDays(10).AddHours(2),
                    HostId = "a",
                    Title = "Event1"
                });

                _context.Events.Add(new Event()
                {
                    //Id = 2,
                    Address = "Address1",
                    Category = Category.Tech,
                    Description = "Description2",
                    StartDate = DateTime.Now.AddDays(11),
                    EndDate = DateTime.Now.AddDays(11).AddHours(2),
                    HostId = "a",
                    Title = "Event2"
                });

                _context.Events.Add(new Event()
                {
                    //Id = 3,
                    Address = "Address3",
                    Category = Category.Tech,
                    Description = "Description3",
                    StartDate = DateTime.Now.AddDays(12),
                    EndDate = DateTime.Now.AddDays(12).AddHours(6),
                    HostId = "b",
                    Title = "Event3"
                });

                _context.Events.Add(new Event()
                {
                    //Id = 4,
                    Address = "Address4",
                    Category = Category.FashionBeauty,
                    Description = "Description4",
                    StartDate = DateTime.Now.AddDays(13),
                    EndDate = DateTime.Now.AddDays(13).AddHours(48),
                    HostId = "c",
                    Title = "Event4"
                });
                _context.Events.Add(new Event()
                {
                    //Id = 5,
                    Address = "Address5",
                    Category = Category.FashionBeauty,
                    Description = "Description5",
                    StartDate = DateTime.Now.AddDays(14),
                    EndDate = DateTime.Now.AddDays(14).AddHours(1),
                    HostId = "e",
                    Title = "Event5"
                });
                _context.SaveChanges();
            }

            if (!_context.Participants.Any())
            {
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "a"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "a"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "a"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 3,
                    UserId = "a"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "b"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "b"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 4,
                    UserId = "b"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 5,
                    UserId = "b"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "c"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 3,
                    UserId = "c"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 1,
                    UserId = "d"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "d"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 5,
                    UserId = "d"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 2,
                    UserId = "e"
                });
                _context.Participants.Add(new Participant()
                {
                    EventId = 4,
                    UserId = "e"
                });
                _context.SaveChanges();
            }
        }
    }
}