namespace Domain.ValueObjects;

public record TopicId
{
    public Guid Value { get; }
    
    private TopicId(Guid value) => Value = value;

    public static TopicId Of(Guid value)
    {
        return value == Guid.Empty ? throw new DomainException("TopicId не может быть пустым.") : new TopicId(value);
    }
}