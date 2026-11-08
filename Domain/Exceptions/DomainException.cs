namespace Domain.Exceptions;

public class DomainException(string message) : Exception($"Domain exception: {message}.");