using Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManager.Core.Interfaces
{
    public interface IFormSubmissionRepository
    {
        void Add(FormSubmission formSubmission);
        IEnumerable<FormSubmission> GetAll();
        FormSubmission GetById(int id);
        void Update(FormSubmission formSubmission);
        void Delete(int id);

    }
}
