namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IPayamGostarClientServiceFactory
    {
        ICrmObjectTypeApiService CreateCrmObjectTypeApiService();
    }
}