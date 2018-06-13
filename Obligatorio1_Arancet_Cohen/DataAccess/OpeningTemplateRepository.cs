using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRepositoryInterface;
using RepositoryInterface;
using Logic.Domain;
using Entities;
using System.Data.Entity.Infrastructure;
using Logic.Exceptions;
using System.Linq.Expressions;

namespace DataAccess
{
    public class OpeningTemplateRepository : IRepository<Template>, ITemplateRepository
    {
        public void Add(Template entity)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Delete(Template entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Template record)
        {
            throw new NotImplementedException();
        }

        public Template Get(Template asked)
        {
            throw new NotImplementedException();
        }

        public Template Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Template> GetAll()
        {
            throw new NotImplementedException();
        }

        public Template GetTemplateByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public void Modify(Template entity)
        {
            throw new NotImplementedException();
        }
    }
}
