using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var manager = new Manager();
        string filePath = "Messages.txt";

        try
        {
            manager.LoadMessagesFromFile(filePath);
            Console.WriteLine($"Messages loaded successfully from {filePath}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading messages: {ex.Message}");
            return;
        }

        Console.WriteLine("UNIQUE PERSONS: ");
        var allPersons = manager.GetAllPersons();
        manager.PrintPersons(allPersons);

        if (allPersons.Count >= 2)
        {
            var person1 = allPersons.First();
            var person2 = allPersons.Skip(1).First();
            Console.WriteLine("MESSAGE COUNT BETWEEN TWO PERSONS: ");
            int messageCount = manager.CountMessagesBetween(person1, person2);
            manager.PrintMessageCount(person1, person2, messageCount);
        }

        if (allPersons.Count >= 2)
        {
            var person1 = allPersons.First();
            var person2 = allPersons.Skip(1).First();
            Console.WriteLine($"MESSAGES BETWEEN {person1.Name.ToUpper()} AND {person2.Name.ToUpper()}: ");
            var messagesBetween = manager.GetMessagesBetween(person1, person2);
            manager.PrintMessages(messagesBetween);
        }

        var selectedDate = new DateTime(2024, 6, 10);
        Console.WriteLine($"MESSAGES ON {selectedDate.ToShortDateString()}: ");
        var messagesByDate = manager.GetMessagesByDate(selectedDate);
        manager.PrintMessages(messagesByDate);

        if (allPersons.Any())
        {
            var selectedSender = allPersons.First();
            Console.WriteLine($"MESSAGES FROM {selectedSender.Name.ToUpper()}: ");
            var messagesBySender = manager.GetMessagesBySender(selectedSender);
            manager.PrintMessages(messagesBySender);
        }

        if (allPersons.Count >= 2)
        {
            var person1 = allPersons.First();
            var person2 = allPersons.Skip(1).First();
            string conversationFile = $"conversation_{person1.Name}_{person2.Name}.txt";
            manager.SaveConversationToFile(person1, person2, conversationFile);
            Console.WriteLine($"Conversation saved to {conversationFile}\n");
        }

        Console.WriteLine("UNSEEN MESSAGES: ");
        var unseenMessages = manager.GetUnseenMessages();
        manager.PrintMessages(unseenMessages);

        if (allPersons.Any())
        {
            var receiver = allPersons.Skip(1).FirstOrDefault() ?? allPersons.First();
            string forbiddenWord = "report";
            Console.WriteLine($"LAST MESSAGE FOR {receiver.Name.ToUpper()} WITH '{forbiddenWord.ToUpper()}' FILTERED: ");
            var filteredMessage = manager.GetLastReceivedMessageWithFilter(receiver, forbiddenWord);
            manager.PrintFilteredMessage(filteredMessage, forbiddenWord);
        }

        Console.WriteLine("TESTING EMPTY MESSAGE EXCEPTION");
        try
        {
            if (allPersons.Count >= 2)
            {
                manager.SendMessage(allPersons[0], allPersons[1], "", DateTime.Now);
            }
        }
        catch (EmptyMessageException ex)
        {
            Console.WriteLine("Empty message exception was handled properly.");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}