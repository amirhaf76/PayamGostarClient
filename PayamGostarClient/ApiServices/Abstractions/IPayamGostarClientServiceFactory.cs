namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IPayamGostarClientServiceFactory
    {
        ICrmObjectTypeService CreateCrmObjectTypeService();

        ICrmObjectTypeFormService CreateCrmObjectTypeFormService();

        IExtendedPropertyService CreateExtendedPropertyService();

        IPropertyGroupService CreatePropertyGroupService();

        ICrmObjectTypeStageService CreateCrmObjectTypeStageService();

    }
}