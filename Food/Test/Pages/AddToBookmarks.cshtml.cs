using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Database;
using Test.Database.Connections;

namespace Test.Pages
{
    public class AddToBookmarks : PageModel
    {
        private int clientId;
        private BookmarkDao bookmarkDao = new BookmarkDao();
        private ClientDao clientDao = new ClientDao();
        private Dish_ClientDao dishClientDao = new Dish_ClientDao();
            
        public void OnGet(int dishId)
        {
            if (!(HttpContext.Session.Keys.Contains("auth") || HttpContext.Request.Cookies.ContainsKey("auth")))
            {
                Response.Redirect("Login");
            }

            clientId = GetClientId();
            bookmarkDao.Insert(dishId, clientId);
            //TODO:добавление рейтинга
            //AddRating(dishId);
            Response.Redirect("/FoodPage?id=" + dishId);
        }

        public int GetClientId()
        {
            var result = 0;
            if (HttpContext.Session.Keys.Contains("auth"))
            {
                result = int.Parse(HttpContext.Session.GetString("auth"));
            }
            else if (HttpContext.Request.Cookies.ContainsKey("auth"))
            {
                result = int.Parse(HttpContext.Request.Cookies["auth"]);
                HttpContext.Session.SetString("auth", result.ToString());
            }

            return result;

        }
        // public void AddRating(int dishId)
        // {
        //     var clientId = dishClientDao.ConnectDishClient.Where(x => x.FirstId == dishId).Select(x => x.SecondId)
        //         .First();
        //     clientDao.AddOneRatingById(this.clientId);
        // }
    }
}