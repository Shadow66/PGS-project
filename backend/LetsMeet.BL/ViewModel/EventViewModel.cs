using System.ComponentModel.DataAnnotations;

namespace LetsMeet.BL.ViewModel
{
    public class EventViewModel
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(10)]
        public string HostId { get; set; }
        public string Address { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}