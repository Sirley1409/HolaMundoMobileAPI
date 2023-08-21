using HolaMundoAPi.Data.Models;
using HolaMundoAPi.Enumerations;

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
            if (!this.context.UserRoles.Any())
            {
                this.AddUserRole("Administrator", RoleType.SuperAdmin);
                this.AddUserRole("Staff", RoleType.Staff);
                this.AddUserRole("Guest", RoleType.Guest);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Users.Any())
            {
                this.AddUser("AdminUser", "123", 1);
                this.AddUser("StaffUser", "123", 2);
                this.AddUser("GuestUser", "123", 3);
                await this.context.SaveChangesAsync();
            }
            if (!this.context.ClasificacionGastos.Any())
            {
                this.AddClasificacionGastos(GastosTipo.Transporte, "Tiquetes");
                this.AddClasificacionGastos(GastosTipo.Hospedaje,"Hospedaje");
                this.AddClasificacionGastos(GastosTipo.Alimentacion,"Alimentacion");
                await this.context.SaveChangesAsync();
            }
            if (!this.context.GastosViaje.Any())
            {
                this.AddGastosViaje(1,1,"Viaje");
                this.AddGastosViaje(2,2,"Noche de Hotel");
                this.AddGastosViaje(3,3,"Desayuno");
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
        private void AddUserRole(string roleName, RoleType roleType)
        {
            this.context.UserRoles.Add(new Models.UserRole
            {
                Name = roleName,
                Type = roleType
            });
        }

        private void AddUser(string userId, string password, long userRoleId)
        {
            this.context.Users.Add(new Models.User
            {
                UserName = userId,
                Password = password,
                RoleId = userRoleId
            });
        }
        private void AddClasificacionGastos(GastosTipo NombreGasto, string Name)
        {
            this.context.ClasificacionGastos.Add(new Models.ClasificacionGastos
            {
                NombreGasto = NombreGasto,
                Name = Name

            });
        }
        private void AddGastosViaje(long UserId,long ClasificacionGastosId, string ClasificacionGastosP)
        {
            this.context.GastosViaje.Add(new Models.GastosViaje
            {
                UserId = UserId,
                ClasificacionGastosId = ClasificacionGastosId,
                ClasificacionGastosV = ClasificacionGastosP,
                Fecha = DateTime.Now.AddDays(this.random.Next(1,30)),
                Valor = this.random.Next(1000,2000000),
                DetalleGasto = "Paseo"
                


            });
        }


    }

}
