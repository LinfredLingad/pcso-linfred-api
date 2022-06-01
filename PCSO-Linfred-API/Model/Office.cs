namespace PCSO_Linfred_API.Model
{
    public class Office
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? position { get; set; }
        public string? department { get; set; }
        public string? imageURL { get; set; }
        public byte[]? image { get; set; } = null;  
        public string? description { get; set; }
        public int officeId { get; set; }
        public DateTime created { get; set; }
    }
}
