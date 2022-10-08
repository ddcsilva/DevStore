using DevStore.Data.Mapping;
using Microsoft.AspNetCore.Identity;

namespace DevStore.WebApp.Configuration
{
    public static class IdentityExtension
    {
        private static void SetupIdentityOptions(IdentityOptions options)
        {
            // Configuração de Senha
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Configuração de Lockout
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // Configuração de Usuário
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;

            // Configuração de SignIn
            options.SignIn.RequireConfirmedAccount = false;
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(SetupIdentityOptions)
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddErrorDescriber<ApplicationIdentityErrorDescriber>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Account/Login";
                options.LogoutPath = $"/Account/Logout";
                options.AccessDeniedPath = $"/Account/AccessDenied";
            });
        }
    }
}
