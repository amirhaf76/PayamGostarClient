﻿using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels.CrmObjectTypeModels;
using System.Threading.Tasks;

namespace PayamGostarClient.InitServiceModels.Abstractions
{
    public interface IInitService
    {
        Task InitAsync<T>() where T : BaseCRMModel;
    }

}
