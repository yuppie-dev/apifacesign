using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.SingleSignOn;
using Facesign.Services.Infra.Data.Data.Context;
using Facesign.Services.Infra.Data.Data.SingleSignOn;
using Facesign.Services.Infra.LogService;
using Microsoft.EntityFrameworkCore;

namespace Facesign.Services.Infra.Data.Repository.SingleSignOn
{
    public class SingleSignOnRepository : ISingleSignOnRepository
    {
        private readonly DbContextOptions<SqlServerContext> _context;
        public SingleSignOnRepository(DbContextOptions<SqlServerContext> context)
        {
            _context = context;
        }

        void ISingleSignOnRepository.Create(SSOModel sso)
        {
            try
            {
                var model = new SSOData()
                { cpf = sso.cpf.Trim().Replace(" ", ""), id_client = sso.id_client  };

                using var _db = new SqlServerContext(_context);
                _db.SSOs.Add(model);
                _db.SaveChanges();               

            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error SSO Repository {0}", ex.Message));

            }
        }       
    }
}
