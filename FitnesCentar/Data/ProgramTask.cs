using System.Net.Sockets;

namespace FitnesCentar.Data
{
    public class ProgramTask
    {
        public int Id { get; set; }
        public int ProgramNumber { get; set; }        

        public int ProgramCategoriesId { get; set; }
        public ProgramCategory ProgramCategories { get; set; }
       
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public  decimal Price { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;

        public ICollection<ScheduleActivity> ScheduleActivities { get; set; }//1:M
           
    }
}
