using System.ComponentModel.DataAnnotations;

namespace TravelSchedule.BackService.Models
{
    public class Accomodation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string? TypeOfAccomodation { get; set; }
        [Required]
        [StringLength(500)]
        public string? Address { get; set; }
        [Required]
        [StringLength(250)]
        public string? RoomCondition { get; set; }
        public int CompletedTravelId { get; set; }
        public virtual CompletedTravel CompletedTravels { get; set;}
    }
}
