﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;
using DomainRepositoryInterface;
using RepositoryInterface;
using Entities;

namespace DataAccess
{
    class BlueprintRespository : IRepository<Blueprint>, IUserRepository
    {
        public void Add(Blueprint toStore)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                BlueprintAndEntityConverter blueprintTranslator = new BlueprintAndEntityConverter();
                MaterialAndEntityConverter materialTranslator = new MaterialAndEntityConverter();

                BlueprintEntity converted = blueprintTranslator.BlueprintToEntiy(toStore);
                context.Blueprints.Add(converted);

                IEnumerable<WallEntity> convertedWalls = toStore.GetWalls().Select(w => materialTranslator.WallToEntity(w,toStore));
                context.Walls.AddRange(convertedWalls);

                
                context.SaveChanges();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Delete(Blueprint entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Blueprint record)
        {
            throw new NotImplementedException();
        }

        public bool ExistsUserName(string aUserName)
        {
            throw new NotImplementedException();
        }

        public User Get(User userAsked)
        {
            throw new NotImplementedException();
        }

        public Blueprint Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Blueprint> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUsersByPermission(Permission aFeature)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public void Modify(Blueprint entity)
        {
            throw new NotImplementedException();
        }
    }
}
