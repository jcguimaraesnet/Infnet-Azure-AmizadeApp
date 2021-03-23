using Amizade.Domain.Model.Entities;
using Amizade.Domain.Model.Interfaces.Infrastructure;
using Amizade.Domain.Model.Interfaces.Repositories;
using Amizade.Domain.Model.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Amizade.Domain.Services.Services
{
    public class AmigoService : IAmigoService
    {
        private readonly IAmigoRepository _repository;
        private readonly IBlobService _blobService;
        private readonly IQueueService _queueService;

        public AmigoService(
            IAmigoRepository repository, 
            IBlobService blobService, 
            IQueueService queueService
        )
        {
            _repository = repository;
            _blobService = blobService;
            _queueService = queueService;
        }

        public async Task<IEnumerable<AmigoEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AmigoEntity> GetByIdAsync(int id)
        {
            //invocando uma function para atualizar ultima data de visualização
            //await _functionService.InvokeAsync(amigoTask.Result);

            //buscando a entidade amigo com base no id (identificador)
            var amigoTask = _repository.GetByIdAsync(id);

            var amigoEntity = amigoTask.Result;

            //primeira forma de serializar objeto json/base64 (usando package Newtonsoft.Json)
            //var jsonAmigo = JsonConvert.SerializeObject(amigoTask.Result);
            //var bytesJsonAmigo = UTF8Encoding.UTF8.GetBytes(jsonAmigo);
            //string jsonAmigoBase64 = Convert.ToBase64String(bytesJsonAmigo);

            //segunda forma de serializar objeto json/base64 (usando package System.Text.Json)
            var jsonBytes = JsonSerializer.SerializeToUtf8Bytes(amigoEntity);
            string jsonAmigoBase64 = Convert.ToBase64String(jsonBytes);

            //enviando objeto serializado em json e base64 como msg para a fila
            await _queueService.SendAsync(jsonAmigoBase64);

            return amigoEntity;
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
