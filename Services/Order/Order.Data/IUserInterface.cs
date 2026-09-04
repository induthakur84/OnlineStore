
using Order.DTO.Request;
using Order.DTO.Response;
using ProjectCommonCode;
using static ProjectCommonCode.RegisterDependencyAttribute;

namespace Order.Data
{
    


    [RegisterScoped]
    public interface IUserInterface
    {
        Task<UserResponse> Create(UserRequest request);
        Task<UserResponse> Update(int id, UserRequest request);
        Task<UserResponse> GetById(int id); 
        Task<PageResults<UserResponse>> GetAll(
            int pageNumber= 1,
            int PageSize= 10,
            string? search= null,
            string? sortBy= null,
            string? sortOrder="desc"
            );
        Task<bool> DeleteById(int id);
    }
}