using eTable.API.Models.Requests;
using eTable.API.Models.Responses;

namespace eTable.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserResponseDTO> RegisterUser(RegisterUserRequestDTO request);
    }
}
