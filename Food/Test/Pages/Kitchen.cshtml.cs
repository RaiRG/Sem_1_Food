using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Connections;
using Test.Database;
using Test.Database.Connections;

namespace Test.Pages
{
    public class Kitchen : PageModel
    {
        private BookmarkDao bookmarkDao = new BookmarkDao();
        private DishDao dishDao = new DishDao();
        private Dish_KitchenDao dishKitchenDao = new Dish_KitchenDao();
        public Dish[] Dishes;

        private Dish_ClientDao dishClientDao = new Dish_ClientDao();
        private Dish_ProductDao dishProductDao = new Dish_ProductDao();
        private ProductDao productDao = new ProductDao();
        private ClientDao clientDao = new ClientDao();

        public void OnGet(string viewOfPage, int kitchen_id)
        {
            int[] allDishesId = GetIdFromNeededTable(viewOfPage, kitchen_id);
            Dishes = new Dish[allDishesId.Length];
            for (var i = 0; i < allDishesId.Length; i++)
            {
                Dishes[i] = dishDao.GetOneById(allDishesId[i]);
            }
        }

        private int[] GetIdFromNeededTable(string viewOfPage, int kitchen_id)
        {
            if (viewOfPage != null)
            {
                int clientId = -1;
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
            }

            return dishKitchenDao.ConnectDishKitchen.Where(x => x.SecondId == kitchen_id)
                .Select(x => x.FirstId).ToArray();
        }
    }
}