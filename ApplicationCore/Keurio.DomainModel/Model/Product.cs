using Keurio.DomainModel.Enum;

namespace Keurio.DomainModel.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        public int CategoryId { get; private set; }

        public string ProductCode { get; private set; } = null!;

        public string ProductName { get; private set; } = null!;

        public StateEnum StateId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int CreateBy { get; set; }

        public int UpdateBy { get; set; }

        protected Product() { }

        public static Product Create(int productId, int categoryId, string productCode, string productName, StateEnum stateId, int createBy)
        {
            
            Validate(categoryId, productName, productCode);
            
            return new Product()
            {
                ProductId = productId,
                CategoryId = categoryId,
                ProductCode = productCode,
                ProductName = productName,
                StateId = stateId,
                CreateBy = createBy,
                UpdateBy = createBy,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };
        }

        private static void Validate(int categoryId, string productName, string productCode)
        { 
            if(categoryId == 0)
            {
                throw new ArgumentException("El Id Categoría debe ser mayor a 0", nameof(categoryId));
            }

            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("El Nombre del Producto no debe estar vacío", nameof(productName));
            }

            if(string.IsNullOrWhiteSpace(productCode))
            {
                throw new ArgumentException("El Código del producto no debe estar vacío", nameof(productCode));
            }
        }
    }
}
