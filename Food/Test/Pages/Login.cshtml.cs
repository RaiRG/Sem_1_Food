using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Pages
{
    public class Login : PageModel
    {
        // TODO: использовать Redirect на профиль
        [BindProperty]
        public string Mail { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public bool isRemember { get; set; }

        public string Message { get; set; }

        public bool isCorrectInputInfo = true;

        private PersonalInfoDao PersonalInfoTable = new PersonalInfoDao();

        public void OnGet()
        {
            if (HttpContext.Session.Keys.Contains("auth") || HttpContext.Request.Cookies.ContainsKey("auth"))
                Response.Redirect("Profile");
        }

        public void OnPost()
        {
            if (Mail == null || Password == null)
            {
                Message = "Пустое поле!";
            }

            if (PersonalInfoTable.AllEntities
                .Where(inf => inf.Mail == Mail && inf.HashPassword == GetHashString(Password))
                .ToArray().Length == 0)
            {
                Message = "Неверный логин или пароль!";
                isCorrectInputInfo = false;
            }
            else
            {
                var id = PersonalInfoTable.AllEntities
                    .Where(inf => inf.Mail == Mail && inf.HashPassword == GetHashString(Password)).ToArray()[0].Id;
                if (isRemember)
                {
                    HttpContext.Response.Cookies.Append("auth", id.ToString(),
                        new CookieOptions {Expires = DateTimeOffset.MaxValue});
                }
                HttpContext.Session.SetString("auth", id.ToString());
                Response.Redirect("Profile");
            }
        }

        string GetHashString(string password)
        {
            byte[] hash = Encoding.ASCII.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            var result = new StringBuilder();
            foreach (var b in hashenc)
            {
                result.Append(b.ToString("x2"));
            }

            return result.ToString();
        }
    }
}