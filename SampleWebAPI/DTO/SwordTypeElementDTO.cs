namespace SampleWebAPI.DTO
{
    public class SwordTypeElementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public TypeReadDTO SwordType { get; set; }
        public List<AttrElementReadDTO> AttrElements { get; set; }
    }
}
