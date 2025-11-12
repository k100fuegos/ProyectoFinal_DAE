namespace SistemaControlPersonal.Core.Clases
{
    internal class CalculoPago
    {
    }

    // Clase ligera para mostrar en el grid de cálculo de pagos
    public class CalculoPagoEmpleado
    {
        public int CodigoEmpleado { get; set; }
        public string NombreEmpleado { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        // Ahora contiene el campo tipo_pago de la tabla Cargo
        public string TipoPago { get; set; } = string.Empty;
        // Nuevo: salario base tomado desde Cargo.salario_base
        public decimal SalarioBase { get; set; } = 0m;
    }
}
