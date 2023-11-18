namespace TODO_B.E.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public string Content { get; set; }= String.Empty;
        public DateTime CreatedDate { get; set; }= DateTime.Now;

    }
}
