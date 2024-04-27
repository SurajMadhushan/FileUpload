namespace FileUpload.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }


        public Project Project { get; set; }
        public int ProjectId { get; set; }

        public List<File> Files { get; set; }
    }
}
