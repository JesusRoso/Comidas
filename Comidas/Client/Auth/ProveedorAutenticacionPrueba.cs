using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Comidas.Client.Auth
{
	public class ProveedorAutenticacionPrueba : AuthenticationStateProvider
	{
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()//con este método se verifica la identidad del usuario
		{
			var anonimo = new ClaimsIdentity(new List<Claim>() //los Claim son un conjunto de informaciones acerca de un usuario, dado en clave-valor 
            {
				new Claim(ClaimTypes.Role,"admin"),
				new Claim(ClaimTypes.Name,"Jesus")
            },"prueba");
			return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimo)));
		}
	}
}
