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
using DataAccessExceptions;
using System.Linq.Expressions;
using System.Data.Common;
using System.Data.Entity.Core;

namespace DataAccess
{
    public class OpeningTemplateRepository : IRepository<Template>, ITemplateRepository
    {
        public void Add(Template entity)
        {
            try
            {
                TryAdding(entity);
            }
            catch (EntityException) {
                throw new InaccessibleDataException();
            }
        }

        private void TryAdding(Template entity) {
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
            try
            {
                TryClearing();
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }

        }

        private void TryClearing() {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                foreach (OpeningTemplateEntity template in context.OpeningTemplates)
                {
                    context.OpeningTemplates.Remove(template);
                }
                context.SaveChanges();
            }
        }

        public void Delete(Template toDelete)
        {
            try
            {
                TryDeleting(toDelete);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            
        }

        private void TryDeleting(Template toDelete) {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                OpeningTemplateEntity entity = context.OpeningTemplates.FirstOrDefault(ote => ote.Name.Equals(toDelete.Name));
                if (entity != null)
                {
                    context.OpeningTemplates.Remove(entity);
                    context.SaveChanges();
                }

            }
        }

        public bool Exists(Template record)
        {
            bool doesExist;
            try
            {
                doesExist = TryAskingIfExists(record);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return doesExist;
        }

        private bool TryAskingIfExists(Template record) {
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
            return SelectFirstOrDefault(t => t.Name.Equals(name.ToUpper()));
        }

        private Template SelectFirstOrDefault(Expression<Func<OpeningTemplateEntity, bool>> aCondition)
        {
            Template firstToComply;
            try
            {
                firstToComply = TrySelectFirstOrDefault(aCondition);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return firstToComply;
        }

        private Template TrySelectFirstOrDefault(Expression<Func<OpeningTemplateEntity, bool>> aCondition) {
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
            return SelectByCriteria(ote => true);
        }

        private ICollection<Template> SelectByCriteria(Expression<Func<OpeningTemplateEntity, bool>> aCriteria)
        {
            ICollection<Template> elegibleUsers;
            try
            {
                elegibleUsers = TrySelectingByCriteria(aCriteria);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return elegibleUsers;
        }

        private ICollection<Template> TrySelectingByCriteria(Expression<Func<OpeningTemplateEntity, bool>> aCriteria) {
            ICollection<Template> elegibleUsers = new List<Template>();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                MaterialAndEntityConverter translator = new MaterialAndEntityConverter();
                IQueryable<OpeningTemplateEntity> elegibleRecords = context.OpeningTemplates.Where(aCriteria);
                foreach (OpeningTemplateEntity record in elegibleRecords)
                {
                    elegibleUsers.Add(translator.EntityToOpeningTemplate(record));
                }
            }

            return elegibleUsers;
        }

        public bool IsEmpty()
        {
            bool isEmpty;
            try
            {
                isEmpty = TryAskingIfEmpty();
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return isEmpty;
        }

        private bool TryAskingIfEmpty() {
            bool isEmpty;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                isEmpty = !context.OpeningTemplates.Any();
            }
            return isEmpty;
        }

        public void Modify(Template entity)
        {
            try
            {
                TryModifying(entity);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
        }

        private void TryModifying(Template entity) {
            if (!Exists(entity))
            {
                throw new TemplateDoesNotExistException();
            }
            MaterialAndEntityConverter translator = new MaterialAndEntityConverter();
            OpeningTemplateEntity record = translator.OpeningTemplateToEntity(entity);
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.Entry(record).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
