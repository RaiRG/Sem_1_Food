using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Connections;
using Test.Database;
using Test.Database.Connections;

namespace Test.Pages
{
    public class Add : PageModel
    {
        private int clientId;
        private int dishId;
        [BindProperty]
        public string AddName { get; set; }

        [BindProperty]
        public bool IsTat { get; set; }

        [BindProperty]
        public bool IsItal { get; set; }
        [BindProperty]
        public bool IsRus { get; set; }

        [BindProperty]
        public int AddPortion { get; set; }
        [BindProperty]
        public TimeSpan Time { get; set; }

        [BindProperty]
        public string Description { get; set; }

        private DishDAO dishDao = new DishDAO();
        private Dish_ClientDao dishClientDao = new Dish_ClientDao();
        private Dish_ProductDao dishProductDao = new Dish_ProductDao();
        private ProductDao productDao = new ProductDao();
        private Dish_KitchenDao dishKitchenDao = new Dish_KitchenDao();
        private StepDao stepDao = new StepDao();

        public void OnGet()
        {
            if (!(HttpContext.Session.Keys.Contains("auth") || HttpContext.Request.Cookies.ContainsKey("auth")))
            {
                Response.Redirect("Login");
            }
        }

        public void OnPost()
        {
            
            if (!(IsItal && IsRus && IsTat || IsItal && IsRus || IsRus && IsTat && IsItal && IsTat))
            {
                var today = DateTime.Now;
                var addDish = new Dish()
                {
                    Name = AddName,
                    Portions = AddPortion,
                    CreatingDate = today,
                    CookTime = Time,
                    CookingMethod = Description
                    //TODO: подумать с img
                };
                dishDao.Insert(addDish);
                if (HttpContext.Session.Keys.Contains("auth"))
                {
                    clientId = int.Parse(HttpContext.Session.GetString("auth"));
                }
                else
                {
                    clientId = int.Parse(HttpContext.Request.Cookies["auth"]);
                    HttpContext.Session.SetString("auth", clientId.ToString());
                }
                dishId = dishDao.AllEntities.Where(x => x.Name == AddName && x.Portions == AddPortion && x.CookingMethod ==Description && x.CookTime == Time && x.CreatingDate == today).Select(x => x.Id).ToArray()[0];
                dishClientDao.Insert(dishId, clientId);
                var allProducts = new string[]
                {
                    Ingridient_0, Ingridient_1, Ingridient_2, Ingridient_3, Ingridient_4, Ingridient_5, Ingridient_6,
                    Ingridient_7, Ingridient_8, Ingridient_9
                };
                for (int i = 0; i < allProducts.Length; i++)
                {
                    if (allProducts[i] == null)
                        break;
                    var pr = new Product()
                    {
                        Name = allProducts[i]
                    };
                    productDao.Insert(pr);
                    var productId = productDao.AllEntities.Where(x => x.Name == pr.Name).Select(x => x.Id).ToArray()[0];
                    dishProductDao.Insert(dishId, productId);
                }

                if (IsItal)
                {
                    dishKitchenDao.Insert(dishId, -3);
                }
                else if (IsRus)
                {
                    dishKitchenDao.Insert(dishId, -2);
                }
                else
                {
                    dishKitchenDao.Insert(dishId, -1);
                }

                var allSteps = new string[]
                {
                    Description_0, Img_0,
                    Description_1, Img_1,
                    Description_2, Img_2,
                    Description_3, Img_3,
                    Description_4, Img_4
                };
                for (int i = 0; i < allSteps.Length/2; i=i+2)
                {
                    if (allSteps[i] == null)
                        break;
                    var step = new Step()
                    {
                        Description = allSteps[i],
                        DishID = dishId,
                        NumberOfStep = i / 2,
                        Img = allSteps[i + 1]
                    };
                    stepDao.Insert(step);
                }
            }
        }

        [BindProperty]
        public string Ingridient_0 { get; set; }
        [BindProperty]
        public string Ingridient_1 { get; set; }
        [BindProperty]
        public string Ingridient_2 { get; set; }
        [BindProperty]
        public string Ingridient_3 { get; set; }
        [BindProperty]
        public string Ingridient_4 { get; set; }
        [BindProperty]
        public string Ingridient_5 { get; set; }
        [BindProperty]
        public string Ingridient_6 { get; set; }
        [BindProperty]
        public string Ingridient_7 { get; set; }
        [BindProperty]
        public string Ingridient_8 { get; set; }
        [BindProperty]
        public string Ingridient_9 { get; set; }

        [BindProperty]
        public string Description_0 { get; set; }
        [BindProperty]
        public string Description_1 { get; set; }
        [BindProperty]
        public string Description_2 { get; set; }
        [BindProperty]
        public string Description_3 { get; set; }
        [BindProperty]
        public string Description_4 { get; set; }

        [BindProperty]
        public string Img_0 { get; set; }
        [BindProperty]
        public string Img_1 { get; set; }
        [BindProperty]
        public string Img_2 { get; set; }
        [BindProperty]
        public string Img_3 { get; set; }
        [BindProperty]
        public string Img_4 { get; set; }
    }
}