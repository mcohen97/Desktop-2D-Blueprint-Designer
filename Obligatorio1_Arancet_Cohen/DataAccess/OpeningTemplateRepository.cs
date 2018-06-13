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
            MaterialAndEntityConverter translator = new MaterialAndEntityConverter();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                try
                {
                    OpeningTemplateEntity converted = translator.OpeningTemplateToEntity(entity);
                    context.OpeningTemplates.Add(converted);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    throw new TemplateAlreadyExistsException();
                }


            }
        }

        public void Clear()
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                foreach (OpeningTemplateEntity template in context.OpeningTemplates)
                {
                    context.OpeningTemplates.Remove(template);
                }
                context.SaveChanges();
            }

        }

        public void Delete(Template entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Template record)
        {
            bool doesExist;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                doesExist = context.OpeningTemplates.Any(ote => ote.Name.Equals(record.Name));
            }
            return doesExist;
        }


        public Template Get(Template asked)
        {
            return SelectFirstOrDefault(t => t.Name.Equals(asked.Name));

        }


        public Template Get(Guid id)
        {
            return SelectFirstOrDefault(t => t.Id.Equals(id));
        }

        public Template GetTemplateByName(string name)
        {
            return SelectFirstOrDefault(t => t.Name.Equals(name));
        }

        private Template SelectFirstOrDefault(Expression<Func<OpeningTemplateEntity, bool>> aCondition)
        {
            Template firstToComply;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                MaterialAndEntityConverter translator = new MaterialAndEntityConverter();
                OpeningTemplateEntity firstRecord = context.OpeningTemplates.FirstOrDefault(aCondition);

                if (firstRecord == null)
                {
                    throw new TemplateDoesNotExistException();
                }
                else
                {
                    firstToComply = translator.EntityToOpeningTemplate(firstRecord);
                }
            }

            return firstToComply;
        }


        public ICollection<Template> GetAll()
        {
            throw new NotImplementedException();
        }


        public bool IsEmpty()
        {
            bool isEmpty;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                isEmpty = !context.OpeningTemplates.Any();
            }
            return isEmpty;
        }

        public void Modify(Template entity)
        {
            throw new NotImplementedException();
        }
    }
}
