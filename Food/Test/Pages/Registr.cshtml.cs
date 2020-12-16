using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
        public string Repeat { get; set; }

        [BindProperty(SupportsGet = false)]
        public string Email { get; set; }

        public string Message { get; set; }

        private ClientDao ClientTable = new ClientDao();
        private PersonalInfoDao PersonalInfoTable = new PersonalInfoDao();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ValidateData())
            {
                var client = new Client()
                {
                    Id = ClientDao.ID,
                    Login = RegistrClient.Login,
                    Name = RegistrClient.Name,
                    Surname = RegistrClient.Surname
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

        private bool ValidateData()
        {
            if (PersonalInfoTable.AllEntities.Where(cl => cl.Mail == Email).ToArray().Length != 0)
            {
               Message = "Пользователь с такой почтой уже зарегистрирован!";
               return false;
            }

            if (Password == null || Password.Length < 8)
            {
                Message = "Пароль должен быть длиннее!";
                return false;
            }

            if (Password != Repeat)
            {
                Message = "Пароли не совпадают!";
                return false;
            }

            var reg =new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]+");
            if (!reg.IsMatch(Email))
            {
                Message = "Неверный формат почты!";
                return false;
            }

            var nameAndSurnamePattern = new Regex("[A-Za-zА-Яа-яЁё]+");
            if (!(nameAndSurnamePattern.IsMatch(RegistrClient.Name) || nameAndSurnamePattern.IsMatch(RegistrClient.Name)))
            {
                var y = nameAndSurnamePattern.IsMatch(RegistrClient.Surname);
                Message = "Неверный формат имени или фамилии! Используйте только русские буквы";
                return false;
            }

            return true;
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