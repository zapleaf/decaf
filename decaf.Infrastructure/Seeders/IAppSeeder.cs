namespace decaf.Infrastructure.Seeders;

// Made public so it can be called from Program.cs in Presentation layer
public interface IAppSeeder
{
    Task Seed();
}
