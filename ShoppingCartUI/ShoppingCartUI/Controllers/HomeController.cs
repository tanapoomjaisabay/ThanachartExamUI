using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCartUI.Models;
using ShoppingCartUI.Services;
using ShoppingCartUI.Services.Interfaces;

namespace ShoppingCartUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _service;

        public HomeController(IProductService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        //[HttpPost]
        //public string GetListProductx([FromBody] RequestModel model)
        //{
        //    ResultGetListProductModel data = new ResultGetListProductModel
        //    {
        //        listProduct = new List<ProductModel>
        //        {
        //            new ProductModel { idKey = 1, productCode = "10001", productDesc = "test01", price = 10000, quantity = 10, createBy = "AAA", updateBy = "AAA", createDatetime = DateTime.Now, updateDatetime = DateTime.Now },
        //            new ProductModel { idKey = 1, productCode = "10002", productDesc = "test02", price = 25000, quantity = 10, createBy = "AAA", updateBy = "AAA", createDatetime = DateTime.Now, updateDatetime = DateTime.Now },
        //        }
        //    };

        //    ResponseGetListProductModel response = new ResponseGetListProductModel
        //    {
        //        status = 200,
        //        success = true,
        //        data = data
        //    };

        //    return JsonConvert.SerializeObject(response);
        //}

        [HttpPost]
        public string GetListProduct([FromBody] RequestModel model)
        {
            model.transactionDate = DateTime.Now;
            var response = _service.GetListProduct();
            return JsonConvert.SerializeObject(response);
        }

        [HttpPost]
        public string CreateTransaction([FromBody] RequestTransactionModel model)
        {
            model.transactionDate = DateTime.Now;
            var response = _service.CreateTransaction(model);
            return JsonConvert.SerializeObject(response);
        }
    }
}
