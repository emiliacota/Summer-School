using System;

public class Message
{
    public Person Sender { get; set; }
    public Person Receiver { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public bool IsSeen { get; set; }

    public Message(Person sender, Person receiver, string content, DateTime date, bool isSeen = false)
    {
        Sender = sender;
        Receiver = receiver;
        Content = content;
        Date = date;
        IsSeen = isSeen;
    }

    public override string ToString()
    {
        string seenStatus = IsSeen ? "Seen" : "Unseen";
        return $"{Date}: {Sender.Name} -> {Receiver.Name}: {Content} [{seenStatus}]";
    }
}