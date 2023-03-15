using Facesign.Services.Domain.Interfaces.Repository;
using Facesign.Services.Entities.User;
using Facesign.Services.Entities.Value;
using Facesign.Services.Infra.Data.Data.Context;
using Facesign.Services.Infra.Data.Data.Extensions;
using Facesign.Services.Infra.Data.Data.User;
using Facesign.Services.Infra.LogService;
using Microsoft.EntityFrameworkCore;

namespace Facesign.Services.Infra.Data.Repository.User
{
    public class UserRepository : IUserRepository
    {

        private readonly DbContextOptions<SqlServerContext> _context;
        public UserRepository(DbContextOptions<SqlServerContext> context)
        {
            _context = context;
        }

        public async Task<UserModel> Get(string cpf)
        {
            try
            {
                await using var _db = new SqlServerContext(_context);
                var result = await _db.User.Where(w => w.cpf == cpf)
                    .Select(s => new UserModel { id = s.id, name = s.name, cpf = s.cpf, telephone = s.telephone, date_insert = s.date_insert, deviceModel = s.deviceModel, matchLevel = s.matchLevel, externaldatabaserefid = s.externaldatabaserefid })
                    .FirstOrDefaultWithNoLockAsync();
                return result;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error User Repository {0}", ex.Message));

                throw;
            }
        }

        public async Task<UserModel> Get(Guid id)
        {
            try
            {
                await using var _db = new SqlServerContext(_context);
                var result = await _db.User.Where(w => w.id == id)
                    .Select(s => new UserModel { id = s.id, name = s.name, cpf = s.cpf, telephone = s.telephone, date_insert = s.date_insert, deviceModel = s.deviceModel, matchLevel = s.matchLevel, externaldatabaserefid = s.externaldatabaserefid })
                    .FirstOrDefaultWithNoLockAsync();
                return result;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error User Repository {0}", ex.Message));

                throw;
            }
        }

        public async Task<List<UserModel>> Get()
        {
            try
            {
                await using var _db = new SqlServerContext(_context);
                var result = await _db.User
                    .Select(s => new UserModel { id = s.id, name = s.name, cpf = s.cpf, telephone = s.telephone, date_insert = Convert.ToDateTime(s.date_insert).ToLocalTime() })
                    .ToListWithNoLockAsync();
                return result;
            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error User Repository {0}", ex.Message));

                throw;
            }
        }

        Guid IUserRepository.Create(UserModel user)
        {
            try
            {
                UserData userData = new UserData()
                { status = 0, cpf = user.cpf.Trim().Replace(" ", ""), name = user.name, telephone = user.telephone, matchLevel = user.matchLevel, ip = user.ip, deviceModel = user.deviceModel, externaldatabaserefid = user.externaldatabaserefid, location = user.location };

                using var _db = new SqlServerContext(_context);
                _db.User.Add(userData);
                _db.SaveChanges();

                return userData.id;

            }
            catch (Exception ex)
            {
                LogLocalService.Log(string.Format("Error Client Repository {0}", ex.Message));

                return Guid.Empty;
            }

        }             

        public async void Update(UserModel user)
        {
            using var _db = new SqlServerContext(_context);

            var dados = _db.User.First(x => x.id == user.id);

            dados.name = user.name;
            dados.telephone = user.telephone;
            dados.status = user.status;

            _db.Update(dados);
            _db.SaveChanges();

        }

        public async Task<bool> CPFVerify(ValueVerifyModel valueVerify)
        {
            using var _db = new SqlServerContext(_context);
            var result = _db.User.Where(w => w.cpf == valueVerify.value && w.status == 0).FirstOrDefault();

            if (result == null)
                return false;
            else
            
                return true;
            }
    }
}
