using System;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]     
[Route("api/[controller]")]

public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _departmentService;

    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<List<Department>> Get() =>
        await _departmentService.GetAsync();

    [HttpGet("searchDepartment")]
    public async Task<ActionResult<Department>> Get(string departmentName)
    {
        var result = await _departmentService.SearchDepartmentAsync(departmentName);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }


    [HttpGet(("getRootDepartments"))]
    public async Task<ActionResult<Department>> GetRootDepartment()
    {
        var result = await _departmentService.GetRootDepartmentsAsync();

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("getChildDepartments")]
    public async Task<ActionResult<Department>> GetChildDepartments(int parentId)
    {
        var result = await _departmentService.GetChildDepartmentsAsync(parentId);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

}




