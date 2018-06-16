using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Logic.Domain;


namespace DataAccess
{
    public class BlueprintAndEntityConverter
    {
        public BlueprintEntity BlueprintToEntiy(IBlueprint toConvert) {
            UserAndEntityConverter userEntityConverter = new UserAndEntityConverter();

            ICollection<SignatureEntity> signatures = toConvert.GetSignatures().Select(s => SignatureToEntity(s)).ToList();

            BlueprintEntity conversion = new BlueprintEntity()
            {
                Name = toConvert.Name,
                Length = toConvert.Length,
                Width = toConvert.Width,
                Owner = userEntityConverter.toEntity(toConvert.Owner),
                Signatures = signatures,
                Id = toConvert.GetId()

            };
            return conversion;
        }

        public IBlueprint EntityToBlueprint(BlueprintEntity toConvert, ICollection<WallEntity> wallEnts, ICollection<OpeningEntity> openEnts, ICollection<ColumnEntity> colEnts) {
            UserAndEntityConverter userEntityConverter = new UserAndEntityConverter();

            User convertedUser  = userEntityConverter.toUser(toConvert.Owner);
            ICollection<Signature> convertedSignatures = toConvert.Signatures.Select(s => EntityToSignature(s)).ToList();
            MaterialContainer materials = BuildUpContainer(wallEnts, openEnts, colEnts);

            IBlueprint conversion = new Blueprint(toConvert.Length, toConvert.Width, toConvert.Name, convertedUser,materials, convertedSignatures,toConvert.Id);
            return conversion;
        }

        private MaterialContainer BuildUpContainer(ICollection<WallEntity> wallEnts, ICollection<OpeningEntity> openEnts, ICollection<ColumnEntity> colEnts) {
            MaterialAndEntityConverter translator = new MaterialAndEntityConverter();

            ICollection<Wall> walls = wallEnts.Select(w => translator.EntityToWall(w)).ToList();
            ICollection<Opening> openings = openEnts.Select(o => translator.EntityToOpening(o)).ToList();
            ICollection<ISinglePointComponent> columns = colEnts.Select(c => (ISinglePointComponent)translator.EntityToColumn(c)).ToList();
            MaterialContainer container = new MaterialContainer(walls, openings, columns);
            return container;

        }

        public SignatureEntity SignatureToEntity(Signature toConvert) {

            UserAndEntityConverter userEntityConverter = new UserAndEntityConverter();

            SignatureEntity conversion = new SignatureEntity()
            {
                Signer = userEntityConverter.toEntity(toConvert.Signer),
                SignatureDate = toConvert.Date
            };

            return conversion;
        }

        public Signature EntityToSignature(SignatureEntity toConvert) {

            UserAndEntityConverter userEntityConverter = new UserAndEntityConverter();

            Signature conversion = new Signature(userEntityConverter.toUser(toConvert.Signer), toConvert.SignatureDate);
            return conversion;

        }


    }
}
