using AgileSolutions.Business.Abstract.Services;
using AgileSolutions.Business.Concrete.Dtos.DepartmentDtos;
using AgileSolutions.Business.Concrete.Dtos.EmployeeDtos;
using AgileSolutions.Business.Concrete.Managers;
using AgileSolutions.Business.Helpers.Validators.DepartmentValidators;
using AgileSolutions.Business.Helpers.Validators.EmployeeValidators;
using AgileSolutions.DataAccess.Abstract.IRepositories;
using AgileSolutions.DataAccess.Concrete.EntityFramework.Repositories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.Business.Helpers.Extensions
{
    public static class MyExtension
    {
        public static void ServiceCollectionMethod(this IServiceCollection service)
        {
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            service.AddScoped<IEmployeeService, EmployeeManager>();
            service.AddScoped<IDepartmentService, DepartmentManager>();
            service.AddScoped<IDepartmentRepository, DepartmentRepository>();
            service.AddTransient<IValidator<EmployeeAddDto>, EmployeeAddValidator>();
            service.AddTransient<IValidator<EmployeeUpdateDto>, EmployeeUpdateValidator>();
            service.AddTransient<IValidator<DepartmentAddDto>, DepartmentAddValidator>();
            service.AddTransient<IValidator<DepartmentUpdateDto>, DepartmentUpdateValidator>();

        }
        public static void ServiceCollectionProductStockMethod(this IServiceCollection service)
        {
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            service.AddScoped<IDepartmentRepository, DepartmentRepository>();
            service.AddScoped<IDepartmentService, DepartmentManager>();
            service.AddScoped<IEmployeeService, EmployeeManager>();


        }

    }
}
