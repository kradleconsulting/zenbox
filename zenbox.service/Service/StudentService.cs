using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zenbox.core.Interface;
using zenbox.model;
using zenbox.model.Entity;

namespace zenbox.service
{
    public class StudentService : IStudentService
    {
        public Task<bool> Add(StudentModel student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentModel>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(StudentModel student)
        {
            throw new NotImplementedException();
        }
    }
}
