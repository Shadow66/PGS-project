using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetsMeet.DA.Models
{
    public enum Category
    {
        ArtsCulture,
        BookClubs,
        CareerBusiness,
        CarsMotorcycles,
        CommunityEnvironment,
        Dancing,
        EducationLearning,
        FashionBeauty,
        Fitness,
        FoodDrink,
        Games,
        HealthWellbeing,
        HobbiesCrafts,
        LanguageEthnicIdentity,
        Lifestyle,
        MovementsPolitics,
        MoviesFilm,
        Music,
        OutdoorsAdventure,
        ParentsFamily,
        PetsAnimals,
        Photography,
        ReligionBeliefs,
        SciFiFantasy,
        Singles,
        Socializing,
        SportsRecreation,
        Support,
        Tech,
        Writing
    }

    public class Event
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string HostId { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}
