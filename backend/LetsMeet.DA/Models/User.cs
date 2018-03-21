using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LetsMeet.DA.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public ICollection<Event> Events { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}
