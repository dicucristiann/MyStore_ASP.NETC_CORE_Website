using PostgreSQL.Data;

namespace MyStore_ASP_NET_CORE_WebApp.Data
{
    public class Cart
    {
        public int Id { get; set; }
        public int HomeProductId { get; set; }
        public HomeProduct? Product { get; set; }
        public int Quantity { get; set; }
    }
}
