namespace Presentation.Data;

public class EventEntity
{
    public string Id { get; set; } = new Guid().ToString();
    public string Name { get; set; } = null!;
}
