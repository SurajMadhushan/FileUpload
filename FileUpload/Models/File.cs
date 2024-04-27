namespace FileUpload.Models
{
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public Project Project { get; set; }
        public int? ProjectId { get; set; }

        public Task Tasks { get; set; }
        public int? TaskId { get; set; }


    }
}
