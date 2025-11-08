using SistemaControlPersonal.Core.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControlPersonal.Core.Dao
{
    internal interface IAsistencias
    {

        int Insert(Asistencias paAsistencias);
        Asistencias GetById(int idAsistencia);
        List<Asistencias> GetAll(string filtro = "");

    }
}
