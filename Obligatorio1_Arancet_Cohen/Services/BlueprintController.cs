using System;
using System.Collections.Generic;
using ServicesExceptions;
using Logic.Domain;
using DataAccess;
using RepositoryInterface;
using DomainRepositoryInterface;

namespace Services
{
    public class BlueprintController
    {
        public Session Session { get; }
        private IRepository<IBlueprint> repository;

        public BlueprintController(Session session, IRepository<IBlueprint> aRepository )
        {
            this.Session = session;
            this.repository = aRepository;
        }

        public void Add(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.CREATE_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            repository.Add(aBlueprint);
        }

        public bool Exist(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            return repository.Exists(aBlueprint);
        }

        public ICollection<IBlueprint> GetBlueprints(User aUser)
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            return ((IBlueprintRepository)repository).GetBlueprintsOfUser(aUser);
        }

        public ICollection<IBlueprint> GetBlueprints()
        {
            if (!Session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            return repository.GetAll();
        }

        public void Remove(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.CREATE_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            repository.Delete(aBlueprint);
        }

        public void Sign(IBlueprint aBlueprint)
        {
            if (!Session.UserLogged.HasPermission(Permission.CAN_SIGN_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }
            aBlueprint.Sign(Session.UserLogged);
            repository.Modify(aBlueprint);
        }

    }
}