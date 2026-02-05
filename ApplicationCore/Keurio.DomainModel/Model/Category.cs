using Keurio.DomainModel.Enum;
using System.Net.Http.Headers;

namespace Keurio.DomainModel.Model
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; private set; } = null!;

        public StateEnum StateID { get; private set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
        
        public int CreateBy { get; set; }
        
        public int UpdateBy { get; set; }

        protected Category()
        {
        }

        public static Category Create(string categoryName, StateEnum stateId, int createBy)
        {

            Valid(categoryName, createBy);

            return new Category()
            {
                CategoryName = categoryName,
                StateID = stateId,
                CreateBy = createBy,
                UpdateBy = createBy,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }

        public static Category Update(int categoryId, string categoryName, StateEnum stateId, int updateBy)
        {
            Valid(categoryName, updateBy);

            return new Category()
            {
                CategoryId = categoryId,
                CategoryName = categoryName,
                StateID = stateId,
                UpdateBy = updateBy,
                UpdateDate = DateTime.Now
            };
        }

        public static Category ChangeState(int categoryId, StateEnum stateId, int updateBy)
        {

            return new Category()
            {
                CategoryId = categoryId,
                StateID = stateId,
                UpdateBy = updateBy,
                UpdateDate = DateTime.Now
            };
        }

        private static void Valid(string categoryName, int createBy)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Nombre de la categoría es requerida.", nameof(categoryName));
            }

            if (createBy == 0) 
            {
                throw new ArgumentException("El código del usuario no puede ser 0.", nameof(categoryName));
            }
        }
    }
}
