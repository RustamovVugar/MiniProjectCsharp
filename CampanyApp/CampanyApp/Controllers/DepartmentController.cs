using DomainLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanyApp.Controllers
{
    public class DepartmentController
    {
        private readonly DepartmentService departmentService;
        public DepartmentController()
        {
            departmentService = new DepartmentService();
        }
        public void Create()
        {
            try
            {
                ConsoleColor.DarkMagenta.WriteConsole("Add department name:");

                string name = Console.ReadLine();

                ConsoleColor.DarkMagenta.WriteConsole("Add department capacity count:");


            Capacity: string capacityStr = Console.ReadLine();

                int capacity;

                bool isParseCapacity = int.TryParse(capacityStr, out capacity);
                if (isParseCapacity)
                {
                    Department department = new()
                    {
                        Name = name,
                        Capacity = capacity,
                    };

                    var result = departmentService.Create(department);

                    ConsoleColor.Green.WriteConsole($"Id {result.Id}, Name {result.Name}, Capacity {result.Capacity}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct capacity:");
                    goto Capacity;
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }
        public void GetById()
        {
            try
            {
                ConsoleColor.DarkMagenta.WriteConsole("Add department id:");

            Id: string idStr = Console.ReadLine();


                int id;

                bool isParseId = int.TryParse(idStr, out id);

                if (isParseId)
                {
                    var result = departmentService.GetById(id);

                    if (result is null)
                    {
                        ConsoleColor.Red.WriteConsole("Department notfound, please try again:");
                        goto Id;
                    }


                    ConsoleColor.Green.WriteConsole($"Id: {result.Id}, Name: {result.Name}, Capacity: {result.Capacity}");
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
                ConsoleColor.DarkMagenta.WriteConsole("Add department id:");

            Id: string idStr = Console.ReadLine();

                int id;

                bool isParseId = int.TryParse(idStr, out id);

                if (isParseId)
                {
                    departmentService.Delete(id);

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

        public void Search()
        {
            try
            {
                Search: ConsoleColor.DarkMagenta.WriteConsole("Add department name:");

                string searchText = Console.ReadLine();

                var result = departmentService.Search(searchText);

                if (searchText == "")
                {
                    goto Search;
                }

                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Capacity: {item.Capacity}");
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }
            
        }

        public void GetAll()
        {
            try
            {
                Text: ConsoleColor.DarkMagenta.WriteConsole("Get all departments:");

                string text = Console.ReadLine();

                if (text == "") 
                {
                    var result = departmentService.GetAll(text);

                    foreach (var item in result)
                    {
                        ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Capacity: {item.Capacity}");
                    }

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct departments:");
                    goto Text;
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);

            }
        }

        public void Update()
        {

        }
    }
}
