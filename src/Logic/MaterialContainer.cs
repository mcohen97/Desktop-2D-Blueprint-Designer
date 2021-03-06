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
        private ICollection<ISinglePointComponent> columns;

        public MaterialContainer()
        {
            walls = new List<Wall>();
            beams = new List<Beam>();
            openings = new List<Opening>();
            columns = new List<ISinglePointComponent>();
        }

        public MaterialContainer(ICollection<Wall> wallsSet,ICollection<Opening> openingsSet, ICollection<ISinglePointComponent> columnsSet) {
            walls = wallsSet;
            openings = openingsSet;
            columns = columnsSet;
            beams = new List<Beam>();
            Beam toAdd;
            foreach (Wall w in walls) {
                toAdd = new Beam(w.Beginning());
                if (!ContainsBeam(toAdd)) {
                    beams.Add(toAdd);
                }
                toAdd = new Beam(w.End());
                if (!ContainsBeam(toAdd))
                {
                    beams.Add(toAdd);
                }
            }
        }

        public bool IsWallsEmpty()
        {
            return walls.Count == 0;
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

        public bool IsColumnsEmpty()
        {
            return columns.Count == 0;
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

        public bool ContainsColumn(ISinglePointComponent aColumn)
        {
            return columns.Contains(aColumn);
        }

        public void AddColumn(ISinglePointComponent aColumn)
        {
            if(aColumn == null)
            {
                throw new ArgumentNullException();
            }
            columns.Add(aColumn);
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

        public ICollection<ISinglePointComponent> GetColumns()
        {
            return new List<ISinglePointComponent>(columns);
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

        public void RemoveColumn(ISinglePointComponent aColumn)
        {
            if (aColumn == null)
            {
                throw new ArgumentNullException();
            }

            columns.Remove(aColumn);
        }

    }
}