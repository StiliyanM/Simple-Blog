namespace MyBlog.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using MyBlog.Models;

    public static class ApplicationBuilderExtensions
    {
        private const string DefaultAdminPassword = "admin123";

        private static readonly IdentityRole adminRole = new IdentityRole(WebConstants.AdministratorRole);

        public static async void SeedDatabase(this IApplicationBuilder app)
        {
            var serviceFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = serviceFactory.CreateScope();
            using (scope)
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                    if (!await roleManager.RoleExistsAsync(adminRole.Name))
                    {
                        await roleManager.CreateAsync(adminRole);
                    }

                var user = await userManager.FindByNameAsync("admin");
                if (user == null)
                {
                    user = new User()
                    {
                        UserName = "admin",
                        Email = "admin@example.com"
                    };

                    await userManager.CreateAsync(user, DefaultAdminPassword);
                    await userManager.AddToRoleAsync(user, adminRole.Name);
                }
            }
        }
    }
}
