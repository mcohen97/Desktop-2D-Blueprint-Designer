using Logic.Domain;

namespace Logic
{
    public class Template
    {
        private float height;
        private float length;
        private string name;
        private ComponentType type;
        private float width;

        public Template(string name, float length, float width, float height, ComponentType type)
        {
            this.name = name;
            this.length = length;
            this.width = width;
            this.height = height;
            this.type = type;
        }

        public float Height { get { return this.height; } internal set { this.height = value; } }
        public float Length { get { return this.length; } internal set { this.length = value; } }
        public string Name { get { return this.name; } internal set { this.name = value; } }
        public ComponentType Type { get { return this.type; } internal set { this.type = value; } }
        public float Width { get { return this.width; } internal set { this.width = value; } }
    }
}