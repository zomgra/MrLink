namespace MrLink.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(LinkDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
