namespace Trier_3.Dtos
{
    public class BlogPostDto
    {
        public string BlogPostTitle { get; set; }
        public DateTime DateTime { get; set; }
        public List<int> numberofsubscribe { get; set; }
        public List<string> nameofsubscribe { get; set; }
    }
}