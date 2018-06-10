using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Logic.Exceptions;

[assembly: InternalsVisibleTo("Logic.Test")]


namespace Logic.Domain
{
    public class Blueprint : IBlueprint
    {

        private string name;
        public override string Name { get { return name; } protected set { SetName(value); } }

        private int length;
        public override int Length { get { return length; } protected set { SetLength(value); } }//Horizontal X Mesaure

        private int width;
        public override int Width { get { return width; } protected set { SetWidth(value); } }//Vertical Y Mesaure

        private MaterialContainer materials;

        private User owner;
        public override  User Owner { get { return owner; } set { SetOwner(value); } }

        private Guid id;

        public Blueprint(int aLength, int aWidth, string aName)
        {
            Length = aLength;
            Width = aWidth;
            Name = aName;
            materials = new MaterialContainer();
            id = Guid.NewGuid();
            signatures = new List<Signature>();
        }

        public Blueprint(int aLength, int aWidth, string aName, MaterialContainer container)
        {
            Length = aLength;
            Width = aWidth;
            Name = aName;
            materials = container;
            id = Guid.NewGuid();
            signatures = new List<Signature>();
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
            Wall newWall = new Wall(from, to);
            if (!newWall.IsHorizontal() && !newWall.IsVertical())
            {
                throw new OutOfRangeComponentException("No es paralela a los ejes");
            }
            else if (!WallInRange(newWall))
            {
                throw new OutOfRangeComponentException();
            }
            else if (TakesOtherWallsPlace(newWall))
            {
                throw new CollinearWallsException();
            }
            else if (TakesAColumnPlace(newWall))
            {
                throw new ColumnInPlaceException();
            }
            else { 
                InsertValidatedWall(newWall);
            }
        }

        private bool TakesAColumnPlace(Wall newWall)
        {
            bool existColumnInWallPlace = false;
            foreach (ISinglePointComponent column in materials.GetColumns())
            {
                if (newWall.DoesContainComponent(column))
                {
                    existColumnInWallPlace = true;
                }
            }
            return existColumnInWallPlace;
        }

        public override void RemoveWall(Point from, Point to)
        {
            Wall aWall = new Wall(from, to);
            if (materials.ContainsWall(aWall))
            {
                materials.RemoveWall(aWall);
                RemoveOpeningsOfWall(aWall);
                AdjustIntersection(aWall.Beginning());
                AdjustIntersection(aWall.End());
            }
        }

        public override void InsertOpening(Opening newOpening)
        {
            if (!PunctualComponentInRange(newOpening))
            {
                throw new OutOfRangeComponentException();
            }
            else
            {
                bool belongsToWall = BelongsToAWall(newOpening);
                if (belongsToWall && !OccupiedPosition(newOpening))
                {
                    materials.AddOpening(newOpening);
                }
                else if (!belongsToWall)
                {
                    throw new ComponentOutOfWallException();
                }
            }
        }

        public void InsertColumn(Point columnPosition)
        {
            ISinglePointComponent newColumn = new Column(columnPosition);

            if (!PunctualComponentInRange(newColumn))
            {
                throw new OutOfRangeComponentException();
            }

            if (BelongsToAWall(newColumn))
            {
                throw new ComponentInWallException();
            }

            if (OccupiedPosition(newColumn))
            {
                throw new OccupiedPositionException();
            }

            materials.AddColumn(newColumn);

        }

        public override void RemoveOpening(Opening anOpening)
        {
            if (materials.ContainsOpening(anOpening))
            {
                materials.RemoveOpening(anOpening);
            }
        }

        //we assume in this method that the wall can be added
        private void InsertValidatedWall(Wall aWall)
        {
            if (IntersectsOtherWalls(aWall))
            {
                FractionNewIntersectedWall(aWall);
            }
            else if (Oversized(aWall))
            {
                InsertOversizedWall(aWall);
            }
            else
            {
                PlaceNewWall(aWall);
            }
        }

        private void FractionNewIntersectedWall(Wall aWall)
        {
            List<Point> intersectionPoints = new List<Point>();
            Point actualIntersection;
            foreach (Wall intersected in WallsIntersectedByThisOne(aWall))
            {
                if (!aWall.IsConnected(intersected))
                {
                    actualIntersection = intersected.GetIntersection(aWall);
                    PartWall(intersected, actualIntersection);
                    intersectionPoints.Add(actualIntersection);
                }
                else
                {
                    PlaceNewWall(aWall);
                }
            }
            intersectionPoints.Sort();
            SplitWall(aWall, intersectionPoints);
        }

        private void PartWall(Wall aWall, Point splitPoint)
        {
            // we are replacing the old walls with two halves
            materials.RemoveWall(aWall);
            RemoveOpening(splitPoint);
            CreateAndPlaceWall(aWall.Beginning(), splitPoint);
            CreateAndPlaceWall(splitPoint, aWall.End());
        }

        public override void RemoveOpening(Point actualIntersection)
        {
            Opening op = new Door(actualIntersection);
            if (materials.ContainsOpening(op))
            {
                materials.RemoveOpening(op);
            }
        }

        private void InsertOversizedWall(Wall newWall)
        {
            int maxLengthWallsCount = (int)(newWall.Length() / Constants.MAX_WALL_LENGTH);
            float lengthOfRemainingWall = newWall.Length() % Constants.MAX_WALL_LENGTH;
            Point vector = newWall.End() - newWall.Beginning();
            Point from = newWall.Beginning();
            Point to;
            for (int i = 0; i < maxLengthWallsCount; i++)
            {
                to = from.PointInSameLineAtSomeDistance(vector, Constants.MAX_WALL_LENGTH);
                CreateAndPlaceWall(from, to);
                from = to;
            }
            if (lengthOfRemainingWall > 0)
            {
                to = from.PointInSameLineAtSomeDistance(vector, lengthOfRemainingWall);
                CreateAndPlaceWall(from, to);
            }

        }

        private void PlaceNewWall(Wall newWall)
        {
            PlaceUnintersectedWall(newWall);
            AdjustIntersection(newWall.Beginning());
            AdjustIntersection(newWall.End());
        }

        private void PlaceUnintersectedWall(Wall aWall)
        {
            Beam BeginningBeam = new Beam(aWall.Beginning());
            Beam EndBeam = new Beam(aWall.End());
            PlaceBeamIfNotExists(BeginningBeam);
            PlaceBeamIfNotExists(EndBeam);
            materials.AddWall(aWall);
        }

        private void PlaceBeamIfNotExists(Beam aBeam)
        {
            if (!materials.ContainsBeam(aBeam))
            {
                materials.AddBeam(aBeam);
            }
        }

        private void SplitWall(Wall newWall, List<Point> intersectionPoints)
        {
            CreateAndPlaceWall(newWall.Beginning(), intersectionPoints.First());
            for (int i = 0; i < intersectionPoints.Count - 1; i++)
            {
                CreateAndPlaceWall(intersectionPoints[i], intersectionPoints[i + 1]);
            }
            CreateAndPlaceWall(intersectionPoints.Last(), newWall.End());

        }

        private void CreateAndPlaceWall(Point from, Point to)
        {
            try
            {
                Wall generatedWall = new Wall(from, to);
                if (!Oversized(generatedWall))
                {
                    PlaceUnintersectedWall(generatedWall);
                }
                else
                {
                    InsertOversizedWall(generatedWall);
                }
            }
            catch (ZeroLengthWallException)
            {

            }

        }

        private bool Oversized(Wall aWall)
        {
            return aWall.Length() > Constants.MAX_WALL_LENGTH;
        }

        private bool WallInRange(Wall newWall)
        {
            return PointInRange(newWall.Beginning()) && PointInRange(newWall.End());
        }

        private bool PunctualComponentInRange(ISinglePointComponent newComponent)
        {
            return PointInRange(newComponent.GetPosition());
        }

        private bool PointInRange(Point aPoint)
        {
            return aPoint.IsInRange(Length, Width);
        }

        private bool TakesOtherWallsPlace(Wall newWall)
        {
            return materials.GetWalls().Any(wall => wall.Overlaps(newWall));
        }

        private bool IntersectsOtherWalls(Wall aWall)
        {
            return WallsIntersectedByThisOne(aWall).Any();
        }

        private ICollection<Wall> WallsIntersectedByThisOne(Wall newWall)
        {
            return materials.GetWalls().Where(wall => wall.DoesIntersect(newWall)).ToList();
        }

        public bool OccupiedPosition(ISinglePointComponent punctualComponent)
        {
            return materials.GetOpenings().Any(op => op.GetPosition().Equals(punctualComponent.GetPosition()))
                || materials.GetBeams().Any(bm => bm.GetPosition().Equals(punctualComponent.GetPosition()))
                || materials.GetColumns().Any(cm => cm.GetPosition().Equals(punctualComponent.GetPosition()));
                
        }

        public bool BelongsToAWall(ISinglePointComponent singlePointed)
        {
            return materials.GetWalls().Any(wall => wall.DoesContainComponent(singlePointed));
        }

        public void RemoveOpeningsOfWall(Wall aWall)
        {
            foreach (Opening existing in GetOpeningsFromWall(aWall))
            {
                materials.RemoveOpening(existing);
            }
        }

        private List<Wall> GetWallsSharingBeam(Beam aBeam)
        {
            return materials.GetWalls().Where(wall => wall.BelongsToEdge(aBeam)).ToList();
        }

        private IEnumerable<Opening> GetOpeningsFromWall(Wall aWall)
        {
            return materials.GetOpenings().Where(opening => aWall.DoesContainComponent(opening));
        }

        private void AdjustIntersection(Point intersection)
        {
            Beam affectedBeam = new Beam(intersection);
            List<Wall> involvedWalls = GetWallsSharingBeam(affectedBeam);
            if (!involvedWalls.Any())
            {
                materials.RemoveBeam(affectedBeam);
            }
            else if (involvedWalls.Count == 2)
            {
                EvaluateMergingWalls(involvedWalls[0], involvedWalls[1]);
            }

        }

        private void EvaluateMergingWalls(Wall wall1, Wall wall2)
        {
            bool theyAreContinuous = wall1.IsCollinearContinuous(wall2);
            bool LengthsSumTheLimitOrLess = wall1.Length() + wall2.Length() <= Constants.MAX_WALL_LENGTH;
            if (theyAreContinuous && LengthsSumTheLimitOrLess)
            {
                MergeWalls(wall1, wall2);
            }
        }

        private void MergeWalls(Wall wall1, Wall wall2)
        {
            Point intersection;
            if (wall1.Beginning().Equals(wall2.Beginning()) || wall1.Beginning().Equals(wall2.End()))
            {
                intersection = wall1.Beginning();
            }
            else
            {
                intersection = wall1.End();
            }

            Wall newWall = wall1.MergeCollinearContinuous(wall2);
            materials.RemoveWall(wall1);
            materials.RemoveWall(wall2);
            RemoveBeamInPoint(intersection);
            materials.AddWall(newWall);

        }

        private void RemoveBeamInPoint(Point point)
        {
            Beam toRemove = new Beam(point);
            materials.RemoveBeam(toRemove);
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
            string strId = id.ToString();
            return "Name: " + Name + " "
                   + "Owner: " + Owner.UserName + " "
                   + "Id: " + strId.Substring(strId.Length - 5);
        }

       

    }
}
