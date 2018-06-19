using System;
using Logic.Domain;
using RepositoryInterface;
using System.Linq;
using System.Collections.Generic;
using ServicesExceptions;
using DataAccessExceptions;

namespace Services
{
    public class OpeningFactory
    {
        private IRepository<Template> templatesRepository;

        public OpeningFactory(IRepository<Template> repository)
        {
            this.templatesRepository = repository;
        }

        public Opening CreateFromTemplate(Point position, string templateName)
        {
            if(templateName == null)
            {
                throw new ArgumentNullException();
            }

            Opening returnedOpening = null;
            ICollection<Template> templates = templatesRepository.GetAll();
            if(!templates.Any(x => x.Name.Equals(templateName)))
            {
                throw new TemplateDoesNotExistException();
            }

            Template templateAsked = templatesRepository.GetAll().FirstOrDefault(x => x.Name.Equals(templateName));
            switch (templateAsked.Type)
            {
                case ComponentType.WALL:
                    throw new InvalidComponentTypeException();
                    break;
                case ComponentType.BEAM:
                    throw new InvalidComponentTypeException();
                    break;
                case ComponentType.DOOR:
                    returnedOpening = new Door(position, templateAsked);
                    break;
                case ComponentType.WINDOW:
                    returnedOpening = new Window(position, templateAsked);
                    break;
                case ComponentType.COLUMN:
                    throw new InvalidComponentTypeException();
                    break;
                default:
                    throw new InvalidComponentTypeException();
                    break;
            }

            return returnedOpening;
        }

    }
}