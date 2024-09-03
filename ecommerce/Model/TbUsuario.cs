namespace ecommerce.Model
{
    public class TbUsuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool EsAdmin { get; set; }
        public bool Eliminado { get; set; }
        public bool Habilitado { get; set; }

    }
}
