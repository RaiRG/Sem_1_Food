using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Database;
using Test.Database.Connections;

namespace Test.Pages
{
    public class Kitchen : PageModel
    {
        private int clientId;
        private BookmarkDao bookmarkDao = new BookmarkDao();
        private DishDAO dishDao = new DishDAO();
        public Dish[] Dishes;

        private Dish_ClientDao dishClientDao = new Dish_ClientDao();

        public void OnGet(string viewOfPage)
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

            int[] allDishesId = GetIdFromNeededTable(viewOfPage);
            Dishes = new Dish[allDishesId.Length];
            for (var i = 0; i < allDishesId.Length; i++)
            {
                Dishes[i] = dishDao.GetOneById(allDishesId[i]);
            }
        }

        private int[] GetIdFromNeededTable(string viewOfPage)
        {
            if (viewOfPage == "Bookmarks")
            {
                return bookmarkDao.ConnectBookmarkDishClientId
                    .Where(x => x.SecondId == clientId)
                    .Select(s => s.FirstId)
                    .ToArray();
            }
            if (viewOfPage == "MyDishes")
            {
                return dishClientDao.ConnectDishClient.Where(x => x.SecondId == clientId).Select(s => s.FirstId)
                    .ToArray();
            }

            return new int[] {0};
        }
    }
}