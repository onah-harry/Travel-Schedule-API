using System.ComponentModel.DataAnnotations;

namespace TravelSchedule.BackService.Models
{
    public class Traveller
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        [StringLength(250)]
        public string? FirstName { get; set;}
        [Required]
        [StringLength(250)]
        public string? LastName { get; set;}
        [Required]
        [StringLength(250)]
        public string? DataOfBirth { get; set; }
        [Required]
        [StringLength(250)]
        public string? PrimaryAddress { get; set; }
    }
}
