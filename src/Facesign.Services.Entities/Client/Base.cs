using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Facesign.Services.Entities.Client;

public class Base
{   
    public Guid id { get; set; }
      
    public DateTime date_insert { get; set; }

}
