using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Pages
{
    public class Profile : PageModel
    {
        public Client Client;
        public PersonalInfo PersonalInfo;

        private ClientDao clientTable;
        private PersonalInfoDao personalInfoDao;

        public void OnGet()
        {
            string id;
            clientTable= new ClientDao();
            personalInfoDao = new PersonalInfoDao();
            if (HttpContext.Session.Keys.Contains("auth"))
            {
                
                id = HttpContext.Session.GetString("auth");
                Client = clientTable.GetOneById(int.Parse(id));
                PersonalInfo = personalInfoDao.GetOneById(int.Parse(id));
            }
            else if (HttpContext.Request.Cookies.ContainsKey("auth"))
            {
                id = HttpContext.Request.Cookies["auth"];
                HttpContext.Session.SetString("auth", id);
                clientTable = new ClientDao();
                personalInfoDao = new PersonalInfoDao();
                Client = clientTable.GetOneById(int.Parse(id));
                PersonalInfo = personalInfoDao.GetOneById(int.Parse(id));
            }
            else
            {
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

        public void OnPost()
        {
            clientTable= new ClientDao();
            personalInfoDao = new PersonalInfoDao();
            int id;
            id = int.Parse(HttpContext.Session.GetString("auth"));
            clientTable.Update(id, Name, Surname, Login);
            personalInfoDao.Update(id, Email);
            OnGet();
            Response.Redirect("Profile");
        }
    }
}