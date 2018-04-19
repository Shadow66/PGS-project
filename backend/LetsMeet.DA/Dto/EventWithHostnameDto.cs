using System;
using System.Collections.Generic;
using System.Text;

namespace LetsMeet.DA.Dto
{
    public class EventWithHostNameDto
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
    }
}
