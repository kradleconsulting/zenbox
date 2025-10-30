using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zenbox.model;
using zenbox.model.Entity;

namespace zenbox.core.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentModel>> GetList();
        Task<StudentModel> Get(Guid id);
        Task<StudentModel> Add(StudentModel student);
        Task<bool> Delete(Guid id);
        Task<StudentModel> Update(StudentModel student);
    }
}
