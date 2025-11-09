using System;

namespace SistemaControlPersonal.Core.Clases
{
    public class Cargos
    {
        public int IdCargo { get; set; }
        public string NombreCargo { get; set; }
        public string Descripcion { get; set; } // Nuevo campo para descripción
        public double SalarioBase { get; set; }
        public string TipoPago { get; set; }
    }
}
