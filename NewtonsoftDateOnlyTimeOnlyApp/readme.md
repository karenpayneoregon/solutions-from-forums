# About

Code samples for Json.net which as of version 13.0.2 now supports [DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly?view=net-7.0) and [TimeOnly](https://learn.microsoft.com/en-us/dotnet/api/system.timeonly?view=net-7.0).


**json**

```json
[
  {
    "Id": 1,
    "FirstName": "Karen",
    "LastName": "Payne",
    "StartDate": "2022-12-01",
    "StartTime": "14:15:00"
  },
  {
    "Id": 2,
    "FirstName": "May",
    "LastName": "Gallagher",
    "StartDate": "2022-12-11",
    "StartTime": "16:00:00"
  }
]
```

**Model**

```csharp
public class Container
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly StartDate { get; set; }
    public TimeOnly StartTime { get; set; }
}
```

**Mocked data**

```csharp
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
```

Get mocked data

```csharp
var containers = Mocked.Container();
```

Serialize data

```csharp
string json = JsonConvert.SerializeObject(containers, Formatting.Indented);
```

Deserialize data

```csharp
var readContainers = JsonConvert.DeserializeObject<List<Container>>(json);
```


![Screenshot](assets/screenshot.png)

