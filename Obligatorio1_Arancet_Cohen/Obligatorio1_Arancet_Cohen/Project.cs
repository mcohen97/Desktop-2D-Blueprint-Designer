
namespace Obligatorio1_Arancet_Cohen
{
    public class Project
    {
        public Client Client { get; set; }
        public Designer Designer { get; set; }

        public Project(Client client, Designer designer)
        {
            this.Client = client;
            this.Designer = designer;
        }

    }
}