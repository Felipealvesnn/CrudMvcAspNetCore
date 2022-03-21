using MacorattiMVC.Domain.Contas;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MacorratiMVC.Infra.data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<AplicacaoDoUsuario> _usermanager;
        private readonly SignInManager<AplicacaoDoUsuario> _SignInmanager;

        public AuthenticateService(UserManager<AplicacaoDoUsuario> userManager, SignInManager<AplicacaoDoUsuario> signInManager)
        {
            _usermanager = userManager;
            _SignInmanager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _SignInmanager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var aplicacaodousuario = new AplicacaoDoUsuario
            {
                UserName = email,
                Email = email,
            };
            var result = await _usermanager.CreateAsync(aplicacaodousuario, password);
            if (result.Succeeded)
            {
                await _SignInmanager.SignInAsync(aplicacaodousuario, isPersistent: false);
            }
            return result.Succeeded;
        }

        public async Task logout()
        {
            await _SignInmanager.SignOutAsync();
        }
    }
}