using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsMeet.DA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LetsMeet.DA
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Run Migrations
                context.Database.Migrate();
                if (!context.Users.Any())
                {
                    context.Users.Add(new User()
                    {
                        Id = "a",
                        UserName = "Username1"
                    });
                    context.Users.Add(new User()
                    {
                        Id = "b",
                        UserName = "Username2"
                    });
                    context.Users.Add(new User()
                    {
                        Id = "c",
                        UserName = "Username3"
                    });
                    context.Users.Add(new User()
                    {
                        Id = "d",
                        UserName = "Username4"
                    });
                    context.Users.Add(new User()
                    {
                        Id = "e",
                        UserName = "Username5"
                    });
                    context.SaveChanges();
                }

                if (!context.Events.Any())
                {
                    context.Events.Add(new Event()
                    {
                        //Id = 1,
                        Address = "Address1",
                        Category = Category.Tech,
                        Description = "Opis wydarzenia1",
                        StartDate = DateTime.Now.AddDays(10),
                        EndDate = DateTime.Now.AddDays(10).AddHours(2),
                        HostId = "a",
                        Title = "Event1"
                    });

                    context.Events.Add(new Event()
                    {
                        //Id = 2,
                        Address = "Address1",
                        Category = Category.Tech,
                        Description = "Opis wydarzenia2",
                        StartDate = DateTime.Now.AddDays(11),
                        EndDate = DateTime.Now.AddDays(11).AddHours(2),
                        HostId = "a",
                        Title = "Event2"
                    });

                    context.Events.Add(new Event()
                    {
                        //Id = 3,
                        Address = "Address3",
                        Category = Category.Tech,
                        Description = "Opis wydarzenia3",
                        StartDate = DateTime.Now.AddDays(12),
                        EndDate = DateTime.Now.AddDays(12).AddHours(6),
                        HostId = "b",
                        Title = "Event3"
                    });

                    context.Events.Add(new Event()
                    {
                        //Id = 4,
                        Address = "Address4",
                        Category = Category.FashionBeauty,
                        Description = "Opis wydarzenia4",
                        StartDate = DateTime.Now.AddDays(13),
                        EndDate = DateTime.Now.AddDays(13).AddHours(48),
                        HostId = "c",
                        Title = "Event4"
                    });
                    context.Events.Add(new Event()
                    {
                        //Id = 5,
                        Address = "Address5",
                        Category = Category.FashionBeauty,
                        Description = "Opis wydarzenia5",
                        StartDate = DateTime.Now.AddDays(14),
                        EndDate = DateTime.Now.AddDays(14).AddHours(1),
                        HostId = "e",
                        Title = "Event5"
                    });
                    context.SaveChanges();
                }

                if (!context.Participants.Any())
                {
                    context.Participants.Add(new Participant()
                    {
                        EventId = 1,
                        UserId = "a"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 2,
                        UserId = "a"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 2,
                        UserId = "a"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 3,
                        UserId = "a"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 1,
                        UserId = "b"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 2,
                        UserId = "b"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 4,
                        UserId = "b"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 5,
                        UserId = "b"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 1,
                        UserId = "c"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 3,
                        UserId = "c"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 1,
                        UserId = "d"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 2,
                        UserId = "d"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 5,
                        UserId = "d"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 2,
                        UserId = "e"
                    });
                    context.Participants.Add(new Participant()
                    {
                        EventId = 4,
                        UserId = "e"
                    });
                    context.SaveChanges();
                }

            }
        }
    }
}
