using System;

public class EmptyMessageException : Exception
{
    public Person Sender { get; }
    public Person Receiver { get; }
    private readonly string _message = "Message content is empty.";

    public EmptyMessageException(Person sender, Person receiver)
    {
        Sender = sender;
        Receiver = receiver;
    }

    public override string Message => _message;

    public void PrintDetails()
    {
        Console.WriteLine($"Empty message attempted from {Sender.Name} to {Receiver.Name}");
    }
}