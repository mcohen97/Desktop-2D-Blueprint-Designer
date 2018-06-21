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
using System.Data.Common;
using BusinessDataExceptions;
using System.Data.Entity.Core;

namespace DataAccess
{
    public class BlueprintRepository : IRepository<IBlueprint>, IBlueprintRepository
    {
        public void Add(IBlueprint toStore)
        {
                BlueprintAndEntityConverter blueprintTranslator = new BlueprintAndEntityConverter();
                MaterialAndEntityConverter materialTranslator = new MaterialAndEntityConverter();
                BlueprintEntity converted = blueprintTranslator.BlueprintToEntiy(toStore);
                IEnumerable<ColumnEntity> convertedColumns = toStore.GetColumns().Select(c => materialTranslator.ColumnToEntity((Column)c, converted));
                IEnumerable<WallEntity> convertedWalls = toStore.GetWalls().Select(w => materialTranslator.WallToEntity(w, converted));
                IEnumerable<SignatureEntity> convertedSignatures = toStore.GetSignatures().Select(s => blueprintTranslator.SignatureToEntity(s, converted));
                ICollection<Opening> itsOpenings = toStore.GetOpenings();
            try
            {
                AddBlueprintEntity(converted, convertedWalls, convertedColumns, itsOpenings, convertedSignatures);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
        }

        private void AddBlueprintEntity(BlueprintEntity converted, IEnumerable<WallEntity> itsWalls,
                                  IEnumerable<ColumnEntity> itsColumns, ICollection<Opening> itsOpenings, IEnumerable<SignatureEntity> itsSignatures) {

         using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                context.Blueprints.Add(converted);
                UserEntity owner = converted.Owner;

                if (context.Users.Any(u => u.UserName.Equals(owner.UserName)))
                {
                    context.Entry(converted.Owner).State = EntityState.Unchanged;
                }

                context.Columns.AddRange(itsColumns);
                context.Walls.AddRange(itsWalls);
                context.Signatures.AddRange(itsSignatures);

                MaterialAndEntityConverter materialTranslator = new MaterialAndEntityConverter();
                foreach (Opening op in itsOpenings)
                {
                    string tempName = op.getTemplateName();
                    OpeningTemplateEntity itsTemplate = context.OpeningTemplates
                                        .FirstOrDefault(t => t.Name.Equals(tempName));
                    
                    OpeningEntity opRecord = materialTranslator.OpeningToEntity(op, itsTemplate, converted);
                    context.Openings.Add(opRecord);
                }
                context.SaveChanges();
            }
        }
        

        public void Clear()
        {
            try {
                TryToClear();
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
        }

        private void TryToClear() {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                foreach (SignatureEntity se in context.Signatures)
                {
                    context.Signatures.Remove(se);
                }
                foreach (BlueprintEntity bpe in context.Blueprints)
                {
                    context.Blueprints.Remove(bpe);
                }
                context.SaveChanges();
            }
        }

        public void Delete(IBlueprint toRemove)
        {
            try
            {
                TryToDelete(toRemove);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }   
        }

        private void TryToDelete(IBlueprint toRemove) {
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
            try
            {
                exists = TryAskingIfExists(asked);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return exists;
        }

        private bool TryAskingIfExists(IBlueprint asked) {
            bool exists;
            BlueprintAndEntityConverter translator = new BlueprintAndEntityConverter();
            BlueprintEntity toAsk = translator.BlueprintToEntiy(asked);
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                Guid askedId = asked.GetId();
                exists = context.Blueprints.Any(bp => bp.Id == askedId);
            }
            return exists;
        }

        public IBlueprint Get(IBlueprint copy)
        {
            return Get(copy.GetId());
        }

        public IBlueprint Get(Guid id)
        {
            IBlueprint queried;
            try
            {
                queried = TryGetting(id);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return queried;
        }

        private IBlueprint TryGetting(Guid id) {
            IBlueprint queried;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                BlueprintEntity record = context.Blueprints.Include(bp => bp.Owner).FirstOrDefault(bp => bp.Id.Equals(id));

                queried = BuildBlueprint(record);
            }
            return queried;
        }

        public ICollection<IBlueprint> GetAll()
        {
            ICollection<IBlueprint> themAll;
            try
            {
                themAll = TryGetAll();
            }
            catch (EntityException) {
                throw new InaccessibleDataException();
            }
            return themAll;
        }

        private ICollection<IBlueprint> TryGetAll() {
            ICollection<IBlueprint> converted = new List<IBlueprint>();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                foreach (BlueprintEntity be in context.Blueprints.Include(b => b.Owner))
                {
                    converted.Add(BuildBlueprint(be));
                }
            }
            return converted;

        }

        public bool IsEmpty()
        {
            bool isEmpty;
            try
            {
                isEmpty = TryAskIsEmpty();
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return isEmpty;
        }

        private bool TryAskIsEmpty() {
            bool isEmpty;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
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
            ICollection<IBlueprint> blueprints;
            try {
                blueprints = TryGettingBlueprintsOfUser(owner);
            }
            catch (EntityException)
            {
                throw new InaccessibleDataException();
            }
            return blueprints;
        }

        private ICollection<IBlueprint> TryGettingBlueprintsOfUser(User owner) {
            ICollection<IBlueprint> queriedBlueprints = new List<IBlueprint>();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                ICollection<BlueprintEntity> query = context.Blueprints.Include(bp => bp.Owner)
                    .Where(bp => bp.Owner.UserName.Equals(owner.UserName)).ToList();

                foreach (BlueprintEntity bpe in query)
                {
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
            try
            {
                TryDeletingBlueprintsOfUser(aUser);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
        }

        private void TryDeletingBlueprintsOfUser(User aUser) {
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
