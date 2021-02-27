using Amizade.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amizade.Domain.Model.Interfaces.Repositories
{
    public interface IAmigoRepository
    {
        Task<IEnumerable<AmigoEntity>> GetAllAsync();
        Task<AmigoEntity> GetByIdAsync(int id);
        Task InsertAsync(AmigoEntity amigoEntity);
        Task UpdateAsync(AmigoEntity amigoEntity);
        Task DeleteAsync(AmigoEntity amigoEntity);

    }
}
