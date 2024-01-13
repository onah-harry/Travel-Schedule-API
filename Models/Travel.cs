using System.ComponentModel.DataAnnotations;

namespace TravelSchedule.BackService.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string? Destination { get; set; }

        [Required]
        [StringLength(250)]
        public string? Purpose { get; set; }       
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? EndDate { get; set; }

        public string? TravellerId { get; set; }
        public virtual Traveller Travellers { get; set; }
    }
}
