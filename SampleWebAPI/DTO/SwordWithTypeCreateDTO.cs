namespace SampleWebAPI.DTO
{
    public class SwordWithTypeCreateDTO
    {
        public string Name { get; set; }
        public string Weight { get; set; }
        public TypeCreateDTO SwordType { get; set; }
    }
}
