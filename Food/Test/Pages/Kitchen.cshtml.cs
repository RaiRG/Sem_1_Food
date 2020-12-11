using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Pages
{
    public class Kitchen : PageModel
    {
        public Dish[] Dishes;
        public void OnGet()
        {
            //TODO: Если авторизован, иначе...
        }
    }
}