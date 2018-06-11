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
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                //instantiate the translators.
                BlueprintAndEntityConverter blueprintTranslator = new BlueprintAndEntityConverter();
                MaterialAndEntityConverter materialTranslator = new MaterialAndEntityConverter();
                //translate and add the blueprint.
                BlueprintEntity converted = blueprintTranslator.BlueprintToEntiy(toStore);
                context.Blueprints.Add(converted);
                //translate and add its walls.
                IEnumerable<WallEntity> convertedWalls = toStore.GetWalls().Select(w => materialTranslator.WallToEntity(w,converted));
                context.Walls.AddRange(convertedWalls);
                //translate and add its openings.
                IEnumerable<OpeningEntity> convertedOpenings = toStore.GetOpenings().Select(o => CreateOpeningEntity(o,materialTranslator,converted));
                context.Openings.AddRange(convertedOpenings);
                
                context.SaveChanges();
            }
        }

        private OpeningEntity CreateOpeningEntity(Opening o, MaterialAndEntityConverter materialTranslator,BlueprintEntity bearer) {
            string tempName = o.getTemplateName();
            OpeningTemplateEntity temp;

            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
               temp= context.OpeningTemplates.FirstOrDefault(t => t.Name.Equals(tempName));
            }

            return materialTranslator.OpeningToEntity(o, temp,bearer);

        }

        public void Clear()
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                foreach (WallEntity we in context.Walls) {
                    context.Walls.Remove(we);
                }
                foreach (OpeningEntity oe in context.Openings) {
                    context.Openings.Remove(oe);
                }
                foreach (ColumnEntity ce in context.Columns)
                {
                    context.Columns.Remove(ce);
                }
                foreach (BlueprintEntity bpe in context.Blueprints) {
                    context.Blueprints.Remove(bpe);
                }
                context.SaveChanges();
            }
        }

        public void Delete(IBlueprint toRemove)
        {
            BlueprintAndEntityConverter translator = new BlueprintAndEntityConverter();
            BlueprintEntity converted = translator.BlueprintToEntiy(toRemove);

            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                foreach (WallEntity we in context.Walls) {
                    if (we.BearerBlueprint.Equals(converted)) {
                        context.Walls.Remove(we);
                    }
                }
                foreach (OpeningEntity oe in context.Openings) {
                    if (oe.BearerBlueprint.Equals(converted)) {
                        context.Openings.Remove(oe);
                    }
                }
                foreach (ColumnEntity ce in context.Columns)
                {
                    if (ce.BearerBlueprint.Equals(converted))
                    {
                        context.Columns.Remove(ce);
                    }
                }
                context.Blueprints.Remove(converted);
            }
        }

        public bool Exists(IBlueprint asked)
        {
            bool exists;
            BlueprintAndEntityConverter translator = new BlueprintAndEntityConverter();
            BlueprintEntity toAsk = translator.BlueprintToEntiy(asked);
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                exists = context.Blueprints.Contains(toAsk);
            }
            return exists;
        }

        public Blueprint Get(Guid id)
        {
            Blueprint queried;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                BlueprintEntity record = context.Blueprints.FirstOrDefault(bp => bp.Id.Equals(id));
                queried = BuildBlueprint(record, context);                 
            }
            return queried;
        }


        public ICollection<IBlueprint> GetAll()
        {
            ICollection<IBlueprint> converted;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                converted=(ICollection<Blueprint>)context.Blueprints.Select(be => BuildBlueprint(be, context));
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
            BlueprintAndEntityConverter translator = new BlueprintAndEntityConverter();
            BlueprintEntity bpEnt = translator.BlueprintToEntiy(entity);

            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                context.Entry(bpEnt).State = EntityState.Modified;
                context.Entry(bpEnt.Owner).State = EntityState.Modified;
                foreach (SignatureEntity signature in bpEnt.Signatures) {
                    context.Entry(signature).State = signature.Id.Equals(Guid.Empty) ? EntityState.Added : EntityState.Unchanged;
                }
                context.SaveChanges();
            }
          
        }

        public ICollection<IBlueprint> GetBlueprintsOfUser(User owner)
        {
            ICollection<IBlueprint> queriedBlueprints;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                IEnumerable<BlueprintEntity> query = context.Blueprints.Where(bp=> bp.Owner.Equals(owner));
                queriedBlueprints = (ICollection<IBlueprint>)query.Select(bp => BuildBlueprint(bp, context));
            }
            return queriedBlueprints;
        }

        private Blueprint BuildBlueprint(BlueprintEntity blueprint, BlueBuilderDBContext context) {
            BlueprintAndEntityConverter converter = new BlueprintAndEntityConverter();

            ICollection<WallEntity> wallEnts = (ICollection<WallEntity>)context.Walls.Where(we => we.BearerBlueprint.Equals(blueprint));
            ICollection<OpeningEntity> openEnts = (ICollection<OpeningEntity>)context.Openings.Where(we => we.BearerBlueprint.Equals(blueprint));
            ICollection<ColumnEntity> colEnts = (ICollection<ColumnEntity>)context.Columns.Where(ce => ce.BearerBlueprint.Equals(blueprint));

            Blueprint builtBlueprint =converter.EntityToBlueprint(blueprint, wallEnts, openEnts, colEnts);
            return builtBlueprint;

        }

        public void DeleteUserBlueprints(Client aUser)
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
