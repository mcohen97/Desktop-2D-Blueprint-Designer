using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public class Window : Opening, IMaterialType
    {

        public Window(Point aPlace) : base(aPlace)
        {
            float DefaultHeightValue = 1;
            float DefaultLengthValue = 0.85F;
            float DefaultHeightAboveFloor = 1;
            Template defaultTemplate = new Template("Default Window Template", DefaultLengthValue, DefaultHeightAboveFloor, DefaultHeightValue, ComponentType.WINDOW);
            base.dimensions = defaultTemplate;
        }

        public Window(Point aPlace, Template template) :base(aPlace,template)
        {
            if (template.Type != ComponentType.WINDOW)
            {
                throw new TemplateTypeNotMatchException();
            }

            position = aPlace;
            dimensions = template;
        }

        public override ComponentType GetComponentType()
        {
            return ComponentType.WINDOW;
        }
    }
}
