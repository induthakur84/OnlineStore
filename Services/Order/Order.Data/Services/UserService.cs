using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Data.Context;
using Order.Domain;
using Order.DTO.Request;
using Order.DTO.Response;
using ProjectCommonCode;

namespace Order.Data.Services
{
    public class UserService : IUserInterface
    {

        private readonly OrderDbContext _context;
        private  readonly IMapper _mapper;

        public UserService(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async  Task<UserResponse> Create(UserRequest request)
        {
            if(request == null)
            {
               throw new ArgumentNullException(nameof(request));
            }

            var userEntity= _mapper.Map<User>(request);
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserResponse>(userEntity);

        }

        public  async Task<bool> DeleteById(int id)
        {
            var userEntity= await _context.Users.FindAsync(id);

            if (userEntity == null)
            {
                return false;
            }
            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PageResults<UserResponse>> GetAll(int pageNumber = 1, int PageSize = 10, string? search = null, string? sortBy = null, string? sortOrder = "desc")
        {
            var query = _context.Users.AsNoTracking().AsQueryable();


            ///Searching
            if(!String.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();


                query = query.Where(x =>

                x.Name.ToLower().Contains(search) ||

                x.Email.ToLower().Contains(search)
                );

            }


            ///Sorting
            ///

            query = (sortBy?.ToLower(), sortOrder?.ToLower()) switch
            {

                ("id", "asc")=> query.OrderBy(x => x.Id),
                ("id", "desc")=> query.OrderByDescending(x => x.Id),
                 _ => query.OrderByDescending(x=>x.Id),
            };

            var totalCount = await query.CountAsync();



            //Pagination

            var data = await query
                       .Skip((pageNumber-1)*PageSize)
                       .Take(PageSize)
                       .Select(x=> _mapper.Map<UserResponse>(x))
                       .ToListAsync();
            return new PageResults<UserResponse>()
            {
                PageNumber=pageNumber,
                PageSize=PageSize,
                TotalNumberOfRecords=totalCount,
                Results = data
            };
        }

        public async Task<UserResponse> GetById(int id)
        {
            var user= await _context.Users.FindAsync(id);
            if (user == null)
            {

                throw new Exception("Usernotfound");
            }

            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> Update(int id, UserRequest request)
        {
           
            if(request == null)
            {
                throw new Exception("user request data not found");
            }

            var userEntity= await _context.Users.FindAsync(id);
            if(userEntity == null)
            {
                throw new Exception("User not found");
            }
            userEntity.Name = request.Name;
            userEntity.Email = request.Email;

            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponse>(userEntity);

        }
    }
}
