using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaoTran.Data
{
    public class PlaySchedual
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlaySchedual { get; set; }
        public DayOfWeek DaysOfWeek { get; set; } //Monday, Tuesday... 
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdMediaFile { get; set; }
        public MediaFile MediaFile { get; set; }


    }
}
