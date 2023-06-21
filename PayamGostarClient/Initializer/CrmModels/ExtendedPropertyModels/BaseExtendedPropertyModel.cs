using PayamGostarClient.ApiServices.Dtos.ExtendedPropertyServiceDtos;
using PayamGostarClient.Initializer.Helpers;
using System;
using System.Collections.Generic;

namespace PayamGostarClient.Initializer.CrmModels.ExtendedPropertyModels
{
    public abstract class BaseExtendedPropertyModel : IEquatable<BaseExtendedPropertyModel>
    {
        public BaseExtendedPropertyModel()
        {
            Name = Array.Empty<ResourceValue>();
            ToolTip = Array.Empty<ResourceValue>();
        }

        public abstract Gp_ExtendedPropertyType Type { get; }

        public string UserKey { get; set; }

        public ResourceValue[] Name { get; set; }
        public ResourceValue[] ToolTip { get; set; }

        public PropertyGroup PropertyGroup { get; set; }

        internal string CrmObjectTypeId { get; set; }

        public bool IsRequired { get; set; }

        public string DefaultValue { get; set; }


        public bool Equals(BaseExtendedPropertyModel other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Type != other.Type ||
                UserKey != other.UserKey ||
                IsRequired != IsRequired ||
                DefaultValue != DefaultValue)
            {
                return false;
            }

            if (CrmObjectTypeId == default && CrmObjectTypeId != other.CrmObjectTypeId)
            {
                return false;
            }

            if (!Name.CheckResourceValues(other.Name))
            {
                return false;
            }

            if (!ToolTip.CheckResourceValues(other.ToolTip))
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var baseModel = obj as BaseExtendedPropertyModel;

            if (baseModel == null)
            {
                return false;
            }

            return Equals(baseModel);
        }

        public override int GetHashCode()
        {
            int hashCode = -1185363241;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserKey);
            hashCode = hashCode * -1521134295 + EqualityComparer<ResourceValue[]>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<ResourceValue[]>.Default.GetHashCode(ToolTip);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CrmObjectTypeId);
            hashCode = hashCode * -1521134295 + IsRequired.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DefaultValue);
            return hashCode;
        }
    }
}
