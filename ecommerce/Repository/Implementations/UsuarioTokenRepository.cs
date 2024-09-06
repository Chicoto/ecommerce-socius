using Dapper;
using ecommerce.Data;
using ecommerce.Model;
using ecommerce.Repository.Interfaces;

namespace ecommerce.Repository.Implementations
{
    public class UsuarioTokenRepository : IUsuarioTokenRepository
    {
        private readonly DapperContext _context;

        public UsuarioTokenRepository(DapperContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<TbUsuarioToken>> GetAllAsync()
        //{
        //    var query = "SELECT * FROM TbUsuarioToken";
        //    using (var connection = _context.CreateConnection())
        //    {
        //        return await connection.QueryAsync<TbUsuarioToken>(query);
        //    }
        //}

        public async Task<TbUsuarioToken> GetByIdAsync(int usuarioId)
        {
            var query = "SELECT * FROM TbUsuarioToken WHERE UsuarioId = @UsuarioId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<TbUsuarioToken>(query, new { UsuarioId = usuarioId });
            }
        }

        //public async Task<int> InsertAsync(TbUsuarioToken usuarioToken)
        //{
        //    var query = "INSERT INTO TbUsuarioToken (UsuarioId, Token) VALUES (@UsuarioId, @Token)";
        //    using (var connection = _context.CreateConnection())
        //    {
        //        return await connection.ExecuteAsync(query, usuarioToken);
        //    }
        //}

        //public async Task<int> UpdateAsync(TbUsuarioToken usuarioToken)
        //{
        //    var query = "UPDATE TbUsuarioToken SET Token = @Token WHERE UsuarioId = @UsuarioId";
        //    using (var connection = _context.CreateConnection())
        //    {
        //        return await connection.ExecuteAsync(query, usuarioToken);
        //    }
        //}

        //public async Task<int> DeleteAsync(int usuarioId)
        //{
        //    var query = "DELETE FROM TbUsuarioToken WHERE UsuarioId = @UsuarioId";
        //    using (var connection = _context.CreateConnection())
        //    {
        //        return await connection.ExecuteAsync(query, new { UsuarioId = usuarioId });
        //    }
        //}
    }
}
