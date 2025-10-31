using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zenbox.core.Interface;
using zenbox.data;
using zenbox.model.Entity;

namespace zenbox.service
{ 
    public class TutorService : ITutorService
    {
        protected readonly ZenboxDbContext _db;
        
        public TutorService(ZenboxDbContext db)
        {
            _db = db;
        }

        public Task<bool> Add(TutorModel tutor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TutorModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TutorModel> GetByUserId(Guid id)
        {
            return await _db.Teachers.Where(e => e.UserId == id)
            .Select(e => new TutorModel()
            {
                Id = e.Id,
                Name = e.Name,
                IsActive = e.IsActive,
                UserId = e.UserId
            }).SingleAsync();
        }

        public Task<IEnumerable<TutorModel>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TutorModel tutor)
        {
            throw new NotImplementedException();
        }
    }
}
