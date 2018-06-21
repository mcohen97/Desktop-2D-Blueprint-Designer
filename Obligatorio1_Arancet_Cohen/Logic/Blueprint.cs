using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using LogicExceptions;

[assembly: InternalsVisibleTo("Logic.Test")]


namespace Logic.Domain
{
    public class Blueprint : IBlueprint
    {

        private string name;
        public override string Name { get { return name; } internal set { SetName(value); } }

        private int length;

        public override int Length { get { return length; } protected set { SetLength(value); } }//Horizontal X Mesaure

        private int width;
        public override int Width { get { return width; } protected set { SetWidth(value); } }//Vertical Y Mesaure

        private MaterialContainer materials;

        private WallsPositioner wallsManager;
        private PunctualComponentPositioner punctualComponentManager;

        private User owner;
        public override User Owner { get { return owner; } set { SetOwner(value); } }

        public Blueprint(int aLength, int aWidth, string aName)
        {
            Length = aLength;
            Width = aWidth;
            Name = aName;
            materials = new MaterialContainer();
            signatures = new List<Signature>();
            id = Guid.NewGuid();
            punctualComponentManager = new PunctualComponentPositioner(materials, Width, Length);
            wallsManager = new WallsPositioner(materials, punctualComponentManager, Width, Length);
        }

        public Blueprint(int aLength, int aWidth, string aName, MaterialContainer container)
        {
            Length = aLength;
            Width = aWidth;
            Name = aName;
            materials = container;
            signatures = new List<Signature>();
            id = Guid.NewGuid();
            punctualComponentManager = new PunctualComponentPositioner(materials, Width, Length);
            wallsManager = new WallsPositioner(materials, punctualComponentManager, Width, Length);
        }

        public Blueprint(int aLength, int aWidth, string aName, User anOwner, MaterialContainer container, ICollection<Signature> someSignatures, Guid anId)
        {
            Length = aLength;
            Width = aWidth;
            Name = aName;
            Owner = anOwner;
            signatures = someSignatures;
            materials = container;
            id = anId;
            punctualComponentManager = new PunctualComponentPositioner(materials, Width, Length);
            wallsManager = new WallsPositioner(materials, punctualComponentManager, Width, Length);
        }

        private void SetName(string aName)
        {
            if (String.IsNullOrEmpty(aName))
            {
                throw new ArgumentNullException();
            }
            name = aName;
        }

        private void SetLength(int aLength)
        {
            if (aLength <= 0)
            {
                throw new ArgumentException();
            }
            length = aLength;
        }

        private void SetWidth(int aWidth)
        {
            if (aWidth <= 0)
            {
                throw new ArgumentException();
            }
            width = aWidth;
        }

        private void SetOwner(User aUser)
        {
            if (aUser == null)
            {
                throw new ArgumentNullException();
            }
            owner = aUser;
        }

        public override void InsertWall(Point from, Point to)
        {
            wallsManager.InsertWall(from, to);
        }

        public override void RemoveWall(Point from, Point to)
        {
            wallsManager.RemoveWall(from, to);
        }

        public override void InsertOpening(Opening newOpening)
        {
            punctualComponentManager.InsertOpening(newOpening);
        }

        public override void InsertColumn(Point columnPosition)
        {
            punctualComponentManager.InsertColumn(columnPosition);
        }

        public override void RemoveColumn(Point columnPosition)
        {
            punctualComponentManager.RemoveColumn(columnPosition);
        }

        public override void RemoveOpening(Opening anOpening)
        {
            punctualComponentManager.RemoveOpening(anOpening);
        }

        public override ICollection<Wall> GetWalls()
        {
            return (ICollection<Wall>)materials.GetWalls();
        }

        public override ICollection<Beam> GetBeams()
        {
            return (ICollection<Beam>)materials.GetBeams();
        }

        public override ICollection<Opening> GetOpenings()
        {
            return (ICollection<Opening>)materials.GetOpenings();
        }

        public override ICollection<ISinglePointComponent> GetColumns()
        {
            return (ICollection<ISinglePointComponent>)materials.GetColumns();
        }

        public override string ToString()
        {

            return "Name: " + Name + " "
                   + "Owner: " + Owner.UserName + " ";
        }
    }
}
