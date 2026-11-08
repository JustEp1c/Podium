namespace Domain.Models;

public class Topic : Entity<TopicId>
{
    public string Title { get; set; } = null!;
    public DateTime? EventStart { get; set; }
    public string Summary { get; set; } = null!;
    public string TopicType { get; set; } = null!;
    public Location Location { get; set; } = null!;

    public static Topic Create(TopicId id, string title, DateTime eventStart, string summary, string topicType, Location location)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(summary);
        ArgumentException.ThrowIfNullOrWhiteSpace(topicType);

        return new Topic
        {
            Id = id,
            Title = title,
            EventStart = eventStart,
            Summary = summary,
            TopicType = topicType,
            Location = location 
        };
    }
}