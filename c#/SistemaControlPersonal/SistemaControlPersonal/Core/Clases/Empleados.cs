namespace SistemaControlPersonal.Core.Clases
{
    public class Empleados
    {
        private int idEmpleado;
        private int codigoEmpleado;
        private string nombreEmpleado;
        private string dUI;
        private string sexo;
        private string fechaNacimiento;
        private string direccion;
        private string telefono;
        private double salarioBase;
        private string fechaIngreso;
        private string estadoLaboral;
        private string cargo;

        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public int CodigoEmpleado { get => codigoEmpleado; set => codigoEmpleado = value; }
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public string DUI { get => dUI; set => dUI = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public double SalarioBase { get => salarioBase; set => salarioBase = value; }
        public string FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string EstadoLaboral { get => estadoLaboral; set => estadoLaboral = value; }
        public string Cargo { get => cargo; set => cargo = value; }
    }
}
