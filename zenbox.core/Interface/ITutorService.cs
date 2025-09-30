using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zenbox.model;
using zenbox.model.Entity;

namespace zenbox.core.Interface
{
    public interface ITutorService
    {
        Task<IEnumerable<TutorModel>> GetList();
        Task<TutorModel> Get(Guid id);
        Task<bool> Add(TutorModel tutor);
        Task<bool> Delete(Guid id);
        Task<bool> Update(TutorModel tutor);
    }
}

