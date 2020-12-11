using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Pages
{
    //TODO: После регистрации перекинуть на страницу "Вы успешно зарегистрированы"
    public class Registr : PageModel
    {
        [BindProperty]
        public Client RegistrClient { get; set; }

        [BindProperty(SupportsGet = false)]
        public string Password { get; set; }

        [BindProperty(SupportsGet = false)]
        public string Email { get; set; }

        public string Message { get; set; }

        private bool isNewMail = true;
        private bool isCorrectPassword = true;
        private ClientDao ClientTable;
        private PersonalInfoDao PersonalInfoTable;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ClientTable = new ClientDao();
            PersonalInfoTable = new PersonalInfoDao();
            if (PersonalInfoTable.AllEntities.Where(cl => cl.Mail == Email).ToArray().Length != 0)
            {
                isNewMail = false;
                Message = "Пользователь с такой почтой уже зарегистрирован!";
            }

            if (Password == null || Password.Length < 8)
            {
                isCorrectPassword = false;
                Message = "Пароль должен быть длиннее!";
            }

            if (isNewMail && isCorrectPassword)
            {
                var client = new Client()
                {
                    Id = ClientDao.ID,
                    Login = RegistrClient.Login,
                    Name = RegistrClient.Name,
                    Surname = RegistrClient.Surname,
                    NumberOfDishes = 0,
                    Rating = 0
                };
                ClientTable.Insert(client);
                var info = new PersonalInfo()
                {
                    Id = client.Id,
                    HashPassword = GetHashPassword(Password),
                    Mail = Email
                };
                PersonalInfoTable.Insert(info);
                Message = "Вы успешно зарегистрированы!";
            }
        }

        string GetHashPassword(string password)
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