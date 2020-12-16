using System;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Database;

namespace Test.Pages
{
    public class Forum : PageModel
    {
        public ForumItem[] AllForumItems;
        public ForumItem[] ClientForumItems;
        public ForumItem[] OthersForumItem;
        public Client[] Clients;
        public static bool isFirstLoading = true;
        private ForumDao forumDao;
        private ClientDao clientDao;
        public bool IsCanShowContent = false;

        public void OnGet()
        {
            var currentClientId = 0;
            if (HttpContext.Session.Keys.Contains("auth"))
            {
                IsCanShowContent = true;
                currentClientId = int.Parse(HttpContext.Session.GetString("auth"));
            }
            else if (HttpContext.Request.Cookies.ContainsKey("auth"))
            {
                IsCanShowContent = true;
                currentClientId = int.Parse(HttpContext.Request.Cookies["auth"]);
                HttpContext.Session.SetString("auth", currentClientId.ToString());
            }
            else
            {
                IsCanShowContent = false;
                Response.Redirect("Login");
                return;
            }

            if (IsCanShowContent)
            {
                forumDao = new ForumDao();
                clientDao = new ClientDao();
                AllForumItems = forumDao.AllEntities.OrderBy(x => x.SendDate).ToArray();
                Clients = new Client[AllForumItems.Length];
                ClientForumItems = forumDao.AllEntities.Where(x => x.ClientId == currentClientId).ToArray();
                OthersForumItem = forumDao.AllEntities.Where(x => x.ClientId != currentClientId).ToArray();
                for (int i = 0; i < AllForumItems.Length; i++)
                {
                    Clients[i] = clientDao.GetOneById(AllForumItems[i].ClientId);
                }
            }

        }

        public void OnGetSend()
        {
            var currentClientId = 0;
            if (HttpContext.Session.Keys.Contains("auth"))
            {
                currentClientId = int.Parse(HttpContext.Session.GetString("auth"));
            }
            else if (HttpContext.Request.Cookies.ContainsKey("auth"))
            {
                currentClientId = int.Parse(HttpContext.Request.Cookies["auth"]);
                HttpContext.Session.SetString("auth", currentClientId.ToString());
            }
            else
            {
                Response.Redirect("Login");
            }

            var mes = HttpUtility.UrlDecode(HttpContext.Request.Headers["message"]);
            var today = DateTime.Now;
            var current = new ForumItem()
            {
                Message = mes,
                ClientId = currentClientId,
                SendDate = today
            };
            forumDao = new ForumDao();
            forumDao.Insert(current);
        }

    }
}