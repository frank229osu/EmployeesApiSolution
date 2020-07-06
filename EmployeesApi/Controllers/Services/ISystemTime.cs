using System;

namespace EmployeesApi.Controllers.Services
{
    public interface ISystemTime
    {
        DateTime GetCurrent();
    }
}