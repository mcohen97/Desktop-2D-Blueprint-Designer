using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

[assembly: InternalsVisibleTo("SystemUsersTest")]

namespace Logic {
    internal class BlueprintPortfolio {

        private static BlueprintPortfolio instance;
        private ICollection<IBlueprint> Blueprints;

        public static BlueprintPortfolio Instance {
            get {
                if (instance == null) {
                    instance = new BlueprintPortfolio();
                }
                return instance;
            }
        }


        private BlueprintPortfolio() {
            Blueprints = new List<IBlueprint>();
        }

        public void Empty() {
            Blueprints = new List<IBlueprint>();
        }

        public bool IsEmpty() {
            return Blueprints.Count() == 0;
        }

        public void Add(IBlueprint aBlueprint) {
            Blueprints.Add(aBlueprint);
        }

        public bool Exist(IBlueprint aBlueprint) {
            if(aBlueprint == null) {
                throw new ArgumentNullException();
            }
            return Blueprints.Contains(aBlueprint);
        }

        public IEnumerator<IBlueprint> GetEnumerator() {
            return Blueprints.GetEnumerator();
        }

        public bool Remove(IBlueprint aBlueprint) {
            if(aBlueprint == null) {
                throw new ArgumentNullException();
            }
            return Blueprints.Remove(aBlueprint);
        }

        public IBlueprint GetBlueprint(IBlueprint aBlueprint) {
            if(aBlueprint == null) {
                throw new ArgumentNullException();
            }
            return Blueprints.First(x => aBlueprint.Equals(x));
        }
    }
}