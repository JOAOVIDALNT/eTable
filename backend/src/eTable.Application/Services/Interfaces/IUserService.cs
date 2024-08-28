using eTable.Communication.Requests;
using eTable.Communication.Responses;

namespace eTable.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserResponseDTO> RegisterUser(RegisterUserRequestDTO request);
    }
}
