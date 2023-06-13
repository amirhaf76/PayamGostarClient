namespace PayamGostarClient.ApiProvider.Abstractions
{
    public interface IPayamGostarClientAbstractFactory
    {
        ICrmObjectTypeApiClient CreateCrmObjectTypeApiClient();

        ICrmObjectTypeFormApiClient CreateCrmObjectTypeFormApiClientt();

        IPropertyDefinitionApiClient CreateIPropertyDefinitionApiClient();

        IPropertyGroupApiClient CreateIPropertyGroupApiClient();

        ICrmObjectTypeStageApiClient CreateICrmObjectTypeStageApiClient();

    }
}
