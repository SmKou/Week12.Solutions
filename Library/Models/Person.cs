namespace Library.Models;

public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Searchable { get; set; }
    public DateTime DateOfBirth { get; set; }

    public int CountryId { get; set; }
    public Country Country { get; set; }
}