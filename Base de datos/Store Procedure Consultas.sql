ALTER PROCEDURE dbo.sp_GetConsultas
    @Filtro NVARCHAR(200) = NULL,
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @SoloActivos BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        E.id_empleado                AS IdEmpleado,
        E.codigo_empleado            AS CodigoEmpleado,
        CAST(E.codigo_empleado AS NVARCHAR(50)) AS CodigoExterno,
        E.nombre_empleado            AS NombreEmpleado,
        E.sexo                      AS Sexo,
        E.dui                       AS DUI,
        E.direccion                 AS Direccion,
        E.telefono                  AS Telefono,
        E.fecha_ingreso             AS FechaIngreso,
        E.estado_laboral            AS EstadoLaboral,
        C.nombre_cargo              AS NombreCargo,
        ISNULL(C.descripcion, '') AS TipoPago, -- ajustar si la columna es distinta
        ISNULL(C.salario_base, 0)      AS SalarioBase,
        A.estado_asistencia         AS EstadoAsistencia,
        A.nota                     AS Nota,
        A.fecha                    AS Fecha
    FROM Empleado E
    LEFT JOIN Cargo C ON E.id_cargo = C.id_cargo
    LEFT JOIN Asistencias A ON E.id_empleado = A.id_empleado
    WHERE
        (@Filtro IS NULL
         OR CAST(E.codigo_empleado AS NVARCHAR(50)) LIKE @Filtro
         OR E.nombre_empleado LIKE @Filtro
         OR E.dui LIKE @Filtro
         OR C.nombre_cargo LIKE @Filtro
         OR E.direccion LIKE @Filtro
         OR E.sexo LIKE @Filtro
         OR E.fecha_ingreso LIKE @Filtro
         OR E.estado_laboral LIKE @Filtro
         OR A.estado_asistencia LIKE @Filtro)
      AND
        (
            (@FechaInicio IS NULL AND @FechaFin IS NULL)
            OR (@FechaInicio IS NOT NULL AND @FechaFin IS NULL AND A.fecha = @FechaInicio)
            OR (@FechaInicio IS NULL AND @FechaFin IS NOT NULL AND A.fecha = @FechaFin)
            OR (@FechaInicio IS NOT NULL AND @FechaFin IS NOT NULL AND A.fecha BETWEEN @FechaInicio AND @FechaFin)
        )
    ORDER BY E.nombre_empleado;
END
GO