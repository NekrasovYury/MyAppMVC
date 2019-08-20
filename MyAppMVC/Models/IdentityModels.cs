using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyAppMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    
    public class Card
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public int NumberCard { get; set; }
        public int Money { get; set; }

        public ICollection<User> Users { get; set; }
        public Card()
        {
            Users = new List<User>();
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int MyProperty { get; set; }

        public int? CardId { get; set; }
        public Card Card { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    //public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //{
    //    protected override void Seed(ApplicationDbContext context)
    //    {
    //        var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

    //        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

    //        // создаем две роли
    //        var role1 = new IdentityRole { Name = "admin" };
    //        var role2 = new IdentityRole { Name = "user" };

    //        // добавляем роли в бд
    //        roleManager.Create(role1);
    //        roleManager.Create(role2);

    //        // создаем пользователей
    //        var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
    //        string password = "ad46D_ewr3";
    //        var result = userManager.Create(admin, password);

    //        // если создание пользователя прошло успешно
    //        if (result.Succeeded)
    //        {
    //            // добавляем для пользователя роль
    //            userManager.AddToRole(admin.Id, role1.Name);
    //            userManager.AddToRole(admin.Id, role2.Name);
    //        }

    //        base.Seed(context);
    //    }
    //}
}