using System;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Hosting;
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
        private DishDao dishDao = new DishDao();
        private Dish_ClientDao dishClientDao = new Dish_ClientDao();
        private Dish_ProductDao dishProductDao = new Dish_ProductDao();
        private ProductDao productDao = new ProductDao();
        private Dish_KitchenDao dishKitchenDao = new Dish_KitchenDao();
        private StepDao stepDao = new StepDao();
        private ClientDao clientDao = new ClientDao();
        
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

        

        public void OnGet()
        {
            if (!(HttpContext.Session.Keys.Contains("auth") || HttpContext.Request.Cookies.ContainsKey("auth")))
            {
                Response.Redirect("Login");
            }
        }

      public void OnPost()
        {
            if (IsItal || IsRus || IsTat)
            {
                //СОхраняем основное фото
                string pathToInputFile = "";
                if (InputFile != null)
                {
                    pathToInputFile = FileHandler.SaveFileAndGetPath(InputFile, "/img/food/");
                }

                // Добавляем к таблице блюд
                var today = DateTime.Now;
                var addDish = new Dish()
                {
                    Name = AddName,
                    Portions = AddPortion,
                    CreatingDate = today,
                    CookTime = Time,
                    CookingMethod = Description,
                    Img = pathToInputFile
                };
                dishDao.Insert(addDish);
                clientId = GetCLientId();
                dishId = addDish.Id;
                
                //Добавляю в связывающую таблицу
                dishClientDao.Insert(dishId, clientId);

                //Добавляют продукты
                AddProducts();
                AddKithen();
                //Добавляю шаги
                AddSteps();
            }
        }
        
        public void AddSteps()
        {
            //Добавляю шаги
            var allSteps = new (string, IFormFile)[]
            {
                (Description_0, Img_0),
                (Description_1, Img_1),
                (Description_2, Img_2),
                (Description_3, Img_3),
                (Description_4, Img_4)
            };
            for (int i = 0; i < allSteps.Length; i++)
            {
                if (allSteps[i].Item1 == null)
                    break;
                string path = "";
                //Сохраняем
                if (allSteps[i].Item2 != null)
                {
                    path = FileHandler.SaveFileAndGetPath(allSteps[i].Item2, "/img/steps/");
                }

                var step = new Step()
                {
                    Description = allSteps[i].Item1,
                    DishID = dishId,
                    NumberOfStep = i,
                    Img = path
                };
                stepDao.Insert(step);
            }
        }

        public void AddProducts()
        {
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
                int productId = 0;
                if (productDao.AllEntities.Where(x => x.Name == pr.Name).Select(x => x.Id).Count() != 0)
                {
                    productId =
                        productDao.AllEntities.Where(x => x.Name == pr.Name).Select(x => x.Id).ToArray()[0];
                }
                else
                {
                    productDao.Insert(pr);
                    productId = pr.Id;
                }
                dishProductDao.Insert(dishId, productId);
            }
        }
        
        public int GetCLientId()
        {
            var result = 0;
            if (HttpContext.Session.Keys.Contains("auth"))
            {
                result = int.Parse(HttpContext.Session.GetString("auth"));
            }
            else
            {
                result = int.Parse(HttpContext.Request.Cookies["auth"]);
                HttpContext.Session.SetString("auth", result.ToString());
            }

            return result;
        }

        public void AddKithen()
        {
            if (IsItal)
            {
                dishKitchenDao.Insert(dishId, -3);
            }
            if (IsRus)
            {
                dishKitchenDao.Insert(dishId, -2);
            }
            if (IsTat)
            {
                dishKitchenDao.Insert(dishId, -1);
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
        public IFormFile Img_0 { get; set; }
        [BindProperty]
        public IFormFile Img_1 { get; set; }
        [BindProperty]
        public IFormFile Img_2 { get; set; }
        [BindProperty]
        public IFormFile Img_3 { get; set; }
        [BindProperty]
        public IFormFile Img_4 { get; set; }
        [BindProperty]
        public IFormFile InputFile { get; set; }
    }
}