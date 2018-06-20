using System;
using System.Collections.Generic;
using ServicesExceptions;
using Logic.Domain;
using DataAccess;
using RepositoryInterface;

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
            BlueprintRepository repository = new BlueprintRepository();
            repository.Add(aBlueprint);
        }

        public bool Exist(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            BlueprintRepository repository = new BlueprintRepository();
            return repository.Exists(aBlueprint);
        }

        public ICollection<IBlueprint> GetBlueprints(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            BlueprintRepository repository = new BlueprintRepository();
            return repository.GetBlueprintsOfUser(aUser);
        }

        public ICollection<IBlueprint> GetBlueprints()
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            BlueprintRepository repository = new BlueprintRepository();
            return repository.GetAll();
        }

        public void Remove(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.CREATE_BLUEPRINT))
            {//you cant destroy what you did not create
                throw new NoPermissionsException();
            }
            BlueprintRepository repository = new BlueprintRepository();
            repository.Delete(aBlueprint);
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