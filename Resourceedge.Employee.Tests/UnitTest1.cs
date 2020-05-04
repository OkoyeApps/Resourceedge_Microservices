using Moq;
using Resourceedge.Employee.Domain.Interfaces;
using System;
using Xunit;
using Resourceedge.Employee.API.Controllers;
using Resourceedge.Employee.Domain.Profiles;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Resourceedge.Common.Archive;
//using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Resourceedge.Employee.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {


            Mock<IEmployee> EmployeeRepo = new Mock<IEmployee>();
            EmployeeProfile Profile = new EmployeeProfile();
            var configuration = new MapperConfiguration(c => c.AddProfile<EmployeeProfile>());
            var mapper = new Mapper(configuration);

            var OldEmployeeController = new OldEmployeeController(EmployeeRepo.Object, mapper);
            //Setup Profile for Automapper
            //OldEmployeeController.GetEmployees(new Common.Util.PaginationResourceParameter());

            Assert.True(true);
        }

        //public T SetUpDatabaseForTest<T>() where T : DbContext
        //{
        //    var options = new DbContextOptionsBuilder<T>().UseInMemoryDatabase(nameof(T));

        //}

        public void CreateEmployeesForTest<T>(T context) where T : DbContext
        {
            for (int i = 0; i < 10; i++)
            {
                context.Add(new OldEmployee
                {
                    EmpEmail = $"test{i}@test.com",
                    BusinessunitId = i,
                    DepartmentId = i,
                    EmployeeId = i,
                    GroupId = i
                });
            }
            context.SaveChanges();
        }
    }
}
