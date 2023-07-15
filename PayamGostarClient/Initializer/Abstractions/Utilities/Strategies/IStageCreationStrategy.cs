using PayamGostarClient.Initializer.CrmModels;
using PayamGostarClient.Initializer.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayamGostarClient.Initializer.Abstractions.Utilities.Strategies
{
    internal interface IStageCreationStrategy
    {
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stages"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundAtleastAFinalStageException"></exception>
        Task CreateStagesAsync(Guid id, List<Stage> stages);
        Task UpdateStagesAsync(Guid id, List<Stage> stages, IEnumerable<Stage> existedStages);
    }
}
