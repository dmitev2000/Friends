using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class FriendController : Controller
    {
        private static List<FriendModel> friends = new List<FriendModel>()
        {
            new FriendModel { Id = 1, Ime = "TestIme1", MestoZiveenje = "TestMesto1"},
            new FriendModel { Id = 2, Ime = "TestIme2", MestoZiveenje = "TestMesto2"},
            new FriendModel { Id = 3, Ime = "TestIme3", MestoZiveenje = "TestMesto3"}
        };

        public ActionResult Index()
        {
            var friendsList = friends.ToList();
            return View(friendsList);
        }

        [HttpGet]
        public ActionResult AddFriend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFriend(FriendModel friend)
        {
            if (!ModelState.IsValid)
            {
                return View("AddFriend", friend);
            }
            friends.Add(friend);
            return View("Index", friends);
        }

        [HttpGet]
        public ActionResult EditFriend(byte Id)
        {
            FriendModel friend = friends.Single(f => f.Id == Id);
            return View(friend);
        }

        [HttpPost]
        public ActionResult EditFriend(FriendModel friend)
        {
            if (!ModelState.IsValid)
            {
                return View("EditFriend", friend);
            }
            for (int i = 0; i < friends.Count; i++)
            {
                if (friend.Id == friends[i].Id)
                {
                    friends[i] = friend;
                }
            }
            return View("Index", friends);
        }

        public ActionResult DeleteFriend(byte Id)
        {
            FriendModel toRemove = friends.Single(friend => friend.Id == Id);
            if (toRemove != null)
            {
                friends.Remove(toRemove);
            }
            return View("Index", friends);
        }
    }
}