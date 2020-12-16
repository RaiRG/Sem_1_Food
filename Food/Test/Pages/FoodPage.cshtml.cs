using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Database;
using Test.Database.Connections;

namespace Test.Pages
{
    public class FoodPage : PageModel
    {
        public Dish Dish { get; set; }

        public string ClientName { get; set; }

        public int DishId { get; set; }

        public Product[] Products { get; set; }

        public int[] Weights { get; set; }

        public Step[] Steps { get; set; }

        public Review[] Reviews { get; set; }

        public Client[] AuthorsOfReview { get; set; }

        public bool isAddedToBookmarks { get; set; }

        public bool isAddReviews { get; set; }

        public bool isAuthClient { get; set; }

        //Tables:
        private DishDao dishTable;
        private Dish_ClientDao dishClientTable;
        private ClientDao clientTable;
        private Dish_ProductDao dishProductTable;
        private ProductDao productTable;
        private StepDao stepTable;
        private ReviewDao reviewTable;
        private BookmarkDao bookmarkDao;

        public void OnGet(int id)
        {
            dishTable = new DishDao();
            dishClientTable = new Dish_ClientDao();
            clientTable = new ClientDao();
            dishProductTable = new Dish_ProductDao();
            productTable = new ProductDao();
            stepTable = new StepDao();
            reviewTable = new ReviewDao();
            bookmarkDao = new BookmarkDao();
            DishId = id;
            Dish = dishTable.GetOneById(id);
            var clientId = dishClientTable.ConnectDishClient.Where(x => x.FirstId == id).Select(x => x.SecondId)
                .ToArray()[0];
            ClientName = clientTable.DictionaryOfEntities[clientId].Name;
            Steps = stepTable.AllEntities.Where(x => x.DishID == DishId).ToArray();
            Reviews = reviewTable.AllEntities.Where(x => x.DishId == DishId).ToArray();
            AuthorsOfReview = new Client[Reviews.Length];
            for (var i = 0; i < Reviews.Length; i++)
            {
                AuthorsOfReview[i] = clientTable.GetOneById(Reviews[i].ClientID);
            }

            var productsId = dishProductTable.GetProductIdByDishesId(DishId);
            Products = new Product[productsId.Count];
            Weights = new int[productsId.Count];
            for (int i = 0; i < productsId.Count; i++)
            {
                Products[i] = productTable.GetOneById(productsId[i]);
            }

            var cuurentClientId = 0;
            if (!(HttpContext.Session.Keys.Contains("auth") || HttpContext.Request.Cookies.ContainsKey("auth")))
            {
                //Response.Redirect("Login");
                isAuthClient = false;
            }
            else
            {
                isAuthClient = true;
                if (HttpContext.Session.Keys.Contains("auth"))
                {
                    cuurentClientId = int.Parse(HttpContext.Session.GetString("auth"));
                }
                else if (HttpContext.Request.Cookies.ContainsKey("auth"))
                {
                    cuurentClientId = int.Parse(HttpContext.Request.Cookies["auth"]);
                    HttpContext.Session.SetString("auth", clientId.ToString());
                }

                isAddReviews = reviewTable.AllEntities.Where(x => x.ClientID == cuurentClientId).Count() != 0;
                isAddedToBookmarks =
                    bookmarkDao.ConnectBookmarkDishClientId.Where(x => x.FirstId == id && x.SecondId == cuurentClientId)
                        .Count() != 0;
                
            }
        }

        [BindProperty]
        public string Description { get; set; }

        public void OnPost(int id)
        {
            reviewTable = new ReviewDao();
           
            if (!(HttpContext.Session.Keys.Contains("auth") || HttpContext.Request.Cookies.ContainsKey("auth")))
            {
                isAddReviews = false;
                Response.Redirect("Login");
                OnGet(id);
            }
            else
            {
                var clientId = 0;
                if (HttpContext.Session.Keys.Contains("auth"))
                {
                    clientId = int.Parse(HttpContext.Session.GetString("auth"));
                }
                else if (HttpContext.Request.Cookies.ContainsKey("auth"))
                {
                    clientId = int.Parse(HttpContext.Request.Cookies["auth"]);
                    HttpContext.Session.SetString("auth", clientId.ToString());
                }

                var newReview = new Review()
                {
                    DishId = id,
                    ClientID = clientId,
                    Description = Description,
                    SendTime = DateTime.Now,
                };
                isAddReviews = true;
                reviewTable.Insert(newReview);
                OnGet(id);
                Response.Redirect("/FoodPage?id=" + id);
            }
        }
    }
}