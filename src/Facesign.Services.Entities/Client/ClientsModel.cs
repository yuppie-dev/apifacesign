
namespace Facesign.Services.Entities.Client
{ 
    public class ClientsModel : Base
    {        
        public string? name { get; set; }
       
        public string? cpf { get; set; }
       
        public string? telephone { get; set; }
       
        public int ? status { get; set; }
       
        public DateTime? validate { get; set; }
       

        public virtual ClientsFunctionalitiesModel functionalitie { get; set; }

        public virtual  ClientsLayoutsModel layout { get; set; }

        public ClientsModel()
        {
            this.functionalitie = new ClientsFunctionalitiesModel();
            this.layout = new ClientsLayoutsModel();
        }
    }
}
