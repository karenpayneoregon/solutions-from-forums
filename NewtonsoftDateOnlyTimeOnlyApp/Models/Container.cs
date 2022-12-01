
namespace NewtonsoftDateOnlyTimeOnlyApp.Models;

public class Container
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly StartDate { get; set; }
    public TimeOnly StartTime { get; set; }
}

public class Mocked
{
    public  static List<Container> Container() =>
        new()
        {
            new()
            {
                Id = 1, 
                FirstName = "Karen", 
                LastName = "Payne", 
                StartDate = new DateOnly(2022,12,1), 
                StartTime = new TimeOnly(14,15)
            },
            new()
            {
                Id = 2, 
                FirstName = "May", 
                LastName = "Gallagher", 
                StartDate = new DateOnly(2022,12,11), 
                StartTime = new TimeOnly(16,0)
            }
        };
}