namespace PayamGostarClient.ApiProvider.Abstractions
{
    public interface IPayamGostarClientAbstractFactory
    {
        ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient();
    }
}
