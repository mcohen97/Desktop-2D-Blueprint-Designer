using System;
using Logic.Domain;
using RepositoryInterface;
using System.Linq;
using System.Collections.Generic;
using ServicesExceptions;
using BusinessDataExceptions;

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

            if (templateAsked.Type.Equals(ComponentType.DOOR) ) {
                returnedOpening = new Door(position, templateAsked);
            } else if (templateAsked.Type.Equals(ComponentType.WINDOW)) {
                returnedOpening = new Window(position, templateAsked);
            } else{
                throw new InvalidComponentTypeException();
            }
            return returnedOpening;
        }

    }
}