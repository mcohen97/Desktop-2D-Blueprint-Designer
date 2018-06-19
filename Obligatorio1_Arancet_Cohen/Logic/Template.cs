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

            if (heightAboveFloor < 0) {
                throw new InvalidTemplateDimensionException();
            }

            if (height <= 0 || (height + heightAboveFloor) >= Constants.WALL_HEIGHT) {
                throw new InvalidTemplateDimensionException();
            }

            if (length <= 0 || length > Constants.MAX_OPENING_LENGTH) {
                throw new InvalidTemplateDimensionException();
            }

            if (type.Equals(ComponentType.DOOR) && heightAboveFloor > 0) {
                throw new InvalidDoorTemplateException();
            }

            this.name = name;
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
    }
}