namespace FootGame.Domain.Entities;

public abstract class Person
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Guid NationalityId { get; private set; }

    protected Person(string name, DateTime birthDate, Guid nationalityId)
    {
        Id = Guid.NewGuid();
        Name = name;
        BirthDate = birthDate;
        NationalityId = nationalityId;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        if (name.Length > 20)
            throw new ArgumentException("Name cannot be longer than 20 characters.");

        Name = name;
    }

    public int GetAge(DateTime currentDate)
    {
        int age = currentDate.Year - BirthDate.Year;

        if (currentDate < BirthDate.AddYears(age))
        {
            age--;
        }

        return age;
    }
}