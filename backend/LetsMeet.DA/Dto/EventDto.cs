using System;
using System.Collections.Generic;
using System.Text;
using LetsMeet.DA.Models;

namespace LetsMeet.DA.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        public string HostId { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}