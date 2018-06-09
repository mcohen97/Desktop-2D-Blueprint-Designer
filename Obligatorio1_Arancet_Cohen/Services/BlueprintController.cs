using System;
using System.Collections.Generic;
using Logic.Exceptions;
using Logic.Domain;
using DataAccess;

namespace Services
{
    public class BlueprintController
    {
        public Session Session { get; }

        public BlueprintController(Session session)
        {
            this.Session = session;
        }

        public void Add(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.CREATE_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            BlueprintPortfolio.Instance.Add(aBlueprint);
        }

        public bool Exist(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            return BlueprintPortfolio.Instance.Exists(aBlueprint);
        }

        public ICollection<IBlueprint> GetBlueprints(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_OWNEDBLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            return BlueprintPortfolio.Instance.GetBlueprintsOfUser(aUser);
        }

        public ICollection<IBlueprint> GetBlueprints()
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            return BlueprintPortfolio.Instance.GetAll();
        }

        public void Remove(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.CREATE_BLUEPRINT))
            {//you cant destroy what you did not create
                throw new NoPermissionsException();
            }
            BlueprintPortfolio.Instance.Delete(aBlueprint);
        }

        public void Sign(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.CAN_SIGN_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            aBlueprint.Sign(Session.UserLogged);
        }
    }
}