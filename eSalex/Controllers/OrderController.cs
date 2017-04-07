using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eSalex.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            //Models.OrderService orderService = new Models.OrderService();
            //var order = orderService.GetOrderById("111");
            //ViewBag.CustId = order.CustId;

            //ViewBag.test = "1";

            //Models.OrderService orderService = new Models.OrderService();
            //ViewBag.Data = orderService.GetOrders();

            List<SelectListItem> custData = new List<SelectListItem>();
            custData.Add(new SelectListItem()
            {
                Text = "叡揚資訊",
                Value = "1"
            });

            custData.Add(new SelectListItem()
            {
                Text = "網軟資訊",
                Value = "2"
            });

            ViewBag.custData = custData;

            return View(); 
        }
        public ActionResult Index2(string id)
        {
            ViewBag.id = id;
            return View();
        }
        /// <summary>
        /// 新增訂單的畫面
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertOrder()
        {
            Models.Order order = new Models.Order();
            order.CustName = "叡揚資訊";
            return View();
        }
        /// <summary>
        /// 新增訂單存檔的Action
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult InsertOrder(Models.Order order)
        {
            ViewBag.Desc1 = "我是ViewBag";
            ViewData["Desc2"] = "我是ViewData";
            TempData["Desc3"] = "我是 TempData";

            return RedirectToAction("Index");
        }
        [HttpGet()]
        public JsonResult TestJson()
        {
            
            var result = new Models.Order();
            result.CustId = "GSS";
            result.CustName = "叡揚資訊";
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index1()
        {
            eSaleService.OrderService orderService = new eSaleService.OrderService();
            var data = orderService.GetOrderById("1");
            ViewBag.data = data.CustId+"-"+data.CustName+"-"+data.OrderId;
            return View();
        }

    }
}