using Newtonsoft.Json;
using ShoppingCartUI.Models;
using ShoppingCartUI.Services.Interfaces;

namespace ShoppingCartUI.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly IConnectService _connectService;

        public ProductService(IConfiguration configuration, IConnectService connectService)
        {
            _configuration = configuration;
            _connectService = connectService;
        }

        public ResponseGetListProductModel GetListProduct()
        {
            string errorMessage = "Get list product failed. Please try again.";

            try
            {
                return GetListProductAPI();
            }
            catch (Exception ex)
            {
                return new ResponseGetListProductModel
                {
                    status = 500,
                    success = false,
                    message = errorMessage,
                    error = ex.Message
                };
            }
        }

        public ResponseGetListProductModel GetListProductAPI()
        {
            RequestGetListProductModel request = new RequestGetListProductModel
            {
                data = new ProductModel 
                {
                    productCode = ""
                },
                deviceInfo = "ShopUI",
                transactionDate = DateTime.Now
            };

            string host = _configuration["DemoAPI:URL"];
            string controller = "Product/GetListProduct";
            string data = JsonConvert.SerializeObject(request);

            var content = _connectService.PostAPI(host, controller, data);
            var response = JsonConvert.DeserializeObject<ResponseGetListProductModel>(content);
            if (response == null)
            {
                return new ResponseGetListProductModel
                {
                    message = "Failed to connect internal service."
                };
            }

            return response;
        }
    }
}
