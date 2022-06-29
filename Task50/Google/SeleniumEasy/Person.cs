namespace Task50Pages.SeleniumEasy;

internal class Person
{
    internal string Name { get; private set; }
    internal string Position{ get; private set; }
    internal string Office { get; private set; }

    public Person(string name, string position, string office)
    {
        Name = name;
        Position = position;
        Office = office;
    }
}
