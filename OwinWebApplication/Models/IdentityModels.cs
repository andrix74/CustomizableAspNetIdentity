using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace OwinWebApplication.Models {

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim> {
        [MaxLength(2)]
        public string Province { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim> {
        public ApplicationDbContext()
            : base("DefaultConnection") {
        }
    }

    public class CustomRole : IdentityRole<int, CustomUserRole> {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
    
    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }


    /*
    public class CustomUserStore : IUserStore<ApplicationUser, int> {
        #region IUserStore<ApplicationUser,int> Members

        public System.Threading.Tasks.Task CreateAsync(ApplicationUser user)
        {
 	        throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync(ApplicationUser user)
        {
 	        throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<ApplicationUser> FindByIdAsync(int userId)
        {
 	        throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<ApplicationUser> FindByNameAsync(string userName)
        {
 	        throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(ApplicationUser user)
        {
 	        throw new System.NotImplementedException();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
 	        throw new System.NotImplementedException();
        }

        #endregion
       
    }
    */
}