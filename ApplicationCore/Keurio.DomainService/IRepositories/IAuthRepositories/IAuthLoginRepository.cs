using Keurio.DomainModel.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keurio.DomainService.IRepositories.IAuthRepositories
{
    public interface IAuthLoginRepository
    {
        Task<AuthLoginResponseDto?> LoginAsync(AuthLoginRequestDto UserCredentials, CancellationToken CancellationToken = default);
    }
}
