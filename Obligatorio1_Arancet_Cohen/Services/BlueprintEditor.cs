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

        public BlueprintEditor(Session session, IBlueprint blueprintTest)
        {
            this.session = session;
            this.blueprint = blueprintTest;
            this.repository = new BlueprintRepository();
        }

        public void SetOwner(User aUser)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);
            CheckPermission(Permission.HAVE_BLUEPRINT);
            blueprint.Owner = aUser;
            repository.Modify(blueprint);
        }


        public void InsertWall(Point from, Point to)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.InsertWall(from, to);
            repository.Modify(blueprint);
        }

        public void InsertColumn(Point columnPosition)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.InsertColumn(columnPosition);
            repository.Modify(blueprint);
        }


        public void RemoveWall(Point from, Point to)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.RemoveWall(from, to);
            repository.Modify(blueprint);
        }

        public void InsertOpening(Opening aOpening)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.InsertOpening(aOpening);
            repository.Modify(blueprint);
        }

        public void RemoveOpening(Opening aOpening)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.RemoveOpening(aOpening);
            repository.Modify(blueprint);
        }

        public void Sign(User architect)
        {
            throw new NotImplementedException();
        }

        private void CheckPermission(Permission permission)
        {
            if (!session.UserLogged.HasPermission(permission))
            {
                throw new NoPermissionsException();
            }
        }
    }
}