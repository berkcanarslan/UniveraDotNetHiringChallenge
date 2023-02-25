// using ProductApp.ProductAppData.Context;
//
// namespace ProductApp.Middlewares;
//
// // Authentication middleware to check if user is logged in on each request
// public class AuthenticationMiddleware
// {
//     private readonly RequestDelegate _next;
//     private readonly ProductAppDbContext _context;
//     public AuthenticationMiddleware(RequestDelegate next,ProductAppDbContext context)
//     {
//         _next = next;
//         _context = context;
//     }
//
//     public async Task InvokeAsync(HttpContext context)
//     {
//         // Check if user is authenticated
//         var token = context.Session.GetString("AuthToken");
//         var user = _context.Users.SingleOrDefault(u => u.AuthToken == token);
//
//         if (user == null)
//         {
//             context.Response.Redirect("/Login");
//             return;
//         }
//
//         // Call the next middleware
//         await _next(context);
//     }
// }
