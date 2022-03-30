namespace EducalProjectT210.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LessonCount { get; set; }
        public string AuthorName { get; set; }
        public decimal Rating { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category{ get; set; }
    }
}
