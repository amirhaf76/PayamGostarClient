using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.CrmObjectDtos;
using Septa.PayamGostarClient.Initializer.Core.CrmModels;
using Septa.PayamGostarClient.Initializer.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Septa.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Strategies
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
        Task UpdateStagesAsync(Guid id, List<Stage> stages, IEnumerable<StageGetResultDto> existedStages);
    }
}
