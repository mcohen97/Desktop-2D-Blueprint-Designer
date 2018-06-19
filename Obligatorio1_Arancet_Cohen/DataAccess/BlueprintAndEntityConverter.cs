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
            BlueprintEntity conversion = new BlueprintEntity()
            {
                Name = toConvert.Name,
                Length = toConvert.Length,
                Width = toConvert.Width,
                Owner = userEntityConverter.toEntity(toConvert.Owner),
                Id = toConvert.GetId()

            };
            return conversion;
        }

        public IBlueprint EntityToBlueprint(BlueprintEntity toConvert, ICollection<WallEntity> wallEnts, ICollection<OpeningEntity> openEnts, ICollection<ColumnEntity> colEnts) {
            UserAndEntityConverter userEntityConverter = new UserAndEntityConverter();

            User convertedUser  = userEntityConverter.toUser(toConvert.Owner);
            ICollection<Signature> convertedSignatures = GetBlueprintSignatures(toConvert);
               
            MaterialContainer materials = BuildUpContainer(wallEnts, openEnts, colEnts);

            IBlueprint conversion = new Blueprint(toConvert.Length, toConvert.Width, toConvert.Name, convertedUser,materials, convertedSignatures,toConvert.Id);
            return conversion;
        }

        private ICollection<Signature> GetBlueprintSignatures(BlueprintEntity toConvert) {
            ICollection<Signature> signatures = new List<Signature>();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                IEnumerable<SignatureEntity> queriedSignatures = context.Signatures.Where(se => se.BlueprintSigned.Id == toConvert.Id);
                foreach (SignatureEntity se in queriedSignatures) {
                    signatures.Add(EntityToSignature(se));
                }
           }
            return signatures;
        }

        private MaterialContainer BuildUpContainer(ICollection<WallEntity> wallEnts, ICollection<OpeningEntity> openEnts, ICollection<ColumnEntity> colEnts) {
            MaterialAndEntityConverter translator = new MaterialAndEntityConverter();

            ICollection<Wall> walls = wallEnts.Select(w => translator.EntityToWall(w)).ToList();
            ICollection<Opening> openings = openEnts.Select(o => translator.EntityToOpening(o)).ToList();
            ICollection<ISinglePointComponent> columns = colEnts.Select(c => (ISinglePointComponent)translator.EntityToColumn(c)).ToList();
            MaterialContainer container = new MaterialContainer(walls, openings, columns);
            return container;

        }

        public SignatureEntity SignatureToEntity(Signature toConvert, BlueprintEntity bearer) {

            UserAndEntityConverter userEntityConverter = new UserAndEntityConverter();

            SignatureEntity conversion = new SignatureEntity()
            {
                SignerName = toConvert.ArchitectName,
                SignerSurname= toConvert.ArchitectSurname,
                SignerUserName=toConvert.ArchitectUserName,
                SignatureDate = toConvert.Date,
                BlueprintSigned = bearer
            };

            return conversion;
        }

        public Signature EntityToSignature(SignatureEntity toConvert) {

            UserAndEntityConverter userEntityConverter = new UserAndEntityConverter();
            Architect dataTransfer = new Architect(toConvert.SignerName, toConvert.SignerSurname, toConvert.SignerUserName, "irrelevant", DateTime.Now);
            Signature conversion = new Signature(dataTransfer, toConvert.SignatureDate);
            return conversion;

        }


    }
}
