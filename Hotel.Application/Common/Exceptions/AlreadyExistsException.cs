namespace Hotel.Application.Common.Exceptions;

public class AlreadyExistsException(string message) : Exception(message);