using Amizade.Domain.Model.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Amizade.Domain.Model.Interfaces.Services
{
    public interface IAmigoService
    {
        Task<IEnumerable<AmigoEntity>> GetAllAsync();
        Task<AmigoEntity> GetByIdAsync(int id);
        Task InsertAsync(AmigoEntity amigoEntity, Stream stream);
        Task UpdateAsync(AmigoEntity amigoEntity, Stream stream);
        Task DeleteAsync(AmigoEntity amigoEntity);
    }
}
