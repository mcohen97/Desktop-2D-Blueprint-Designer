using System;
using Logic.Domain;
using Logic.Exceptions;
using System.Collections.Generic;

namespace Services
{
    public class BlueprintEditor
    {
        private IBlueprint blueprint;
        private Session session;

        public BlueprintEditor(Session session, IBlueprint blueprintTest)
        {
            this.session = session;
            this.blueprint = blueprintTest;
        }

        public string GetName()
        {
            if (!session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }

            return blueprint.Name;
        }

        public void SetOwner(User aUser)
        {
            if (!session.UserLogged.HasPermission(Permission.EDIT_BLUEPRINT) ||
                !aUser.HasPermission(Permission.HAVE_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }

            blueprint.Owner = aUser;
        }

        public User GetOwner()
        {
            if (!session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }

            return blueprint.Owner;
        }

        public void InsertWall(Point from, Point to)
        {
            if(!session.UserLogged.HasPermission(Permission.EDIT_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }

            blueprint.InsertWall(from, to);
        }

        public void InsertColumn(Point columnPosition)
        {
            if(!session.UserLogged.HasPermission(Permission.EDIT_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }

            blueprint.InsertColumn(columnPosition);
        }

        public ICollection<Wall> GetWalls()
        {
            if (!session.UserLogged.HasPermission(Permission.READ_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }

            return blueprint.GetWalls();
        }

        public void RemoveWall(Point point1, Point point2)
        {
            throw new NotImplementedException();
        }

        public void InsertOpening(Opening aOpening)
        {
            if (!session.UserLogged.HasPermission(Permission.EDIT_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }

            blueprint.InsertOpening(aOpening);
        }

        public void RemoveOpening(Opening aOpening)
        {
            if (!session.UserLogged.HasPermission(Permission.EDIT_BLUEPRINT))
            {
                throw new NoPermissionsException();
            }

            blueprint.RemoveOpening(aOpening);
        }

        public object GetColumns()
        {
            throw new NotImplementedException();
        }

        public void InsertWall(Wall aWall)
        {
            throw new NotImplementedException();
        }
    }
}