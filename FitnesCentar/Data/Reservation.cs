namespace FitnesCentar.Data
{
    public class Reservation
    {
        public int Id { get; set; }
       
        public int ScheduleActivitiesId { get; set; }
        public ScheduleActivity ScheduleActivities { get; set; }

        public string ClientsId { get; set; }
        public Client Clients { get; set; }

        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
