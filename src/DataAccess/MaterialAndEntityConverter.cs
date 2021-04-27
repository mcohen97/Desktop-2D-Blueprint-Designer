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
                BeginningX = toConvert.Beginning().CoordX,
                BeginningY = toConvert.Beginning().CoordY,
                EndX = toConvert.End().CoordX,
                EndY = toConvert.End().CoordY,
                Height = toConvert.Height(),
                Width = toConvert.Width(),
                BearerBlueprint = bearer
            };
            return conversion;
        }

        public Wall EntityToWall(WallEntity toConvert) {

            Point origin = new Point(toConvert.BeginningX, toConvert.BeginningY);
            Point end = new Point(toConvert.EndX, toConvert.EndY);
            return new Wall(origin, end);
        }

        public ColumnEntity ColumnToEntity(Column toConvert, BlueprintEntity blueprint) {

            ColumnEntity conversion = new ColumnEntity()
            {
                Width = toConvert.Width(),
                Height = toConvert.Height(),
                Length = toConvert.Length(),
                CoordX = toConvert.GetPosition().CoordX,
                CoordY = toConvert.GetPosition().CoordY,
                BearerBlueprint= blueprint
                
            };
            return conversion;
        }

        public Column EntityToColumn(ColumnEntity toConvert) {
            Point position = new Point(toConvert.CoordX, toConvert.CoordY);
            Column conversion = new Column(position);
            return conversion;
        }

        public OpeningEntity OpeningToEntity(Opening toConvert, OpeningTemplateEntity itsTemplate, BlueprintEntity bearer) {
            OpeningEntity conversion = new OpeningEntity()
            {
                CoordX= toConvert.GetPosition().CoordX,
                CoordY= toConvert.GetPosition().CoordY,
                Template = itsTemplate,
                BearerBlueprint= bearer
            };
            return conversion;
        }

        public Opening EntityToOpening(OpeningEntity toConvert) {

            Point pos = new Point(toConvert.CoordX,toConvert.CoordY);
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
                Name = toConvert.Name,
                ComponentType = (int)toConvert.Type
                
            };
            return conversion;
        }

        public OpeningTemplateEntity GetTemplateFromOpening(Opening anOpening) {
            OpeningTemplateEntity extracted = new OpeningTemplateEntity()
            {
                Name = anOpening.getTemplateName(),
                Height = anOpening.HeightAboveFloor(),
                Length = anOpening.Length(),
                HeightAboveFloor = anOpening.HeightAboveFloor(),
                ComponentType = (int)anOpening.GetComponentType()

            };
            return extracted;
        }

        public Template EntityToOpeningTemplate(OpeningTemplateEntity toConvert) {
            Template conversion = new Template(toConvert.Name,
                toConvert.Length, toConvert.HeightAboveFloor, toConvert.Height, 
                (ComponentType)toConvert.ComponentType);

            return conversion;
        }



    }
}
