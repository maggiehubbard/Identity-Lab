using IdentityLab.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityLab.Controllers
{
    public class HomeController : Controller
    {

        [Authorize]
        public ActionResult Cart()
        {            
            return View();
        }

        [Authorize]
        public ActionResult CartAdd(int id)
        {
            ViewBag.Cart = DAOclass.AddItemToCartList(id);

            return View("Cart");
        }

        [Authorize]
        public ActionResult CartDelete(int id)
        {
            ViewBag.Cart = DAOclass.DeleteItemFromCartList(id);
            return View("Cart");
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Products()
        {
            ViewBag.ProductList = DAOclass.GenerateProductList();
            return View();
        }

        public ActionResult Search(string term)
        {
            ViewBag.ProductList = DAOclass.SearchProductList(term);
            return View("Products");
        }

    }
}