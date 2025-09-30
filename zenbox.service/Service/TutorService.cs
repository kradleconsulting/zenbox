using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zenbox.core.Interface;
using zenbox.model.Entity;

namespace zenbox.service
{ 
    public class TutorService() : ITutorService
    {
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
