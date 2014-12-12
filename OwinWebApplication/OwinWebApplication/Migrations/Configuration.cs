namespace OwinWebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OwinWebApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OwinWebApplication.Models.ApplicationDbContext>
    {

        

        public Configuration() {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OwinWebApplication.Models.ApplicationDbContext context) {
            Initialize(context);
        }


        private void Initialize(OwinWebApplication.Models.ApplicationDbContext context) {
            /*
            context.Roles.AddOrUpdate(
                r => r.Name,
                new CustomRole { Id = 1, Name = "Admin" },
                new CustomRole { Id = 2, Name = "Utente" }
                );

            context.Users.AddOrUpdate(
                u => u.Id,
                new ApplicationUser {
                    Id = 1,
                    Provincia = "Reggio Emilia",
                    Citta = "Correggio",
                    Email = "aaa@bbb.it",
                    EmailConfirmed = true,
                    PasswordHash = "",
                    SecurityStamp = null,
                    PhoneNumber = "0000",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEndDateUtc = DateTime.Now,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = "andrea"
                });
            */

            var RoleManager = new RoleManager<CustomRole, int>(new RoleStore<CustomRole, int, CustomUserRole>(context));
            string roleName1 = "Admin";
            string roleName2 = "Utente";

            IdentityResult roleresult1;
            IdentityResult roleresult2;

            //Create role if it does not exist
            if (!RoleManager.RoleExists(roleName1))
                roleresult1 = RoleManager.Create(new CustomRole(roleName1));

            if (!RoleManager.RoleExists(roleName2))
                roleresult2 = RoleManager.Create(new CustomRole(roleName2));


            var UserManager = new UserManager<ApplicationUser, int>(new UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context));
            var utente = new ApplicationUser() { Id = 1, UserName = "andrea", Citta = "Correggio", Provincia = "Reggio Emilia", Email = "a@a.it", EmailConfirmed = true, PhoneNumberConfirmed = true };
            var result = UserManager.Create(utente, "andrea01");

            if(result.Succeeded)
                UserManager.AddToRole(utente.Id, roleName1);

        }


    }

}
