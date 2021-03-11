using Amizade.Domain.Model.Entities;
using Amizade.Domain.Model.Interfaces.Infrastructure;
using Amizade.Domain.Model.Interfaces.Repositories;
using Amizade.Domain.Model.Interfaces.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Amizade.Domain.Services.Services
{
    public class AmigoService : IAmigoService
    {
        private readonly IAmigoRepository _repository;
        private readonly IBlobService _blobService;
        private readonly IFunctionService _functionService;

        public AmigoService(IAmigoRepository repository, IBlobService blobService, IFunctionService functionService)
        {
            _repository = repository;
            _blobService = blobService;
            _functionService = functionService;
        }

        public async Task<IEnumerable<AmigoEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AmigoEntity> GetByIdAsync(int id)
        {
            await _functionService.InvokeAsync(new { Id = id });
            var amigoTask = _repository.GetByIdAsync(id);

            return amigoTask.Result;
        }

        public async Task InsertAsync(AmigoEntity amigoEntity, Stream stream)
        {
            var newUri = await _blobService.UploadAsync(stream);
            amigoEntity.ImageUri = newUri;

            await _repository.InsertAsync(amigoEntity);
        }

        public async Task UpdateAsync(AmigoEntity amigoEntity, Stream stream)
        {
            //TODO: improvement
        }

        public async Task DeleteAsync(AmigoEntity amigoEntity)
        {
            //TODO: improvement
        }

    }
}
