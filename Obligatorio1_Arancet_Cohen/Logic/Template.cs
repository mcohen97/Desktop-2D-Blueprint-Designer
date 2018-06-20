using LogicExceptions;
using System;
using Logic.Domain;

namespace Logic.Domain
{
    public class Template
    {
        private float height;
        private float length;
        private string name;
        private ComponentType type;
        private float heightAboveFloor;

        public Template(string name, float length, float heightAboveFloor, float height, ComponentType type)
        {
            if (!(type.Equals(ComponentType.DOOR) || type.Equals(ComponentType.WINDOW))) {
                throw new InvalidTemplateTypeException();
            }

            if (String.IsNullOrEmpty(name)) {
                throw new EmptyTemplateNameException();
            }

            if (heightAboveFloor < 0 || heightAboveFloor> Constants.MAX_HEIGHT_ABOVE_FLOOR) {
                throw new InvalidTemplateDimensionException("Height above floor must be between "+0+" and "+Constants.MAX_HEIGHT_ABOVE_FLOOR);
            }

            if (height <= 0 || (height + heightAboveFloor) >= Constants.WALL_HEIGHT) {
                throw new InvalidTemplateDimensionException("Height must be more than "+ 0 +" and less than" + Constants.WALL_HEIGHT);
            }

            if (length <= 0 || length > Constants.MAX_OPENING_LENGTH) {
                throw new InvalidTemplateDimensionException("Length must be more than "+0+" and less than" + Constants.MAX_OPENING_LENGTH);
            }

            if (type.Equals(ComponentType.DOOR) && heightAboveFloor > 0) {
                throw new InvalidDoorTemplateException();
            }
            //a way to ignore cases in equal names.
            this.name = name.ToUpper();
            this.length = length;
            this.heightAboveFloor = heightAboveFloor;
            this.height = height;
            this.type = type;
        }

        public float Height { get { return height; } internal set { height = value; } }
        public float Length { get { return length; } internal set { length = value; } }
        public string Name { get { return name; } internal set { name = value; } }
        public ComponentType Type { get { return type; } internal set { type = value; } }
        public float HeightAboveFloor { get { return heightAboveFloor; } internal set { heightAboveFloor = value; } }
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            bool areEqual;
            if (obj == null)
            {
                areEqual = false;
            }
            else if (obj is Template) { 
                Template otherTemplate = (Template)obj;
                areEqual = otherTemplate.Name.Equals(this.Name);
            }
            else
            {
                areEqual = false;
            }

            return areEqual;
        }

        public override string ToString()
        {
            return name;
        }
    }
}