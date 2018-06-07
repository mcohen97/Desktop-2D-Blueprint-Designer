using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;

namespace UserRepositoryInterface
{
    public interface IBlueprintRepository
    {
        ICollection<IBlueprint> GetBlueprintsOfUser(User owner);

        void DeleteUserBlueprints(Client aUser);
    }
}
