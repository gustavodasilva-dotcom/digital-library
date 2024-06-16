namespace DigitalLibrary.Common.Infrastructure.MessageBroker;

public sealed class MessageBrokerSettings
{
    public const string Position = "MessageBroker";

    public string Host { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
}
