using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

using var context = new FootballLeagueDbContext();

GetAllTeams();
QuerySingleRecords();
FilterMultipleRecords();
SearchWithWildCard();
AggregateFunctions();
GroupByItems();
OrderByItems();
SelectAndProjections();
InsertARecord();
InsertBulkRecords();
UpdateRecord();
DeleteRecord();

async Task DeleteRecord()
{
    var coach = context.Coaches.First(q => q.Id == 4);

    context.Remove(coach);

    await context.SaveChangesAsync();
}

async Task UpdateRecord()
{
    var coach = context.Coaches.First(q => q.Id == 2);

    coach.Name = "Rahul Dravid";

    await context.SaveChangesAsync();
}

async Task InsertBulkRecords()
{
    var coachGary = new Coach()
    {
        Name = "Gary Kirsten",
        CreatedDate = DateTime.Now
    };

    var coachGautam = new Coach()
    {
        Name = "Gautam Gambhir",
        CreatedDate = DateTime.Now
    };

    var CoachesToBeAdded = new List<Coach> { coachGary, coachGautam };

    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    await context.Coaches.AddRangeAsync(CoachesToBeAdded);
    await context.SaveChangesAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}

async Task InsertARecord()
{
    var coachDhoni = new Coach()
    {
        Name = "MS Dhoni",
        CreatedDate = DateTime.Now
    };

    await context.Coaches.AddAsync(coachDhoni);
    
    await context.SaveChangesAsync();

    Console.WriteLine($"Dhoni added at: {coachDhoni.Id}");
}

async Task SelectAndProjections()
{
    var teams = await context.Teams
        .Select(q => q.Name)
        .ToListAsync();

    foreach (var name in teams)
    {
        Console.WriteLine(name);
    }

    var teamsWithDate = await context.Teams
        .Select(q => new { q.Name, q.CreatedDate })
        .ToListAsync();

    foreach (var team in teamsWithDate)
    {
        Console.WriteLine($"{team.Name} - {team.CreatedDate}");
    }
}

void OrderByItems()
{
    var ascendingItems = context.Teams.OrderBy(q => q.Name);
    foreach (var team in ascendingItems)
    {
        Console.WriteLine(team.Name);
    }

    var descendingItems = context.Teams.OrderByDescending(q => q.Name);
    foreach (var team in descendingItems)
    {
        Console.WriteLine(team.Name);
    }
}

async Task GroupByItems()
{
    var groupedTeams = context.Teams.
        GroupBy(q => new { q.CreatedDate.Date, q.Name });

    foreach (var group in groupedTeams)
    {
        Console.WriteLine(group.Key);
        foreach (var team in group)
        {
            Console.WriteLine(team.Name);
        }
    }
}
async Task AggregateFunctions()
{
    var countAll = await context.Teams.CountAsync();
    Console.WriteLine(countAll);

    var countContainsL = await context.Teams.CountAsync(q => q.Name.Contains("l"));
    Console.WriteLine(countContainsL);

    var min = await context.Teams.MinAsync(q => q.TeamId);
    Console.WriteLine(min);

    var max = await context.Teams.MaxAsync(q => q.TeamId);
    Console.WriteLine(max);

    var avg = await context.Teams.AverageAsync(q => q.TeamId);
    Console.WriteLine(avg);

    var sum = await context.Teams.SumAsync(q => q.TeamId);
    Console.WriteLine(sum);
}

async Task GetAllTeams()
{
    var teams = await context.Teams.ToListAsync();

    foreach (var team in teams)
    {
        Console.WriteLine(team.Name);
    }
}

void QuerySingleRecords()
{
    var teamFirst = context.Teams.First();
    Console.WriteLine(teamFirst.Name);

    var teamSecond = context.Teams.First(q => q.TeamId == 2);
    Console.WriteLine(teamSecond.Name);

    var teamThird = context.Teams.FirstOrDefault(q => q.TeamId == 8);

    var teamFourth = context.Teams.Find(3);
    Console.WriteLine(teamFourth.Name);

    var teamFifth = context.Teams.Single(q => q.Name == "India");
    Console.WriteLine(teamFifth.TeamId);
}

async Task FilterMultipleRecords()
{
    var teams = await context.Teams.Where(q => q.TeamId < 3).ToListAsync();
    foreach (var team in teams)
    {
        Console.WriteLine(team.Name);
    }
}

async Task SearchWithWildCard()
{
    var teams = await context.Teams.Where(q => EF.Functions.Like(q.Name, $"%{"l"}")).ToListAsync(); //Ends with l
    foreach (var team in teams)
    {
        Console.WriteLine(team.Name);
    }
}