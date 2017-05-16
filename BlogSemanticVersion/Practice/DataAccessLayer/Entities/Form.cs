namespace DataAccessLayer.Entities
{
    public class Form
    {
        public int FormId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int? Age { get; set; }
        public string FavouriteBrowser { get; set; }
        public string Preferable { get; set; }
        public string MarkOfForm { get; set; }
    }
}
