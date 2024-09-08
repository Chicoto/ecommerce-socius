using ecommerce.Model;
using System.Data;

namespace ecommerce.Helpers
{
    public static class PedidoHelper
    {
        public static DataTable CreatePedidoDetalleDataTable(List<TbPedidoDetalle> detalles)
        {
            var table = new DataTable();
            table.Columns.Add("ProductoId", typeof(int));
            table.Columns.Add("Cantidad", typeof(int));
            table.Columns.Add("PrecioTotal", typeof(decimal));

            foreach (var detalle in detalles)
            {
                table.Rows.Add(detalle.ProductoId, detalle.Cantidad, detalle.PrecioTotal);
            }

            return table;
        }
    }
}
