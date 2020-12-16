using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Database;

namespace Test.Pages
{
    public class AddToBookmarks : PageModel
    {
        private int clientId;
        private BookmarkDao bookmarkDao = new BookmarkDao();
        public void OnGet(int dishId)
        {
            if (!(HttpContext.Session.Keys.Contains("auth") || HttpContext.Request.Cookies.ContainsKey("auth")))
            {
                Response.Redirect("Login");
            }

            if (HttpContext.Session.Keys.Contains("auth"))
            {
                clientId = int.Parse(HttpContext.Session.GetString("auth"));
            }
            else if (HttpContext.Request.Cookies.ContainsKey("auth"))
            {
                clientId = int.Parse(HttpContext.Request.Cookies["auth"]);
                HttpContext.Session.SetString("auth", clientId.ToString());
            }
            bookmarkDao.Insert(dishId, clientId);
            Response.Redirect("/FoodPage?id=" + dishId);
        }
    }
}