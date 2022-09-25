using ListaDeTarefasMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace ListaDeTarefasMVC.Filters
{
    public class PaginaUsuarioLogadoAdministrador : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
                else
                {
                    if (usuario.Perfil != Enums.PerfilUsuario.Administrador)
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "SemAcesso" } });
                    }
                }                               
            }

            base.OnActionExecuting(context);

        }


    }
}
