using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Database.Connections;

namespace Test.Pages
{
    public class FindingKithen : PageModel
    {
        public string FindKey;
        private int clientId;
      
        private DishDao dishDao = new DishDao();
        public Dish[] Dishes;

        private Dish_ClientDao dishClientDao = new Dish_ClientDao();
        private Dish_ProductDao dishProductDao = new Dish_ProductDao();
        private ProductDao productDao = new ProductDao();
        private ClientDao clientDao = new ClientDao();
        public void OnGet(string searchingString)
        {
            if (searchingString != "" && searchingString != null)
            {
                Find(searchingString);
            }
        }
        public void Find(string searchString)
        {
            var result = dishDao.AllEntities
                .Where(x => x.Name.Contains(searchString) || x.CookingMethod.Contains(searchString))
                .ToList();
            var productsWithSearchingString = productDao.AllEntities.Where(x => x.Name.Contains(searchString))
                .Select(x => x.Id).ToArray();
            var dishesIdByProducts = dishProductDao.ConnectDishProduct
                .Where(x => productsWithSearchingString.Contains(x.SecondId))
                .Select(x => x.FirstId);
            foreach (var idByProduct in dishesIdByProducts)
            {
                if (!result.Contains(dishDao.GetOneById(idByProduct)))
                {
                    result.Add(dishDao.GetOneById(idByProduct));
                }
            }

            var clientsWithSearchingString =
                clientDao.AllEntities.Where(x => x.Name.Contains(searchString)).Select(x => x.Id);
            var dishesIdByClients =
                dishClientDao.ConnectDishClient.Where(x => clientsWithSearchingString.Contains(x.SecondId))
                    .Select(x => x.FirstId);
            foreach (var idByClient in dishesIdByClients)
            {
                if (!result.Contains(dishDao.GetOneById(idByClient)))
                {
                    result.Add(dishDao.GetOneById(idByClient));
                }
            }
            Dishes = result.ToArray();
        }
    }
}