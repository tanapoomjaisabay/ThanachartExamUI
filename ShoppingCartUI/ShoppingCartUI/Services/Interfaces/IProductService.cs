﻿using ShoppingCartUI.Models;

namespace ShoppingCartUI.Services.Interfaces
{
    public interface IProductService
    {
        ResponseGetListProductModel GetListProduct();
        ResponseTransactionModel CreateTransaction(RequestTransactionModel model);
    }
}
