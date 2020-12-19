using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Database;
using Test.Database.Connections;

namespace Test.Pages
{
    public class Profile : PageModel
    {
        public Client Client;
        public PersonalInfo PersonalInfo;
        public int NumberOfDishes { get; set; }
        public int Rating { get; set; }
        public bool isCanShowContent { get; set; }

        private ClientDao clientTable = new ClientDao();
        private PersonalInfoDao personalInfoDao = new PersonalInfoDao();
        private Dish_ClientDao dishClientDao = new Dish_ClientDao();
        private BookmarkDao bookmarkDao = new BookmarkDao();
        public void OnGet()
        {
            string id;
            if (HttpContext.Session.Keys.Contains("auth"))
            {
                isCanShowContent = true;
                id = HttpContext.Session.GetString("auth");
                Client = clientTable.GetOneById(int.Parse(id));
                PersonalInfo = personalInfoDao.GetOneById(int.Parse(id));
                var dishesId = dishClientDao.ConnectDishClient.Where(x => x.SecondId == Client.Id)
                    .Select(x => x.FirstId);
                NumberOfDishes = dishesId.Count();
                Rating = bookmarkDao.ConnectBookmarkDishClientId.Where(x => dishesId.Contains(x.FirstId)).Count();
            }
            else if (HttpContext.Request.Cookies.ContainsKey("auth"))
            {
                isCanShowContent = true;
                id = HttpContext.Request.Cookies["auth"];
                HttpContext.Session.SetString("auth", id);
                Client = clientTable.GetOneById(int.Parse(id));
                PersonalInfo = personalInfoDao.GetOneById(int.Parse(id));
                var dishesId = dishClientDao.ConnectDishClient.Where(x => x.SecondId == Client.Id)
                    .Select(x => x.FirstId);
                NumberOfDishes = dishesId.Count();
                Rating = bookmarkDao.ConnectBookmarkDishClientId.Where(x => dishesId.Contains(x.FirstId)).Count();
            }
            else
            {
                isCanShowContent = false;
                Response.Redirect("Login");
            }
        }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Surname { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Login { get; set; }

        public IFormFile InputFile { get; set; }

        public void OnPost(string viewOfSendData)
        {
            int currentClientId;
            if (HttpContext.Session.Keys.Contains("auth"))
            {
                currentClientId = int.Parse(HttpContext.Session.GetString("auth"));
            }
            else
            {
                currentClientId = int.Parse(HttpContext.Request.Cookies["auth"]);
                HttpContext.Session.SetString("auth", currentClientId.ToString());
            }

            if (viewOfSendData == "info")
            {
                clientTable.Update(currentClientId, Name, Surname, Login);
                personalInfoDao.Update(currentClientId, Email);
                
            }
            else if (viewOfSendData == "changePhoto")
            {
                var currentImg = clientTable.GetOneById(currentClientId).Img;
                if (currentImg != FileHandler.DefaultProfileImg)
                {
                    var currentImgLocation = FileHandler.WebRoot + "/" + currentImg;
                    System.IO.File.Delete(currentImgLocation);
                }
                var newPath = FileHandler.SaveFileAndGetPath(InputFile, "/img/profilePhotos/");
                clientTable.Update(currentClientId, newPath);
            }
            OnGet();
            Response.Redirect("Profile");
        }
    }
}