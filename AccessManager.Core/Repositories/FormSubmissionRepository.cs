using AccessManager.Core.Data;
using AccessManager.Core.Interfaces;
using Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManager.Core.Repositories
{
    public class FormSubmissionRepository : IFormSubmissionRepository
    {
        private readonly AppDbContext _context;

        public FormSubmissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(FormSubmission formSubmission)
        {
            _context.FormSubmissions.Add(formSubmission);
            _context.SaveChanges();
        }

        public IEnumerable<FormSubmission> GetAll()
        {
            return _context.FormSubmissions.ToList();
        }

        public FormSubmission GetById(int id)
        {
            return _context.FormSubmissions.Find(id);
        }

        public void Update(FormSubmission formSubmission)
        {
            _context.FormSubmissions.Update(formSubmission);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.FormSubmissions.Find(id);
            if (entity != null)
            {
                _context.FormSubmissions.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}

