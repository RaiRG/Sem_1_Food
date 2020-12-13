using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Test.Database;

namespace Test.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public static int NumberInScrollItem = 18;
        public Dish[] top = new Dish[NumberInScrollItem];
        public Dish[] moreNew = new Dish[NumberInScrollItem];
        public Dish[] quick = new Dish[NumberInScrollItem];
        

        private DishDAO dishTable;
        private BookmarkDao bookmarkDao;

        public void OnGet()
        {
            dishTable = new DishDAO();
            bookmarkDao = new BookmarkDao();
            quick = dishTable.AllEntities.OrderByDescending(x => x.CookTime).Take(NumberInScrollItem).ToArray();
            moreNew = dishTable.AllEntities.OrderByDescending(x => x.CreatingDate).Take(NumberInScrollItem).ToArray();
            var topIds = bookmarkDao.ConnectBookmarkDishClientId
                .GroupBy(x => x.FirstId)
                .OrderByDescending(x => x.Count())
                .Take(NumberInScrollItem)
                .Select(x=> x.Key)
                .ToArray();
            for (var i = 0; i < topIds.Length; i++)
            {
                top[i] = dishTable.GetOneById(topIds[i]);
            }
        }

        public void OnPost()
        {
        }
    }
}