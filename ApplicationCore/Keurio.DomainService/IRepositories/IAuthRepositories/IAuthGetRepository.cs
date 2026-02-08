using Keurio.DomainModel.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.DomainService.IRepositories.IAuthRepositories
{
    public interface IAuthGetRepository
    {
        Task<AuthLoginResponseDto?> GetAsync(int UserID, int CompanyID, CancellationToken CancellationToken = default);
    }
}
