﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Controllers
{
    public class ProductController : Controller
    {
        private webapistore1Context webapistoreContext;
        public ProductController(webapistore1Context webapistore)
        {
            webapistoreContext = webapistore;
        }
        // GET: ProductController
        [HttpGet]
        [Route("getlist/getl")]
        public async Task<ActionResult> Index()
        {
            var list = webapistoreContext.Products.ToList();
            var json = JsonConvert.SerializeObject(list);
            var stringContent = new StringContent(json,System.Text.Encoding.UTF8,"application/json");

            return Ok(json);
        }


        [HttpGet]
        [Route("getlist/getCustomer")]
        public async Task<ActionResult> CustomerList()
        {
            var list = webapistoreContext.Customer.ToList();
            var json = JsonConvert.SerializeObject(list);
            var stringContent = new StringContent(json,System.Text.Encoding.UTF8,"application/json");

            return Ok(json);
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
     
        [Route("Factor/Create")]
        public async Task<long> CreateFactor([FromBody]Factor factor)
        {
            long a= await webapistoreContext.Database.ExecuteSqlInterpolatedAsync($" exec CreateFactor  @F_customerID={factor.FCustomerId},@F_ProductID={factor.FProductId},@Quantity={factor.Quantity},@TotalPrice={factor.TotalPrice}");
            return a;
            //var sql = " declare @Id decimal (18,0) ;exec CreateFactor @F_customerID,@F_ProductID,@Quantity,@TotalPrice,@Id OUT";
            //long a = 0;
            //var result = webapistoreContext.Database.sqlra(sql, factor.FCustomerId, factor.FProductId,factor.Quantity,factor.TotalPrice, a);
            //return result;
        }




        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
