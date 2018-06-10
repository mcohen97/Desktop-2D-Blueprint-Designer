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
        public BlueprintEntity BlueprintToEntiy(Blueprint toConvert) {
            UserAndEntityConverter userEntityConverter = new UserAndEntityConverter();
            BlueprintEntity conversion = new BlueprintEntity()
            {
                Name = toConvert.Name,
                Length = toConvert.Length,
                Width = toConvert.Width,
                Owner = userEntityConverter.toEntity(toConvert.Owner),
                Signatures = (ICollection<SignatureEntity>)toConvert.GetSignatures().Select(s=>SignatureToEntity(s))

            };
            return conversion;
        }

        public Blueprint EntityToBlueprint(BlueprintEntity toConvert) {
            UserAndEntityConverter userEntityConverter = new UserAndEntityConverter();
            User convertedUser  = userEntityConverter.toUser(toConvert.Owner);
            ICollection<Signature> convertedSignatures = (ICollection<Signature>)toConvert.Signatures.Select(s => EntityToSignature(s));
            Blueprint conversion = new Blueprint(toConvert.Length, toConvert.Width, toConvert.Name, convertedUser, convertedSignatures);
            return conversion;
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
