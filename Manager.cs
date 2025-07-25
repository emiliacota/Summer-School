using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Manager
{
    private List<Message> messages = new List<Message>();

    public void LoadMessagesFromFile(string filePath)
    {
        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(new string[] { "##" }, StringSplitOptions.None);
            if (parts.Length != 5) continue;

            var date = DateTime.Parse(parts[0]);
            var sender = ParsePerson(parts[1]);
            var receiver = ParsePerson(parts[2]);
            var content = parts[3];
            var isSeen = bool.Parse(parts[4]);

            try
            {
                SendMessage(sender, receiver, content, date, isSeen);
            }
            catch (EmptyMessageException ex)
            {
            }
        }
    }

    private Person ParsePerson(string data)
    {
        var name = data.Substring(0, data.IndexOf('('));
        var inner = data.Substring(data.IndexOf('(') + 1, data.IndexOf(')') - data.IndexOf('(') - 1);
        var fields = inner.Split(',');

        int id = int.Parse(fields[0]);
        string email = fields[1];
        int? age = fields.Length > 2 && !string.IsNullOrEmpty(fields[2]) ? (int?)int.Parse(fields[2]) : null;

        return new Person(name.Trim(), id, email.Trim(), age);
    }

    public void SendMessage(Person sender, Person receiver, string content, DateTime date, bool isSeen = false)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            var ex = new EmptyMessageException(sender, receiver);
            ex.PrintDetails();
            throw ex;
        }
        messages.Add(new Message(sender, receiver, content, date, isSeen));
    }

    public List<Person> GetAllPersons() =>
        messages.SelectMany(m => new[] { m.Sender, m.Receiver }).Distinct().ToList();

    public int CountMessagesBetween(Person p1, Person p2) =>
        messages.Count(m => (m.Sender.Equals(p1) && m.Receiver.Equals(p2)) ||
                           (m.Sender.Equals(p2) && m.Receiver.Equals(p1)));

    public List<Message> GetMessagesBetween(Person p1, Person p2) =>
        messages.Where(m => (m.Sender.Equals(p1) && m.Receiver.Equals(p2)) ||
                           (m.Sender.Equals(p2) && m.Receiver.Equals(p1)))
                .OrderBy(m => m.Date).ToList();

    public List<Message> GetMessagesByDate(DateTime date) =>
        messages.Where(m => m.Date.Date == date.Date).OrderBy(m => m.Date).ToList();

    public List<Message> GetMessagesBySender(Person sender) =>
        messages.Where(m => m.Sender.Equals(sender)).OrderBy(m => m.Date).ToList();

    public List<Message> GetUnseenMessages() =>
        messages.Where(m => !m.IsSeen).ToList();

    public Message GetLastReceivedMessageWithFilter(Person receiver, string forbiddenWord)
    {
        var last = messages.Where(m => m.Receiver.Equals(receiver))
                          .OrderByDescending(m => m.Date)
                          .FirstOrDefault();
        if (last != null)
        {
            string filtered = last.Content.Replace(forbiddenWord, new string('*', forbiddenWord.Length));
            return new Message(last.Sender, last.Receiver, filtered, last.Date, last.IsSeen);
        }
        return null;
    }

    public void SaveConversationToFile(Person p1, Person p2, string filename)
    {
        var conversation = GetMessagesBetween(p1, p2);
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var message in conversation)
            {
                sw.WriteLine($"{message.Date}: {message.Sender.Name} -> {message.Receiver.Name}: {message.Content}");
            }
        }
    }

    public void PrintMessages(List<Message> messages)
    {
        messages.ForEach(message => Console.WriteLine(message));
        Console.WriteLine();
    }

    public void PrintPersons(List<Person> persons)
    {
        persons.ForEach(person =>
            Console.WriteLine($"{person.Name} (ID: {person.Id}, Email: {person.Email}" + (person.Age.HasValue ? $", Age: {person.Age}" : "") + ")")
        );
        Console.WriteLine();
    }

    public void PrintMessageCount(Person p1, Person p2, int count)
    {
        Console.WriteLine($"Messages between {p1.Name} and {p2.Name}: {count}");
        Console.WriteLine();
    }

    public void SaveMessagesToFile(List<Message> messages, string filename)
    {
        try
        {
            File.WriteAllLines(filename, messages.Select(m => m.ToString()));
            Console.WriteLine($"Messages saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }

    public void PrintFilteredMessage(Message message, string forbiddenWord)
    {
        if (message != null)
        {
            Console.WriteLine($"Last received message with '{forbiddenWord}' filtered:");
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine("No messages found.");
        }
        Console.WriteLine();
    }
}