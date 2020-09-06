using MasGobalDevTest.BL.DTO;
using MasGobalDevTest.DA.Models;
using System;

namespace MasGobalDevTest.BL.Factory
{
    
    public class HourlySalaryEmployee : EmployeeDTO
    {
        public HourlySalaryEmployee(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            HourlySalary = employee.HourlySalary;
            MonthlySalary = employee.MonthlySalary;
            AnnualSalary = 120 * employee.HourlySalary * 12;
        }
    }

    public class MounthlySalaryEmployee : EmployeeDTO
    {
        public MounthlySalaryEmployee(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            HourlySalary = employee.HourlySalary;
            MonthlySalary = employee.MonthlySalary;
            AnnualSalary = employee.MonthlySalary * 12;
        }
    }

    public abstract class Creator
    {
        public abstract EmployeeDTO GetEmployee(Employee employee);
    }

    public class ConcreteCreator : Creator
    {
        public override EmployeeDTO GetEmployee(Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new HourlySalaryEmployee(employee);
                case "MonthlySalaryEmployee":
                    return new MounthlySalaryEmployee(employee);
                default:
                    throw new ApplicationException($"Can't create employee of type {employee.ContractTypeName}");
            }
        }
    }


}
