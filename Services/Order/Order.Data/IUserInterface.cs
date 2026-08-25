
using Order.DTO.Request;
using Order.DTO.Response;

namespace Order.Data
{
    public interface IUserInterface
    {
        Task<UserRequest> Create(UserRequest request);
        Task<UserRequest> Update(UserRequest request);
        Task<UserResponse> GetById(int id); 
        Task<IQueryable<UserResponse>> GetAll(
            int pageNumber= 1,
            int PageSize= 10,
            string? search= null,
            string? sortBy= null,
            string? sortOrder="desc"
            );
        Task<bool> DeleteById(int id);
    }
}