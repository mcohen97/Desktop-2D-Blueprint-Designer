using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Logic.Domain;
using BusinessDataExceptions;

namespace DataAccess
{
    class UserAndEntityConverter
    {
        public UserEntity toEntity(User toConvert)
        {
            if (toConvert == null)
            {
                throw new ArgumentNullException();
            }

            UserEntity conversion;
            if (toConvert is Admin)
            {
                conversion = AdminToEntity((Admin)toConvert);
            }
            else if (toConvert is Client)
            {
                conversion = ClientToEntity((Client)toConvert);
            }
            else if (toConvert is Designer)
            {
                conversion = DesignerToEntity((Designer)toConvert);
            }
            else
            {
                conversion = ArhitectToEntiy((Architect)toConvert);
            }
            return conversion;
        }

        public User toUser(UserEntity toConvert)
        {
            if (toConvert == null)
            {
                throw new ArgumentNullException();
            }

            User conversion;
            if (toConvert is ClientEntity)
            {
                conversion = EntityToClient((ClientEntity)toConvert);
            }
            else if (toConvert is AdminEntity)
            {
                conversion = EntityToAdmin((AdminEntity)toConvert);
            }
            else if (toConvert is DesignerEntity)
            {
                conversion = EntityToDesigner((DesignerEntity)toConvert);
            }
            else
            {
                conversion = EntityToArchitect((ArchitectEntity)toConvert);

            }
            return conversion;
        }


        private ClientEntity ClientToEntity(Client toConvert)
        {
            if (toConvert == null)
            {
                throw new ArgumentNullException();
            }

            ClientEntity conversion = new ClientEntity()
            {
                Name = toConvert.Name,
                Surname = toConvert.Surname,
                UserName = toConvert.UserName,
                Password = toConvert.Password,
                Phone = toConvert.Phone,
                IdCard = toConvert.Id,
                Address = toConvert.Address,
                RegistrationDate = toConvert.RegistrationDate,
                LastLoginDate = toConvert.LastLoginDate
            };

            return conversion;
        }

        private Client EntityToClient(ClientEntity toConvert)
        {
            if (toConvert == null)
            {
                throw new ArgumentNullException();
            }

            Client conversion;

            try
            {
                conversion = new Client(toConvert.Name, toConvert.Surname, toConvert.UserName,
                                               toConvert.Password, toConvert.Phone, toConvert.Address,
                                               toConvert.IdCard, toConvert.RegistrationDate, toConvert.LastLoginDate);

            }
            catch (ArgumentNullException)
            {
                throw new InconsistentDataException();
            }

            return conversion;
        }

        private AdminEntity AdminToEntity(Admin toConvert)
        {
            if (toConvert == null)
            {
                throw new ArgumentNullException();
            }
            AdminEntity conversion = new AdminEntity()
            {
                Name = toConvert.Name,
                Surname = toConvert.Surname,
                UserName = toConvert.UserName,
                Password = toConvert.Password,
                RegistrationDate = toConvert.RegistrationDate,
                LastLoginDate = toConvert.LastLoginDate

            };
            return conversion;

        }

        private Admin EntityToAdmin(AdminEntity toConvert)
        {
            if (toConvert == null)
            {
                throw new ArgumentNullException();
            }
            Admin conversion;
            try
            {
                conversion = new Admin(toConvert.Name, toConvert.Surname, toConvert.UserName,
                                            toConvert.Password, toConvert.RegistrationDate, toConvert.LastLoginDate);
            }
            catch (ArgumentNullException)
            {
                throw new InconsistentDataException();
            }
            return conversion;
        }

        private DesignerEntity DesignerToEntity(Designer toConvert)
        {
            if (toConvert == null)
            {
                throw new ArgumentNullException();
            }

            DesignerEntity conversion = new DesignerEntity()
            {
                Name = toConvert.Name,
                Surname = toConvert.Surname,
                UserName = toConvert.UserName,
                Password = toConvert.Password,
                RegistrationDate = toConvert.RegistrationDate,
                LastLoginDate = toConvert.LastLoginDate,
            };
            return conversion;
        }

        private Designer EntityToDesigner(DesignerEntity toConvert)
        {
            if (toConvert == null)
            {
                throw new ArgumentNullException();
            }
            Designer conversion;
            try
            {
                conversion = new Designer(toConvert.Name, toConvert.Surname, toConvert.UserName,
                    toConvert.Password, toConvert.RegistrationDate, toConvert.LastLoginDate);
            }
            catch (ArgumentNullException) {
                throw new InconsistentDataException();
            }
                return conversion;
        }

        private ArchitectEntity ArhitectToEntiy(Architect toConvert)
        {
            ArchitectEntity conversion = new ArchitectEntity()
            {
                Name = toConvert.Name,
                Surname = toConvert.Surname,
                UserName = toConvert.UserName,
                Password = toConvert.Password,
                RegistrationDate = toConvert.RegistrationDate,
                LastLoginDate = toConvert.LastLoginDate

            };
            return conversion;

        }

        private Architect EntityToArchitect(ArchitectEntity toConvert)
        {
            if (toConvert == null)
            {
                throw new ArgumentNullException();
            }
            Architect conversion;
            try
            {
                conversion = new Architect(toConvert.Name, toConvert.Surname, toConvert.UserName, toConvert.Password, toConvert.RegistrationDate, toConvert.LastLoginDate);
            }
            catch (ArgumentNullException) {
                throw new InconsistentDataException();
            }
                return conversion;
        }
    }
}
