using SistemaControlPersonal.Core.Clases;

namespace SistemaControlPersonal.Core.Dao
{
    internal interface IAsistencias
    {
        List<Asistencias> GetAll(string filtro = "", DateTime? fechaFiltro = null);
        int Insert(Asistencias paAsistencias);
    }
}
