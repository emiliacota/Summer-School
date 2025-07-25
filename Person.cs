public class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }

    public Person(string name, int id, string email, int? age = null)
    {
        Name = name;
        Id = id;
        Email = email;
        Age = age;
    }

    public override bool Equals(object obj)
    {
        return obj is Person person && Id == person.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}