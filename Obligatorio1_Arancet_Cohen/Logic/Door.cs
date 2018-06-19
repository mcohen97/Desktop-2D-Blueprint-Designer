using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicExceptions;

namespace Logic.Domain
{

    public class Door : Opening, IMaterialType
    {

        public Door(Point aPlace) : base(aPlace)
        {
            float DefaultHeightValue = 2.20F;
            float DefaultLengthValue = 0.85F;
            Template defaultTemplate = new Template("Default Door Template", DefaultLengthValue, 0, DefaultHeightValue, ComponentType.DOOR);
            base.dimensions = defaultTemplate;
        }

        public Door(Point point, Template template) : base(point,template)
        {            
            if(template.Type != ComponentType.DOOR)
            {
                throw new TemplateTypeNotMatchException();
            }

            position = point;
            dimensions = template;
        }

        public override ComponentType GetComponentType()
        {
            return ComponentType.DOOR;
        }
    }
}
