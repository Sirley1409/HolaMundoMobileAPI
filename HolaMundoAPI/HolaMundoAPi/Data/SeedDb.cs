namespace HolaMundoAPi.Data
{
    public class SeedDb
    {
        private readonly HolaMundoDbContext context;
        private readonly Random random;

        public SeedDb(HolaMundoDbContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Clients.Any())
            {
                this.AddUser("First Client");
                this.AddUser("Second Client");
                this.AddUser("Third Client");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddUser(string name)
        {
            this.context.Clients.Add(new Models.Client
            {
                Name = name,
                Dna = this.random.Next(1000000, 1999999).ToString()
            });
        }

    }

}
