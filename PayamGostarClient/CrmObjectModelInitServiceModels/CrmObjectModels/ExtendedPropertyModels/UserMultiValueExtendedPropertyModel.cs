using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.ExtendedPropertyModels
{
    public class UserMultiValueExtendedPropertyModel : BaseExtendedPropertyModel
    {
        public bool ShowDeactiveMembersOption { get; set; }

        public override Gp_ExtendedPropertyType Type => Gp_ExtendedPropertyType.UserMultiValue;
    }


}
