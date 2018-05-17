using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Domain
{
    public class MaterialContainer
    {

        private ICollection<Wall> walls;
        private ICollection<Beam> beams;
        private ICollection<Opening> openings;

        public MaterialContainer()
        {
            walls = new List<Wall>();
            beams = new List<Beam>();
            openings = new List<Opening>();
        }

        public bool IsWallsEmpty()
        {
            return walls.Count == 0;//couln't find anything like isEmpty();
        }

        public bool IsBeamsEmpty()
        {
            return beams.Count == 0;
        }

        public bool IsOpeningsEmpty()
        {
            return openings.Count == 0;
        }

        public void AddWall(Wall aWall)
        {
            if (aWall == null)
            {
                throw new ArgumentNullException();
            }
            walls.Add(aWall);

        }


        public void AddBeam(Beam aBeam)
        {
            if (aBeam == null)
            {
                throw new ArgumentNullException();
            }
            beams.Add(aBeam);
        }

        public void AddOpening(Opening anOpening)
        {
            if (anOpening == null)
            {
                throw new ArgumentNullException();
            }
            openings.Add(anOpening);
        }

        public int WallsCount()
        {
            return walls.Count;
        }

        public int BeamsCount()
        {
            return beams.Count;
        }


        public int OpeningsCount()
        {
            return openings.Count;
        }

        public void RemoveWall(Wall aWall)
        {
            if (aWall == null)
            {
                throw new ArgumentNullException();
            }
            walls.Remove(aWall);
        }

        public void RemoveBeam(Beam aBeam)
        {
            if (aBeam == null)
            {
                throw new ArgumentNullException();
            }
            beams.Remove(aBeam);
        }

        public void RemoveOpening(Opening anOpening)
        {
            if (anOpening == null)
            {
                throw new ArgumentNullException();
            }
            openings.Remove(anOpening);
        }

        public ICollection<Wall> GetWalls()
        {
            return new List<Wall>(walls);
        }

        public ICollection<Beam> GetBeams()
        {
            return new List<Beam>(beams);
        }

        public ICollection<Opening> GetOpenings()
        {

            return new List<Opening>(openings);

        }

        public bool ContainsWall(Wall aWall)
        {
            if (aWall == null)
            {
                throw new ArgumentNullException();
            }
            return walls.Contains(aWall);
        }

        public bool ContainsBeam(Beam aBeam)
        {
            if (aBeam == null)
            {
                throw new ArgumentNullException();
            }
            return beams.Contains(aBeam);
        }

        public bool ContainsOpening(Opening anOpening)
        {
            if (anOpening == null)
            {
                throw new ArgumentNullException();
            }
            return openings.Contains(anOpening);
        }

        public ICollection GetPriceables()
        {
            ICollection<IPriceable> wallsAsPriceables = new List<IPriceable>(walls);
            ICollection<IPriceable> doorsAsPriceables = new List<IPriceable>(walls);
            ICollection<IPriceable> openingsAsPriceables = new List<IPriceable>(walls);

            return (ICollection)wallsAsPriceables.Concat(doorsAsPriceables.Concat(openings));
        }
    }
}