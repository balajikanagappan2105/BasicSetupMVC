using AutoMapper;
using EffortEntry.Repository.Interfaces;
using EffortEntry.Repository.Models;
using EffortEntry.Repository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EffortEntry.Repository.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		private readonly DbContext _context;
		private IMapper _mapper;
		public UserRepository(DbContext context, IMapper mapper)
			: base(context)
		{
			_context = context;
			_mapper = mapper;
		}
	}
}

