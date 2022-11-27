namespace Contact.Data.Entities
{
    public class Info
    {
        public int Id { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
