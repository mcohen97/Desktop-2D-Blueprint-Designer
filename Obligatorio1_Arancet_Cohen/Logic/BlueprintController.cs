using System;
using System.Collections.Generic;

namespace Logic {
    public class BlueprintController {
        private Session session;

        public BlueprintController(Session session) {
            this.session = session;
        }

        public void Add(IBlueprint aBlueprint) {
            if (!session.UserLogged.HasPermission(Permission.CREATE_BLUEPRINT)) {
                throw new NoPermissionsException();
            }
            BlueprintPortfolio.Instance.Add(aBlueprint);
        }

        public bool Exist(IBlueprint aBlueprint) {
            if (!session.UserLogged.HasPermission(Permission.READ_BLUEPRINT)) {
                throw new NoPermissionsException();
            }
            return BlueprintPortfolio.Instance.Exist(aBlueprint);
        }

        public IEnumerator<IBlueprint> GetBlueprints(User aUser) {
            if (!session.UserLogged.HasPermission(Permission.READ_BLUEPRINT)) {
                throw new NoPermissionsException();
            }
            return BlueprintPortfolio.Instance.GetBlueprintsOfUser(aUser);
        }

        public IEnumerator<IBlueprint> GetBlueprints() {
            if (!session.UserLogged.HasPermission(Permission.READ_OWNEDBLUEPRINT)) {
                throw new NoPermissionsException();
            }
            return BlueprintPortfolio.Instance.GetEnumerator();
        }
    }
}