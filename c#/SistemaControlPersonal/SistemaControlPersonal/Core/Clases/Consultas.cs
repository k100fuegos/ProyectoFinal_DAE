namespace SistemaControlPersonal.Core.Clases
{
    internal class Consultas
    {
        // Empleado
        public int IdEmpleado { get; set; }
        public int CodigoEmpleado { get; set; }          // id interno
        public string CodigoExterno { get; set; } = "";  // código visible
        public string NombreEmpleado { get; set; } = "";
        public string Sexo { get; set; } = "";
        public string DUI { get; set; } = "";
        public string Direccion { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string FechaIngreso { get; set; } = "";
        public string EstadoLaboral { get; set; } = "";

        // Cargo
        public string NombreCargo { get; set; } = "";
        public string DescripcionCargo { get; set; } = "";
        public string TipoPago { get; set; } = "";
        public decimal SalarioBase { get; set; } = 0m;

        // Asistencia
        public string EstadoAsistencia { get; set; } = "";
        public string Nota { get; set; } = "";
        public string Fecha { get; set; } = "";
    }
}
