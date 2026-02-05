using Keurio.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.DomainService.IRepositories.ICategoryRepositories
{
    public interface ICategoryUpdateRepository
    {
        Task<int> UpdateAsync(Category Model, CancellationToken CancellationToken);
    }
}
