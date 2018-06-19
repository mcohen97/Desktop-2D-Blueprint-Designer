using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicExceptions;

namespace Logic.Domain
{
    class PunctualComponentPositioner
    {
        private MaterialContainer materials;
        private float Length;
        private float Width;

        public PunctualComponentPositioner(MaterialContainer blueprintMaterials, float aWidth, float aLength)
        {
            materials = blueprintMaterials;
            Length = aLength;
            Width = aWidth;
        }

        public void InsertOpening(Opening newOpening)
        {
            if (!PunctualComponentInRange(newOpening))
            {
                throw new OutOfRangeComponentException();
            }
            else
            {
                
                bool belongsToWall = BelongsToAWall(newOpening);
                if (!belongsToWall) {
                    throw new ComponentOutOfWallException();
                } else if (!OccupiedPosition(newOpening) && FitsInItsWall(newOpening)) {

                    materials.AddOpening(newOpening);
                }
            }
        }

        private bool FitsInItsWall(Opening newOpening) {
            Wall itsWall = materials.GetWalls().FirstOrDefault(w => w.DoesContainComponent(newOpening));
            Wall pieceThatWouldOccupy = PieceOfOccupiedWall(newOpening, itsWall);

            bool fits = false;

            if (!OutOfWallBorder(pieceThatWouldOccupy,itsWall)) {
                ICollection<Opening> thatWallsOpenings = materials.GetOpenings().Where(o => itsWall.DoesContainComponent(o)).ToList();
                fits= !thatWallsOpenings.Any(o => PieceOfOccupiedWall(o, itsWall).Overlaps(pieceThatWouldOccupy));
            }
            return fits;           
        }

        private bool OutOfWallBorder(Wall occupied, Wall entire) {
            return occupied.DoesContainPoint(entire.Beginning()) || occupied.DoesContainPoint(entire.End());
        }

        //this method uses vector algebra to get the piece of wall ocuppied by an opening
        private Wall PieceOfOccupiedWall(Opening anOpening, Wall itsWall) {
            float opLength = anOpening.Length();
            Point beginning = itsWall.Beginning();
            Point end = itsWall.End();
            Point positiveVector = beginning - end;
            Point negativeVector = end - beginning;
            Point beginningOfPiece = anOpening.GetPosition().PointInSameLineAtSomeDistance(negativeVector,opLength/2);
            Point endOfPiece= anOpening.GetPosition().PointInSameLineAtSomeDistance(positiveVector, opLength/2);
            Wall piece = new Wall(beginningOfPiece, endOfPiece);
            return piece;
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

        private bool PunctualComponentInRange(ISinglePointComponent newComponent)
        {
            return PointInRange(newComponent.GetPosition());
        }

        private bool PointInRange(Point aPoint)
        {
            return aPoint.IsInRange(Length, Width);
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

        public void RemoveOpening(Opening anOpening)
        {
            if (materials.ContainsOpening(anOpening))
            {
                materials.RemoveOpening(anOpening);
            }
        }

        public void RemoveOpening(Point position)
        {
            bool exists = materials.GetOpenings().Any(o => o.GetPosition().Equals(position));
            if (exists)
            {
                Opening op = materials.GetOpenings().First(o => o.GetPosition().Equals(position));
                materials.RemoveOpening(op);
            }
        }

        public void RemoveOpeningsOfWall(Wall aWall)
        {
            foreach (Opening existing in GetOpeningsFromWall(aWall))
            {
                materials.RemoveOpening(existing);
            }
        }

        private IEnumerable<Opening> GetOpeningsFromWall(Wall aWall)
        {
            return materials.GetOpenings().Where(opening => aWall.DoesContainComponent(opening));
        }

        public void RemoveColumn(Point columnPosition)
        {
            if (materials.GetColumns().Any(c => c.GetPosition().Equals(columnPosition)))
            {
                ISinglePointComponent toDelete = materials.GetColumns().First(c => c.GetPosition().Equals(columnPosition));
                materials.RemoveColumn(toDelete);
            }
        }
        
    }
}
