namespace FitnesCentar.Data
{
    public class ProgramCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateModified { get; set; } = DateTime.Now;
        public ICollection<ProgramTask> ProgramTasks { get; set; }
    }
}
