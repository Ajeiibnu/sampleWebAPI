namespace SampleWebAPI.DTO
{
    public class SamuraiWithSwordCreateDTO
    {
        public string Name { get; set; }
        public List<SwordCreateDTO> Swords { get; set; }
    }
}
