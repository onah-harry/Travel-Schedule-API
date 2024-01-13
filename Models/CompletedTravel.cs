using System.ComponentModel.DataAnnotations;

namespace TravelSchedule.BackService.Models
{
    public class CompletedTravel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ArrivalDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ArrivalTime { get; set; }
        public bool? CheckIn { get; set; }

        public int TravelId { get; set; }
        public virtual Travel Travels { get; set; }
    }
}
