using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;
using DomainRepositoryInterface;
using RepositoryInterface;
using Entities;
using System.Data.Entity;

namespace DataAccess
{
    public class BlueprintRepository : IRepository<IBlueprint>, IBlueprintRepository
    {
        public void Add(IBlueprint toStore)
        {
            
                //instantiate the translators.
                BlueprintAndEntityConverter blueprintTranslator = new BlueprintAndEntityConverter();
                MaterialAndEntityConverter materialTranslator = new MaterialAndEntityConverter();

                //translate and add the blueprint.
                BlueprintEntity converted = blueprintTranslator.BlueprintToEntiy(toStore);
             using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.Blueprints.Add(converted);
                UserEntity owner = converted.Owner;

                if (context.Users.Any(u=>u.UserName.Equals(owner.UserName)))
                {
                    context.Entry(converted.Owner).State = EntityState.Unchanged;
                }
                else {
                    context.Entry(converted.Owner).State = EntityState.Added;
                }

                IEnumerable<ColumnEntity> convertedColumns = toStore.GetColumns().Select(c=> materialTranslator.ColumnToEntity((Column)c,converted));
                context.Columns.AddRange(convertedColumns);

                //translate and add its walls.
                IEnumerable<WallEntity> convertedWalls = toStore.GetWalls().Select(w => materialTranslator.WallToEntity(w,converted));
                context.Walls.AddRange(convertedWalls);

                IEnumerable<SignatureEntity> convertedSignatures = toStore.GetSignatures().Select(s => blueprintTranslator.SignatureToEntity(s, converted));
                context.Signatures.AddRange(convertedSignatures);
                /*foreach (SignatureEntity se in convertedSignatures) {
                    context.Signatures.Add(se);
                    if (context.Users.Any(u => u.UserName == se.SignerUserName)){
                        context.Entry(se.Signer).State = EntityState.Modified;
                    }
                }*/
                

            foreach (Opening op in toStore.GetOpenings()) {
                    string tempName = op.getTemplateName();
                    OpeningTemplateEntity itsTemplate = context.OpeningTemplates
                            .FirstOrDefault(t => t.Name.Equals(tempName));
                    OpeningEntity opRecord=materialTranslator.OpeningToEntity(op, itsTemplate, converted);
                    context.Openings.Add(opRecord);
            }
                context.SaveChanges();
            }
           
        }

        public void Clear()
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                foreach (SignatureEntity se in context.Signatures) {
                    context.Signatures.Remove(se);
                }
                foreach (BlueprintEntity bpe in context.Blueprints) {
                    context.Blueprints.Remove(bpe);
                }
                context.SaveChanges();
            }
        }

        public void Delete(IBlueprint toRemove)
        {
            if (Exists(toRemove))
            {
                BlueprintAndEntityConverter translator = new BlueprintAndEntityConverter();
                BlueprintEntity converted = translator.BlueprintToEntiy(toRemove);

                using (BlueBuilderDBContext context = new BlueBuilderDBContext())
                {
                    Guid removeId = toRemove.GetId();
                    BlueprintEntity record = context.Blueprints.FirstOrDefault(be => be.Id == removeId);
                    context.Blueprints.Remove(record);
                    context.SaveChanges();
                }
            }
        }

        public bool Exists(IBlueprint asked)
        {
            bool exists;
            BlueprintAndEntityConverter translator = new BlueprintAndEntityConverter();
            BlueprintEntity toAsk = translator.BlueprintToEntiy(asked);
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                Guid askedId = asked.GetId();
                exists = context.Blueprints.Any(bp => bp.Id==askedId);
            }
            return exists;
        }

        public IBlueprint Get(Guid id)
        {
            IBlueprint queried;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                BlueprintEntity record = context.Blueprints.Include(bp=>bp.Owner).FirstOrDefault(bp => bp.Id.Equals(id));

                queried = BuildBlueprint(record);                 
            }
            return queried;
        }

        public IBlueprint Get(IBlueprint copy) {
            return Get(copy.GetId());
        }

        public ICollection<IBlueprint> GetAll()
        {
            ICollection<IBlueprint> converted = new List<IBlueprint>();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                foreach (BlueprintEntity be in context.Blueprints.Include(b=> b.Owner)) {
                    converted.Add(BuildBlueprint(be));
                }
            }
            return converted;
        }

        public bool IsEmpty()
        {
            bool isEmpty;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                isEmpty = !context.Blueprints.Any();
            }
            return isEmpty;
        }

        public void Modify(IBlueprint entity)
        {
            Delete(entity);
            Add(entity);
          
        }

        public ICollection<IBlueprint> GetBlueprintsOfUser(User owner)
        {
            ICollection<IBlueprint> queriedBlueprints = new List<IBlueprint>();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                ICollection<BlueprintEntity> query = context.Blueprints.Include(bp=> bp.Owner)
                    .Where(bp=> bp.Owner.UserName.Equals(owner.UserName)).ToList();

                foreach (BlueprintEntity bpe in query) {
                    queriedBlueprints.Add(BuildBlueprint(bpe));
                }
            }
            return queriedBlueprints;
        }

        private IBlueprint BuildBlueprint(BlueprintEntity blueprint) {
            BlueprintAndEntityConverter converter = new BlueprintAndEntityConverter();
            ICollection<WallEntity> wallEnts;
            ICollection<OpeningEntity> openEnts;
            ICollection<ColumnEntity> colEnts;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {

                wallEnts = context.Walls.Where(we => we.BearerBlueprint.Id == blueprint.Id).ToList();
                openEnts = context.Openings.Include(o => o.Template).Where(we => we.BearerBlueprint.Id== blueprint.Id).ToList();
                colEnts = context.Columns.Where(ce => ce.BearerBlueprint.Id== blueprint.Id).ToList();
            }
            IBlueprint builtBlueprint =converter.EntityToBlueprint(blueprint, wallEnts, openEnts, colEnts);
            return builtBlueprint;
        }

        public void DeleteUserBlueprints(User aUser)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                foreach (BlueprintEntity bpEnt in context.Blueprints.Where(bp => bp.Owner.UserName.Equals(aUser.UserName)))
                {
                    context.Blueprints.Remove(bpEnt);
                }
                context.SaveChanges();

            }
        }
    }
}
