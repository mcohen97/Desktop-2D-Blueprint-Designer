﻿using System;
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
                UserEntity owner = converted.Owner;

                if (context.Users.Any(u=>u.UserName.Equals(owner.UserName)))
                {
                    context.Entry(converted.Owner).State = EntityState.Unchanged;
                }
                else {
                    context.Entry(converted.Owner).State = EntityState.Added;
                }

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
            if (Exists(toRemove))
            {
                BlueprintAndEntityConverter translator = new BlueprintAndEntityConverter();
                BlueprintEntity converted = translator.BlueprintToEntiy(toRemove);

                using (BlueBuilderDBContext context = new BlueBuilderDBContext())
                {
                    foreach (WallEntity we in context.Walls)
                    {
                        if (we.BearerBlueprint.Equals(converted))
                        {
                            context.Walls.Remove(we);
                        }
                    }
                    foreach (OpeningEntity oe in context.Openings)
                    {
                        if (oe.BearerBlueprint.Equals(converted))
                        {
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
                    context.Blueprints.Attach(converted);
                    context.Blueprints.Remove(converted);
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
                BlueprintEntity record = context.Blueprints.Include(bp=>bp.Owner)
                    .Include(bp=>bp.Signatures).FirstOrDefault(bp => bp.Id.Equals(id));

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
                foreach (BlueprintEntity be in context.Blueprints.Include(b=> b.Owner).Include(b=> b.Signatures)) {
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
            ICollection<IBlueprint> queriedBlueprints = new List<IBlueprint>();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                ICollection<BlueprintEntity> query = context.Blueprints.Include(bp=> bp.Owner)
                    .Include(bp=>bp.Signatures).Where(bp=> bp.Owner.UserName.Equals(owner.UserName)).ToList();

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
                openEnts = context.Openings.Where(we => we.BearerBlueprint.Id== blueprint.Id).ToList();
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
