using System;
namespace Backend.Models;

public class DepartmentDBSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string DepartmentsCollectionName { get; set; } = null!;
}


