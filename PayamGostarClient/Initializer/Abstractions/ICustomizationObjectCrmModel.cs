using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.Initializer.Abstractions
{
    public interface ICustomizationCrmModel
    {
        CustomizationCrmType CustomizationCrmType { get; }
    }
}
