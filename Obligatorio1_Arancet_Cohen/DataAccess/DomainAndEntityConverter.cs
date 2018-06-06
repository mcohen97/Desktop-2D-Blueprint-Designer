using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Logic.Domain;

namespace DataAccess
{
    class DomainAndEntityConverter
    {
        public ClientEntity ClientToEntity(Client toConvert)
        {

            ClientEntity conversion = new ClientEntity()
            {
                Name = toConvert.Name,
                Surname = toConvert.Surname,
                UserName = toConvert.UserName,
                Password = toConvert.Password,
                Phone = toConvert.Phone,
                Address = toConvert.Address

            };
            return conversion;
        }

        public Client EntityToClient(ClientEntity toConvert)
        {
            Client conversion = new Client(toConvert.Name, toConvert.Surname, toConvert.UserName,
                                           toConvert.Password, toConvert.Phone, toConvert.Address,
                                           toConvert.IdCard, toConvert.RegistrationDate);


            return conversion;
        }

        public AdminEntity AdminToEntity(Admin toConvert)
        {
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

        public Admin EntityToAdmin(AdminEntity toConvert) {
            Admin conversion = new Admin(toConvert.Name, toConvert.Surname, toConvert.UserName,
                                        toConvert.Password, toConvert.RegistrationDate);
            return conversion;
        }

        public DesignerEntity DesignerToEntity(Designer toConvert) {
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

        public Designer EntityToDesigner(DesignerEntity toConvert) {
            Designer conversion = new Designer(toConvert.Name, toConvert.Surname, toConvert.UserName, toConvert.Password, toConvert.RegistrationDate);
            return conversion;
        }

    }
}
