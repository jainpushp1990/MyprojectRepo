using Design_Calculator_New.Entity;
using Design_Calculator_New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Design_Calculator_New.Controllers
{
    public class HomeController : Controller
    {
        SimpleDBEntities Dbcontext = new SimpleDBEntities();
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            var iSUserExists = Dbcontext.Employees.Any(x => x.UserName == userModel.UserName && x.Password == userModel.Password);
            if (iSUserExists)
            {
                return RedirectToAction("Calculate");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Calculate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Calculate(GoldModel goldModel)
        {
            if (goldModel.Discount == 0)
            {
                int totalPrice = CalculateTotalPriceWithoutDiscount(goldModel.GoldPrice, goldModel.Weightitem);
                TempData["GoldPrice"] = goldModel.GoldPrice;
                TempData["Weightitem"] = goldModel.Weightitem;
                TempData["Discount"] = goldModel.Discount;
                TempData["totalPrice"] = totalPrice;
                return RedirectToAction("Calculate");
            }
            else
            {
                int totalPrice = CalculateTotalPricewithDiscount(goldModel.GoldPrice, goldModel.Weightitem, goldModel.Discount);
                TempData["GoldPrice"] = goldModel.GoldPrice;
                TempData["Weightitem"] = goldModel.Weightitem;
                TempData["Discount"] = goldModel.Discount;
                TempData["totalPrice"] = totalPrice;
                return RedirectToAction("Calculate");
            }
        }

        public static int CalculateTotalPriceWithoutDiscount(int Goldprice, int WeightoftheGold)
        {
            int totalPricewithoutDiscount = Goldprice * WeightoftheGold;
            return totalPricewithoutDiscount;
        }

        public static int CalculateTotalPricewithDiscount(int Goldprice, int WeightoftheGold, int discount)
        {
            int totalpr = Goldprice * WeightoftheGold;
            int Totaldiscount = totalpr * discount / 100;
            int totalPricewithDiscount = totalpr - Totaldiscount;
            return totalPricewithDiscount;
        }
    }
}