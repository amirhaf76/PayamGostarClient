namespace PayamGostarClient.ApiServices.Abstractions
{
    public interface IPayamGostarClientServiceFactory
    {
        ICrmObjectTypeService CreateCrmObjectTypeService();

        ICrmObjectTypeFormService CreateCrmObjectTypeFormService();

        ICrmObjectTypeTicketService CreateCrmObjectTypeTicketService();

        IExtendedPropertyService CreateExtendedPropertyService();

        IPropertyGroupService CreatePropertyGroupService();

        ICrmObjectTypeStageService CreateCrmObjectTypeStageService();

    }
}