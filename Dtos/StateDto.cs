namespace WebTestMVC.Dtos;

public class StateDto(int Id, string name, string code, bool IsActive)
{
    public int Id { get; } = Id;
    public string Name { get; } = name;
    public string Code { get; } = code;
    public bool IsActive { get; } = IsActive;
}