using System;
using Logic.Domain;
using System.Collections.Generic;
using Logic;
using RepositoryInterface;
using DataAccess;
using ServicesExceptions;

namespace Services
{
    public class BlueprintEditor
    {
        private IBlueprint blueprint;
        private IRepository<IBlueprint> repository;
        private Session session;
        private bool hasBeenModify;

        public bool HasBeenModify {
            get {
                return hasBeenModify;
            }
            internal set {
                hasBeenModify = value;
            }
        }

        public BlueprintEditor(Session session, IBlueprint blueprint, IRepository<IBlueprint> aRepository)
        {
            this.session = session;
            this.blueprint = blueprint;
            this.repository = aRepository;
            HasBeenModify = false;
        }

        public void SetOwner(User aUser)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);
            blueprint.Owner = aUser;
            repository.Modify(blueprint);
            HasBeenModify = true;
        }

        public void InsertWall(Point from, Point to)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.InsertWall(from, to);
            repository.Modify(blueprint);
            HasBeenModify = true;
        }

        public void InsertColumn(Point columnPosition)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.InsertColumn(columnPosition);
            repository.Modify(blueprint);
            HasBeenModify = true;
        }

        public void RemoveWall(Point from, Point to)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.RemoveWall(from, to);
            repository.Modify(blueprint);
            HasBeenModify = true;
        }

        public void InsertOpening(Opening aOpening)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.InsertOpening(aOpening);
            IRepository<Template> templateRepo = new OpeningTemplateRepository();

            if (!templateRepo.Exists(aOpening.getTemplate()))
            {
                templateRepo.Add(aOpening.getTemplate());
            }
            repository.Modify(blueprint);
            HasBeenModify = true;
        }

        public void RemoveOpening(Opening aOpening)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.RemoveOpening(aOpening);
            repository.Modify(blueprint);
            HasBeenModify = true;
        }

        public void Sign()
        {
            CheckPermission(Permission.CAN_SIGN_BLUEPRINT);

            blueprint.Sign(session.UserLogged);
            repository.Modify(blueprint);
            HasBeenModify = false;
        }

        private void CheckPermission(Permission permission)
        {
            if (!session.UserLogged.HasPermission(permission))
            {
                throw new NoPermissionsException();
            }
        }

        public void RemoveColumn(Point columnPoint)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.RemoveColumn(columnPoint);
            repository.Modify(blueprint);
            HasBeenModify = true;
        }

        public ICollection<Template> GetTemplates()
        {
            IRepository<Template> repository = new OpeningTemplateRepository();
            return repository.GetAll();
        }
    }
}