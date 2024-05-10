using System.ComponentModel.DataAnnotations.Schema;

namespace FitnesCentar.Data
{
    public class ProgramTask
    {
        public int Id { get; set; }
        public int ProgramNumber { get; set; }

        public int ProgramCAategoriesId { get; set; }
        public ProgramCategory ProgramCategories { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal Price { get; set; }

        public DateTime DateModified { get; set; } = DateTime.Now;

        public ICollection<ScheduleActivity> ScheduleActivities { get; set; }//1:M

    }
}
