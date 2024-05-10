namespace FitnesCentar.Data
{
    public class FitnesInstructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;
        public ICollection<ScheduleActivity> ScheduleActivities { get; set; }
    }
}
