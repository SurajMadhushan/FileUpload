namespace FileUpload.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public List<File> Files { get; set;}

        public List<Task> Tasks { get; set;}
    }
}
