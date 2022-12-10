﻿using DomainLayer.Entities;
using RepositoryLayer.Data;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CampanyApp.Controllers
{
    public class EmployeeController
    {
        private readonly EmployeeService employeeService;
        private readonly DepartmentService departmentService;

        public EmployeeController()
        {
            employeeService = new EmployeeService();
            departmentService = new DepartmentService();
        }

        public void Create()
        {
            try
            {
                if (AppDbContext<Department>.datas.Count != 0)
                {
                    ConsoleColor.Blue.WriteConsole("Add department id:");

                Id: string idstr = Console.ReadLine();
                    int id;
                    bool isParseId = int.TryParse(idstr, out id);
                    if (isParseId)
                    {
                        Department department = departmentService.GetById(id);
                        if (department == null)
                        {
                            ConsoleColor.Red.WriteConsole("Not Found, Please try again:");
                            goto Id;
                        }
                        else
                        {
                            ConsoleColor.Blue.WriteConsole("Add employee name:");

                            string name = Console.ReadLine();
                            if (Regex.IsMatch(name, "^[A-Z]{1}[a-z]*"))
                            {
                                ConsoleColor.Blue.WriteConsole("Add employee surname:");

                            Surname: string surname = Console.ReadLine();

                                if (Regex.IsMatch(surname, "^[A-Z]{1}[a-z]*"))
                                {
                                    ConsoleColor.Blue.WriteConsole("Add employee address:");

                                    string address = Console.ReadLine();

                                    if (Regex.IsMatch(address, "^[A-Z]{1}[a-z]+[0-9]*"))
                                    {
                                        ConsoleColor.Blue.WriteConsole("Add employee age");

                                    Age: string ageStr = Console.ReadLine();

                                        int age;

                                        bool isParseAge = int.TryParse(ageStr, out age);

                                        if (isParseAge)
                                        {
                                            Employee employee = new Employee()
                                            {
                                                Name = name,
                                                Surname = surname,
                                                Address = address,
                                                Age = age,
                                                Department = department

                                            };
                                            var result = employeeService.Create(employee);
                                            if (result is null) throw new NullReferenceException();
                                            ConsoleColor.Green.WriteConsole($"Id:{result.Id}, Name:{result.Name}, Surname: {result.Surname}, Age:{result.Age}, Address:{result.Address}, Department name: {result.Department.Name}");
                                        }
                                        else
                                        {
                                            ConsoleColor.Red.WriteConsole("Please add correct age:");
                                            goto Age;
                                        }

                                    }
                                    else
                                    {
                                        ConsoleColor.Red.WriteConsole("Please add correct age:");
                                        goto Address;
                                    }
                                }
                                else
                                {
                                    ConsoleColor.Red.WriteConsole("Please add correct surname:");
                                    goto Surname;
                                }
                            }

                            else
                            {
                                ConsoleColor.Red.WriteConsole("Please add correct name:");
                                goto Name;
                            }
                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("Not found, Please try again:");
                        goto Id;
                    }
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct name:");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void GetById()
        {
            try
            {
                ConsoleColor.DarkMagenta.WriteConsole("Add employee id:");

            Id: string idStr = Console.ReadLine();


                int id;

                bool isParseId = int.TryParse(idStr, out id);

                if (isParseId)
                {
                    var result = employeeService.GetById(id);

                    if (result is null)
                    {
                        ConsoleColor.Red.WriteConsole("Employee notfound, please try again:");
                        goto Id;
                    }


                    ConsoleColor.Green.WriteConsole($"Id: {result.Id}, Name: {result.Name}, Surname: {result.Surname}, Age: {result.Age}, Address: {result.Address}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id:");
                    goto Id;
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);

            }
        }

        public void Delete()
        {
            try
            {
                ConsoleColor.DarkMagenta.WriteConsole("Add employee id:");

            Id: string idStr = Console.ReadLine();

                int id;

                bool isParseId = int.TryParse(idStr, out id);

                if (isParseId)
                {
                    employeeService.Delete(id);

                    ConsoleColor.Green.WriteConsole($" Successfully delete ");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id:");
                    goto Id;
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void Count()
        {

        }

        public void Update()
        {

        }

        public void GetEmployeesByDepartamentId()
        {

        }

        public void SearchEmployeesByNameOrSurname()
        {
            ConsoleColor.DarkMagenta.WriteConsole("Add searchText:");

            string searchText = Console.ReadLine();

            var result = employeeService.SearchEmployeesByNameOrSurname(searchText);

            foreach (var item in result)
            {
                ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}, Age: {item.Age}, Address: {item.Address}");
            }
        }
        public void GetEmployeesByDepartmentAge()
        {

        }

        public void GetAllEmployeesByDepartamentName()
        {

        }
    }
}
