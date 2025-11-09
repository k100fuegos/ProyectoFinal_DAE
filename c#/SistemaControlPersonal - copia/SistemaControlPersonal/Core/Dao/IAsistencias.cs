using SistemaControlPersonal.Core.Clases;
using System;
using System.Collections.Generic;

namespace SistemaControlPersonal.Core.Dao
{
    internal interface IAsistencias
    {
        List<Asistencias> GetAll(string filtro = "", DateTime? fechaFiltro = null);
        Asistencias GetById(int idAsistencia);
        int Insert(Asistencias paAsistencias);
    }
}
