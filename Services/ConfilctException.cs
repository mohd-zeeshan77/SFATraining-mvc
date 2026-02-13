namespace WebTestMVC.Services;

public sealed class ConflictException(string message) : Exception(message);