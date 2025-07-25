using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblem
{
    internal class TXTreader
    {
        public static List<Message> ReadMessagesTXT(string path)
        {
            List<Message> messages = new List<Message>();

            try
            {
                foreach (var line in File.ReadLines(path))
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
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            messages.Add(new Message(sender, receiver, content, date, isSeen));
                        }
                        else
                        {
                            var ex = new EmptyMessageException(sender, receiver);
                            ex.PrintDetails();
                        }
                    }
                    catch (EmptyMessageException ex)
                    {
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return messages;
        }

        private static Person ParsePerson(string data)
        {
            var name = data.Substring(0, data.IndexOf('('));
            var inner = data.Substring(data.IndexOf('(') + 1, data.IndexOf(')') - data.IndexOf('(') - 1);
            var fields = inner.Split(',');

            int id = int.Parse(fields[0]);
            string email = fields[1];
            int? age = fields.Length > 2 && !string.IsNullOrEmpty(fields[2]) ? (int?)int.Parse(fields[2]) : null;

            return new Person(name.Trim(), id, email.Trim(), age);
        }
    }
}