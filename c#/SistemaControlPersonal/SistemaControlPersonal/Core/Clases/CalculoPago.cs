using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
