using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using ThesisManagement.DAL.Interfaces;
using ThesisManagement.Entities.Db;

namespace ThesisManagement.DAL.Repositories
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        protected readonly AppDbContext context = context;
        private readonly DbSet<T> entities = context.Set<T>();

        public async Task<IEnumerable<T>> GetAll(params string[] includes)
        {
            IQueryable<T> query = entities;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetById(Guid id, params string[] includes)
        {
            IQueryable<T> query = entities;

            // Bao gồm các thuộc tính liên quan nếu có
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            // Lấy thông tin về loại thực thể
            var entityType = context.Model.FindEntityType(typeof(T)) ?? throw new ArgumentException($"Entity type '{typeof(T).Name}' không tồn tại trong DbContext.");

            // Lấy khóa chính của thực thể
            var primaryKey = entityType.FindPrimaryKey() ?? throw new ArgumentException($"Thực thể '{typeof(T).Name}' không có khóa chính.");

            // Giả sử chỉ có một khóa chính đơn
            if (primaryKey.Properties.Count != 1)
                throw new NotSupportedException("Phương thức này chỉ hỗ trợ các thực thể có một khóa chính đơn.");

            var keyProperty = primaryKey.Properties[0];
            var keyName = keyProperty.Name;

            // Xây dựng biểu thức lambda để so sánh khóa chính
            var parameter = Expression.Parameter(typeof(T), "e");
            var property = Expression.PropertyOrField(parameter, keyName);
            var constant = Expression.Constant(id, typeof(Guid));
            var equality = Expression.Equal(property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

            // Thực hiện truy vấn
            return await query.SingleOrDefaultAsync(lambda);
        }

        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = entities;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.Where(predicate).ToListAsync();
        }
    }
}
