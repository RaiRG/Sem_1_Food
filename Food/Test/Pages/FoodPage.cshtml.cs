using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Database;
using Test.Database.Connections;

namespace Test.Pages
{
    public class FoodPage : PageModel
    {
        public Dish Dish;
        public string ClientName;
        public int DishId;
        public Product[] Products;
        public int[] Weights;
        public Step[] Steps;
        public Review[] Reviews;
        public Client[] AuthorsOfReview;
        
        
        //Tables:
        private DishDAO dishTable = new DishDAO();
        private Dish_ClientDao dishClientTable = new Dish_ClientDao();
        private ClientDao clientTable = new ClientDao();
        private Dish_ProductDao dishProductTable = new Dish_ProductDao();
        private ProductDao productTable = new ProductDao();
        private StepDao stepTable = new StepDao();
        private ReviewDao reviewTable = new ReviewDao();
        
        public void OnGet(int id)
        {
            DishId = id;
            Dish = dishTable.GetOneById(id);
            var clientId = dishClientTable.GetIdOfSecondByFirst(id);
            ClientName = clientTable.DictionaryOfEntities[clientId].Name;
            Steps =  stepTable.AllEntities.Where(x => x.DishID == DishId).ToArray();
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
                Weights[i] = dishProductTable.GetWeight(DishId, Products[i].Id);
            }
        }

        [BindProperty] 
        public string Description { get; set; }
        public void OnPost()
        {
            //TODO:Сессия и куки
        }
    }
}