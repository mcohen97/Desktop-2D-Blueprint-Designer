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


        public WallEntity WallToEntity(Wall toConvert, BlueprintEntity bearer) {

            WallEntity conversion = new WallEntity()
            {
                From = PointToEntity(toConvert.Beginning()),
                To = PointToEntity(toConvert.End()),
                Height = toConvert.Height(),
                Width = toConvert.Width(),
                BearerBlueprint = bearer
            };
            return conversion;
        }

        public Wall EntityToWall(WallEntity toConvert) {

            Point origin = EntityToPoint(toConvert.From);
            Point end = EntityToPoint(toConvert.To);
            return new Wall(origin, end);
        }

        public ColumnEntity ColumnToEntity(Column toConvert) {

            ColumnEntity conversion = new ColumnEntity()
            {
                Width = toConvert.Width(),
                Height = toConvert.Height(),
                Length = toConvert.Length(),
                Position = PointToEntity(toConvert.GetPosition())
            };
            return conversion;
        }

        public Column EntityToColumn(ColumnEntity toConvert) {
            Point position = EntityToPoint(toConvert.Position);
            Column conversion = new Column(position);
            return conversion;
        }

        public OpeningEntity OpeningToEntity(Opening toConvert, OpeningTemplateEntity itsTemplate, BlueprintEntity bearer) {
            OpeningEntity conversion = new OpeningEntity()
            {
                Position = PointToEntity(toConvert.GetPosition()),
                Template = itsTemplate,
                BearerBlueprint= bearer
            };
            return conversion;
        }

        public Opening EntityToOpening(OpeningEntity toConvert) {

            Point pos = EntityToPoint(toConvert.Position);
            Template temp = EntityToOpeningTemplate(toConvert.Template);

            Opening conversion;
            switch (toConvert.Template.ComponentType) {
                case ((int)ComponentType.DOOR):
                    conversion = new Door(pos, temp);
                    break;
                case ((int)ComponentType.WINDOW):
                    conversion = new Window(pos, temp);
                    break;
                default:
                    throw new Exception();
                 break;
            }
            return conversion;
        }


        public OpeningTemplateEntity OpeningTemplateToEntity(Template toConvert) {
            OpeningTemplateEntity conversion = new OpeningTemplateEntity()
            {
                Height = toConvert.Height,
                Length = toConvert.Length,
                HeightAboveFloor = toConvert.HeightAboveFloor,
            };
            return conversion;
        }

        public Template EntityToOpeningTemplate(OpeningTemplateEntity toConvert) {
            Template conversion = new Template(toConvert.Name,
                toConvert.Length, toConvert.Height, toConvert.Height, 
                (ComponentType)toConvert.ComponentType);

            return conversion;
        }

        

        private PointEntity PointToEntity(Point toConvert)
        {
            PointEntity conversion = new PointEntity()
            {
                CoordX = toConvert.CoordX,
                CoordY = toConvert.CoordY
            };
            return conversion;
        }

        private Point EntityToPoint(PointEntity toConvert)
        {
            return new Point(toConvert.CoordX, toConvert.CoordY);
        }


    }
}
