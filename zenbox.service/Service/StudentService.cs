using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zenbox.core.Interface;
using zenbox.data;
using zenbox.model;
using zenbox.model.Entity;

namespace zenbox.service
{
    public class StudentService : IStudentService
    {
        protected readonly ZenboxDbContext _db;

        public StudentService(ZenboxDbContext db)
        {
            _db = db;
        }

        public Task<StudentModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentModel> GetByUserId(Guid id)
        {
            return await _db.Students.Where(e => e.UserId == id)
                .Select(e => new StudentModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    IsActive = e.IsActive,
                    UserId = e.UserId
                }).SingleAsync();
        }

        public Task<StudentModel> Update(StudentModel student)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentModel>> GetList()
        {
            return _db.Students.Any() ?
                    await _db.Students.Select(e => new StudentModel()
                    {
                        Id = e.Id,
                        Name = e.Name,
                        IsActive = e.IsActive,
                        UserId = e.UserId
                    }).ToListAsync() : new List<StudentModel>();
        }

        public async Task<StudentModel> Add(StudentModel student)
        {
            var s = new Student()
            {
                UserId = student.UserId,
                Id = student.Id,
                Name = student.Name,
                IsActive = student.IsActive
            };

            _db.Students.Add(s);
            await _db.SaveChangesAsync();

            return new StudentModel()
            {
                UserId = s.UserId,
                Id = s.Id,
                Name = s.Name,
                IsActive = s.IsActive
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            var s = await _db.Students.SingleAsync(e => e.Id == id);            
            
            _db.Students.Remove(s);

            await _db.SaveChangesAsync();

            return true;
        }
    }
}
