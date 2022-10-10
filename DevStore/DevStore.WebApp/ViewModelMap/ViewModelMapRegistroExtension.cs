using DevStore.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace DevStore.WebApp.ViewModelMap
{
    public static class ViewModelMapRegistroExtension
    {
        public static IdentityUser<int> ToDomain(this RegistroViewModel from)
        {
            // TODO: incluir no BD o campo NOME dos usuários ao registrá-lo
            var to = new IdentityUser<int>
            {
                UserName = from.Email,
                Email = from.Email
            };

            return to;
        }
    }
}
