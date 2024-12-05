using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using Server.Models.JoinTables;

namespace Server.Data
{
    public static class Seed
    {
        public static async Task SeedDataFromJsonAsync(DataContext context, string jsonFilePath)
        {
            // Ensure the database exists
            await context.Database.EnsureCreatedAsync();

            // Check if the database is already seeded
            if (context.Classes.Any() || context.People.Any() || context.ClassList.Any())
            {
                Console.WriteLine("Database already seeded.");
                return;
            }

            // Load JSON file
            var jsonData = await File.ReadAllTextAsync(jsonFilePath);
            var participants = JsonSerializer.Deserialize<ParticipantsData>(jsonData);

            if (participants == null)
            {
                Console.WriteLine("Invalid JSON data.");
                return;
            }

            // Seed Classes
            if (participants.Classes != null)
            {
                var classes = participants.Classes.Select(c => new Class
                {
                    ID = c.ID,
                    Name = c.Name,
                    Room = c.Room,
                    StartTime = DateTime.Parse(c.StartTime),
                    EndTime = DateTime.Parse(c.EndTime),
                    NoPeople = c.NoPeople
                }).ToList();

                await context.Classes.AddRangeAsync(classes);
                Console.WriteLine("Classes seeded.");
            }

            // Seed People
            if (participants.People != null)
            {
                var people = participants.People.Select(p => new Person
                {
                    ID = p.ID,
                    Name = p.Name,
                    Email = string.IsNullOrWhiteSpace(p.Email) ? $"{p.Name.Replace(" ", "").ToLower()}@example.com" : p.Email,
                    Present = false
                }).ToList();

                await context.People.AddRangeAsync(people);
                Console.WriteLine("People seeded.");
            }

            // Link People to Classes via ClassList
            if (participants.People != null)
            {
                foreach (var person in participants.People)
                {
                    if (person.Schedule != null)
                    {
                        foreach (var className in person.Schedule)
                        {
                            var dbClass = await context.Classes.FirstOrDefaultAsync(c => c.Name == className);
                            if (dbClass != null)
                            {
                                await context.ClassList.AddAsync(new ClassList
                                {
                                    PersonID = person.ID,
                                    ClassID = dbClass.ID
                                });
                                Console.WriteLine($"Linked {person.Name} to class {className}");
                            }
                        }
                    }
                }
            }

            // Save changes
            await context.SaveChangesAsync();
            Console.WriteLine("Database seeding complete.");
        }
    }

    public class ParticipantsData
    {
        public List<ClassInput> Classes { get; set; } = new List<ClassInput>();
        public List<PersonInput> People { get; set; } = new List<PersonInput>();
    }

    public class ClassInput
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int NoPeople { get; set; }
    }

    public class PersonInput
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Schedule { get; set; }
    }
}
