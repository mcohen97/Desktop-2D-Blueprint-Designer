using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Logic.Domain;

namespace DataAccess
{
    class MaterialAndEntityConverter
    {
        public PointEntity PointToEntity(Point toConvert) {
            PointEntity conversion = new PointEntity()
            {
                CoordX = toConvert.CoordX,
                CoordY = toConvert.CoordY
            };
            return conversion;
        }

        public Point EntityToPoint(PointEntity toConvert) {
            return new Point(toConvert.CoordX, toConvert.CoordY);
        }

        public WallEntity WallToEntity(Wall toConvert) {
            WallEntity conversion = new WallEntity()
            {
                From = PointToEntity(toConvert.Beginning()),
                To = PointToEntity(toConvert.End()),
                Height = toConvert.Height(),
                Width = toConvert.Width()
            };
            return conversion;
        }

        public Wall EntityToWall(WallEntity toConvert) {

            Point origin = EntityToPoint(toConvert.From);
            Point end = EntityToPoint(toConvert.To);
            return new Wall(origin,end);
        }

    }
}
