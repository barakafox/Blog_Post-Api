namespace Trier_3.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string BlogPostTitle { get; set; }
        public DateTime DateTime { get; set; }
        public List<int> numberofsubscribe {  get; set; }
        public List<string> nameofsubscribe { get; set; }
        public User User { get; set; }
    }
}
