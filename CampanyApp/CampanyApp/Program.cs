
using CampanyApp.Controllers;
using DomainLayer.Entities;
using ServiceLayer.Helpers;

DepartmentController departmentController = new();
EmployeeController employeeController = new();

while (true)
{
    GetMenues();

SelectOption: string option = Console.ReadLine();

    int selectedOption;

    bool isParseOption = int.TryParse(option, out selectedOption);

    if (isParseOption)
    {
        switch (selectedOption)
        {
            case 1:
                departmentController.Create();
                break;
            case 2:
                Console.WriteLine("Update Department");
                break;
            case 3:
                departmentController.Delete();
                break;
            case 4:
                departmentController.GetById();
                break;
            case 5:
                departmentController.GetAll();
                break;
            case 6:
                departmentController.Search();
                break;
            case 7:
                employeeController.Create();
                break;
            case 8:
                Console.WriteLine("Update employee");
                break;
            case 9:
                Console.WriteLine("Get employee by id");
                break;
            case 10:
                Console.WriteLine("Delete employee");
                break;
            case 11:
                Console.WriteLine("Get employee by age");
                break;
            case 12:
                Console.WriteLine("Get employees by departmentId");
                break;
            case 13:
                Console.WriteLine("Get all employees by departmentname");
                break;
            case 14:
                
                break;
            case 15:
                Console.WriteLine("Get all employees count");
                break;

            default:
                Console.WriteLine("Select again true option:");
                goto SelectOption;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Select again true option:");
        goto SelectOption;
    }
}

static void GetMenues()
{
    ConsoleColor.Blue.WriteConsole("Select department option:");

    ConsoleColor.DarkGray.WriteConsole(" 1 - Create Department, 2 - Update Department, 3 - Delete Department," +
    "4 - Get department by id, 5 - Get all departments, 6 - Search method for departments,");

    ConsoleColor.Blue.WriteConsole("Select employee option");

    ConsoleColor.DarkGray.WriteConsole("7 - Create employee, 8 - Update employee, 9 - Get employee by id, 10 - Delete employee, " +
        "11 - Get employees bye age, 12 - Get employees by departmentId, 13 - Get all employees by departmentName, " +
    "14 - Search method for employees by name or surname, 15 - Get all employees count");



}
