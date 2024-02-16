namespace FitnesCentar.Data
{
    public class ScheduleActivity
    {
        public int Id { get; set; }
        public int ActivityNumber { get; set; }

        public int ProgramTasksId { get; set; }
        public ProgramTask ProgramTasks { get; set; }
        
        public int FitnesInstructorId { get; set; }
        public FitnesInstructor FitnesInstructors { get; set; }

        public DateTime WeekDay { get; set; }
        public DateTime StarHour { get; set; }
        public DateTime EndHour { get; set; }

        public DateTime DateModified { get; set; } = DateTime.Now;
        public ICollection<Reservation> Reservations { get; set; }
    }
}
