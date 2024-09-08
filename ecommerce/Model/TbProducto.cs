namespace ecommerce.Model
{
    public class TbProducto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int StockReservado { get; set; }
        public bool Habilitado { get; set; }
        public bool Eliminado { get; set; }

    }
}
