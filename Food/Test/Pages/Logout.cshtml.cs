using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Pages
{
    public class Logout : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Clear();
            HttpContext.Response.Cookies.Delete("auth");
            Response.Redirect("Login");
        }
    }
}