using GameShop.Controllers;

namespace GameShop.MiddleWare
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (UserController.IsActive == true)
            {
                await _next(context);
            }
            else { throw new Exception("Пользователь не автаризован"); };
        }
    }
}
