namespace Domain.Abstractions;

public interface IEntity<T>
{
    public T Id { get; set; }
}

public interface IEntity
{
}