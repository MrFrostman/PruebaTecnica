namespace LoginWebApi.Models
{
    public class Article
    {

        public int IdArticle { get; set; } 
        public string Title { get; set; }
        public string Contenido { get; set; }   
        public DateTime PublisDate { get; set; } = DateTime.Now;
        public int MemberID { get; set; }
    }
}
