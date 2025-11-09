using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControlPersonal.Core.Clases
{
    internal class Asistencias
    {
        private int idAsistencia;
        private string fecha;
        private string estado_asistencia;
        private string nota;
        private int codigoEmpleado; // PK (ID_Empleado) — usado internamente para FK en inserciones
        private string codigoExterno; // código visible del empleado (codigo_empleado)
        private string nombreEmpleado;
        private string cargo;

        public int IdAsistencia { get => idAsistencia; set => idAsistencia = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Estado_asistencia { get => estado_asistencia; set => estado_asistencia = value; }
        public string Nota { get => nota; set => nota = value; }
        // CodigoEmpleado: contiene ahora el ID de la tabla Empleado (clave primaria)
        public int CodigoEmpleado { get => codigoEmpleado; set => codigoEmpleado = value; }
        // CodigoExterno: el código legible/visible del empleado que se muestra en la UI
        public string CodigoExterno { get => codigoExterno; set => codigoExterno = value; }
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public string Cargo { get => cargo; set => cargo = value; }
    }
}
