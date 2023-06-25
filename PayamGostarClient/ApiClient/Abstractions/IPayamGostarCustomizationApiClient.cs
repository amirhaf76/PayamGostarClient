namespace PayamGostarClient.ApiClient.Abstractions
{
    public interface IPayamGostarCustomizationApiClient
    {

        IPayamGostarExtendedPropertyApiClient ExtendedPropertyApi { get; }

        IPayamGostarPropertyGroupApiClient PropertyGroupApi { get; }

        IPayamGostarCrmObjectTypeApiClient CrmObjectTypeApi { get; }
    }


}