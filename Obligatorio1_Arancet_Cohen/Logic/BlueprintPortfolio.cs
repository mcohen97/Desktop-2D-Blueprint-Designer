using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

[assembly: InternalsVisibleTo("SystemUsersTest")]

namespace Logic.Domain
{
    public class BlueprintPortfolio
    {

        private static BlueprintPortfolio instance;
        private ICollection<IBlueprint> Blueprints;

        public static BlueprintPortfolio Instance {
            get {
                if (instance == null)
                {
                    instance = new BlueprintPortfolio();
                }
                return instance;
            }
        }

        private BlueprintPortfolio()
        {
            Blueprints = new List<IBlueprint>();
        }

        public void Clear()
        {
            Blueprints = new List<IBlueprint>();
        }

        public bool IsEmpty()
        {
            return Blueprints.Count() == 0;
        }

        public void Add(IBlueprint aBlueprint)
        {
            Blueprints.Add(aBlueprint);
        }

        public bool Exists(IBlueprint aBlueprint)
        {
            if (aBlueprint == null)
            {
                throw new ArgumentNullException();
            }
            return Blueprints.Contains(aBlueprint);
        }

        public ICollection<IBlueprint> GetBlueprintsCopy()
        {
            return new List<IBlueprint>(Blueprints);
        }

        public bool Delete(IBlueprint aBlueprint)
        {
            if (aBlueprint == null)
            {
                throw new ArgumentNullException();
            }
            return Blueprints.Remove(aBlueprint);
        }

        public IBlueprint Get(IBlueprint aBlueprint)
        {
            if (aBlueprint == null)
            {
                throw new ArgumentNullException();
            }
            return Blueprints.First(x => aBlueprint.Equals(x));
        }

        public ICollection<IBlueprint> GetBlueprintsOfUser(User owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException();
            }
            List<IBlueprint> elegible = Blueprints.Where(x => owner.Equals(x.Owner)).ToList();
            return new List<IBlueprint>(elegible);
        }

        internal void DeleteUserBlueprints(Client aUser)
        {
            foreach (IBlueprint existent in GetBlueprintsCopy())
            {
                if (existent.Owner.Equals(aUser))
                {
                    Blueprints.Remove(existent);
                }
            }
        }
    }
}