namespace zenbox.model
{
    public class InvoiceModel
    {
        public Guid Id { get; set; }
        public Guid HeaderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Checked { get; set; }
    }
}
