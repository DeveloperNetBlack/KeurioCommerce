using Keurio.DomainModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.DomainService.IRepositories.ICategoryRepositories
{
    public interface ICategoryValidateRepository
    {
        Task<string> ValidateAsync(Category Model, CancellationToken CancellationToken);
    }
}
