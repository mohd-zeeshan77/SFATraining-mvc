namespace WebTestMVC.Dtos
{
    public sealed class CityDto(int Id, string Name, int StateId)
    {
        public int Id { get; } = Id;
        public string Name { get; } = Name;
        public int StateId { get; } = StateId;
    }
}
