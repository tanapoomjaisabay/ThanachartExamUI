namespace ShoppingCartUI.Services.Interfaces
{
    public interface IConnectService
    {
        string PostAPI(string host, string controller, string json);
    }
}
