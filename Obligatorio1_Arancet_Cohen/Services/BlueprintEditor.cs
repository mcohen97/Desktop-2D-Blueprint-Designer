using System;
using Logic.Domain;
using Logic.Exceptions;
using System.Collections.Generic;
using Logic;

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

        public void SetOwner(User aUser)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);
            CheckPermission(Permission.HAVE_BLUEPRINT);

            blueprint.Owner = aUser;
        }


        public void InsertWall(Point from, Point to)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.InsertWall(from, to);
        }

        public void InsertColumn(Point columnPosition)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.InsertColumn(columnPosition);
        }


        public void RemoveWall(Point from, Point to)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.RemoveWall(from, to);
        }

        public void InsertOpening(Opening aOpening)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.InsertOpening(aOpening);
        }

        public void RemoveOpening(Opening aOpening)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.RemoveOpening(aOpening);
        }


        public void SetName(string name)
        {
            CheckPermission(Permission.EDIT_BLUEPRINT);

            blueprint.Name = name;
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