using DotnetWebApi.Application.Common.Interfaces;
using System.Security.Claims;

namespace DotnetWebApi.WebApi.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        public string? UserId => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
