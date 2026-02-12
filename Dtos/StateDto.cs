namespace WebTestMVC.Dtos;

public class StateDto(int Id, string name, string code)
{
    public int Id { get; } = Id;
    public string Name { get; } = name;
    public string Code { get; } = code;
}