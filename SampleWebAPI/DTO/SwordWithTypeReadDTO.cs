namespace SampleWebAPI.DTO
{
    public class SwordWithTypeReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeReadDTO SwordType { get; set; }
    }
}
