using Kursach;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kursach
{
    internal class Program
    {
        static List<Doctor> doctors = new List<Doctor>();
        static List<Employee> employees = new List<Employee>();
        static List<Polyclinic> polyclinics = new List<Polyclinic>();
        static string doctorFile = "doctors.txt";
        static string employeeFile = "employees.txt";
        static string polyclinicFile = "polyclinics.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Система управления поликлиникой";
            bool flag = true;

            // Первое меню: загрузка и добавление данных
            while (flag)
            {
                Console.Clear();
                ShowFirstMenu();
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        try
                        {
                            Console.Clear();
                            LoadData();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Считывание данных успешно");
                            Console.ResetColor();
                            Console.Write("Хотите продолжить? (Да/Нет): ");
                            string answer = Console.ReadLine();
                            if (answer.ToLower() == "нет")
                                flag = false;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка при считывании данных");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case '2':
                        try
                        {
                            Console.Clear();
                            AddDoctor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Врач успешно добавлен");
                            Console.ResetColor();
                            Console.Write("Хотите продолжить? (Да/Нет): ");
                            string answer = Console.ReadLine();
                            if (answer.ToLower() == "нет")
                                flag = false;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка, попробуйте еще раз");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case '3':
                        try
                        {
                            Console.Clear();
                            AddEmployee();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Сотрудник регистратуры успешно добавлен");
                            Console.ResetColor();
                            Console.Write("Хотите продолжить? (Да/Нет): ");
                            string answer = Console.ReadLine();
                            if (answer.ToLower() == "нет")
                                flag = false;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка, попробуйте еще раз");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        break;
                    case '4':
                        flag = false;
                        break;
                    case '5':
                        SaveData();
                        return;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка, попробуйте еще раз");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }

            // Главное меню
            bool flagMain = true;
            while (flagMain)
            {
                Console.Clear();
                ShowMainMenu();
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        bool flagDoctors = true;
                        while (flagDoctors)
                        {
                            Console.Clear();
                            ShowDoctorsMenu();
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    try
                                    {
                                        Console.Clear();
                                        ShowAllDoctors();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Информация о врачах выведена");
                                        Console.ResetColor();
                                        Console.Write("Хотите продолжить? (Да/Нет): ");
                                        string answer = Console.ReadLine();
                                        if (answer.ToLower() == "нет")
                                            flagDoctors = false;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка, попробуйте еще раз");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                    break;
                                case '2':
                                    try
                                    {
                                        Console.Clear();
                                        EditDoctor();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Врач успешно отредактирован");
                                        Console.ResetColor();
                                        Console.Write("Хотите продолжить? (Да/Нет): ");
                                        string answer = Console.ReadLine();
                                        if (answer.ToLower() == "нет")
                                            flagDoctors = false;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка, попробуйте еще раз");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                    break;
                                case '3':
                                    try
                                    {
                                        Console.Clear();
                                        RemoveDoctor();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Врач успешно удален");
                                        Console.ResetColor();
                                        Console.Write("Хотите продолжить? (Да/Нет): ");
                                        string answer = Console.ReadLine();
                                        if (answer.ToLower() == "нет")
                                            flagDoctors = false;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка, попробуйте еще раз");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                    break;
                                case '4':
                                    flagDoctors = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ошибка, попробуйте еще раз");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    case '2':
                        bool flagEmployees = true;
                        while (flagEmployees)
                        {
                            Console.Clear();
                            ShowEmployeesMenu();
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    try
                                    {
                                        Console.Clear();
                                        ShowAllEmployees();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Информация о сотрудниках выведена");
                                        Console.ResetColor();
                                        Console.Write("Хотите продолжить? (Да/Нет): ");
                                        string answer = Console.ReadLine();
                                        if (answer.ToLower() == "нет")
                                            flagEmployees = false;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка, попробуйте еще раз");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                    break;
                                case '2':
                                    try
                                    {
                                        Console.Clear();
                                        AddDoctorToPolyclinic();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Врач успешно добавлен в поликлинику");
                                        Console.ResetColor();
                                        Console.Write("Хотите продолжить? (Да/Нет): ");
                                        string answer = Console.ReadLine();
                                        if (answer.ToLower() == "нет")
                                            flagEmployees = false;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка, попробуйте еще раз");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                    break;
                                case '3':
                                    try
                                    {
                                        Console.Clear();
                                        AddEmployeeToPolyclinic();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Сотрудник успешно добавлен в поликлинику");
                                        Console.ResetColor();
                                        Console.Write("Хотите продолжить? (Да/Нет): ");
                                        string answer = Console.ReadLine();
                                        if (answer.ToLower() == "нет")
                                            flagEmployees = false;
                                    }
                                    catch
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Ошибка, попробуйте еще раз");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                    break;
                                case '4':
                                    flagEmployees = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ошибка, попробуйте еще раз");
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    case '3':
                        SaveData();
                        return;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка, попробуйте еще раз");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowFirstMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("ПЕРВОЕ МЕНЮ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] Считывание данных");
            Console.WriteLine("[2] Добавление врача");
            Console.WriteLine("[3] Добавление сотрудника регистратуры");
            Console.WriteLine("[4] Выход из первого меню");
            Console.WriteLine("[5] Выход из программы для сохранения данных");
            Console.ResetColor();
        }

        static void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("ГЛАВНОЕ МЕНЮ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] Врачи");
            Console.WriteLine("[2] Поликлиники");
            Console.WriteLine("[3] Выход из программы");
            Console.ResetColor();
        }

        static void ShowDoctorsMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] Вывод информации о врачах");
            Console.WriteLine("[2] Редактировать врача");
            Console.WriteLine("[3] Удалить врача");
            Console.WriteLine("[4] Выход в главное меню");
            Console.ResetColor();
        }

        static void ShowEmployeesMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] Вывод информации о сотрудниках");
            Console.WriteLine("[2] Добавить врача в поликлинику");
            Console.WriteLine("[3] Добавить сотрудника в поликлинику");
            Console.WriteLine("[4] Выход в главное меню");
            Console.ResetColor();
        }

        static void AddDoctor()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ ВРАЧА ===");
            Doctor d = new Doctor();
            Console.Write("ФИО: ");
            d.Name = Console.ReadLine();
            Console.Write("Специальность: ");
            d.Specialty = Console.ReadLine();
            Console.Write("Стаж (в годах): ");
            if (int.TryParse(Console.ReadLine(), out int experience))
                d.Experience = experience;
            else
                d.Experience = 0;
            doctors.Add(d);
            SaveData();
        }

        static void AddEmployee()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ СОТРУДНИКА РЕГИСТРАТУРЫ ===");
            Employee e = new Employee();
            Console.Write("ФИО: ");
            e.Name = Console.ReadLine();
            Console.Write("Должность: ");
            e.Position = Console.ReadLine();
            Console.Write("Стаж (в годах): ");
            if (int.TryParse(Console.ReadLine(), out int experience))
                e.Experience = experience;
            else
                e.Experience = 0;
            employees.Add(e);
            SaveData();
        }

        static void EditDoctor()
        {
            ShowAllDoctors();
            Console.Write("\nВведите номер врача для редактирования: ");
            if (int.TryParse(Console.ReadLine(), out int i) && i > 0 && i <= doctors.Count)
            {
                Doctor d = doctors[i - 1];
                Console.WriteLine("=== РЕДАКТИРОВАНИЕ ВРАЧА ===");
                Console.Write("Новое ФИО (Enter — оставить): ");
                string input = Console.ReadLine();
                if (input != "") d.Name = input;
                Console.Write("Новая специальность: ");
                input = Console.ReadLine();
                if (input != "") d.Specialty = input;
                Console.Write("Новый стаж: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int exp)) d.Experience = exp;
                SaveData();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный номер.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void ShowAllDoctors()
        {
            Console.WriteLine("=== СПИСОК ВСЕХ ВРАЧЕЙ ===\n");
            if (doctors.Count == 0)
            {
                Console.WriteLine("Врачей нет.");
            }
            else
            {
                for (int i = 0; i < doctors.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}]");
                    doctors[i].Print();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        static void RemoveDoctor()
        {
            ShowAllDoctors();
            Console.Write("\nВведите номер врача для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int i) && i > 0 && i <= doctors.Count)
            {
                doctors.RemoveAt(i - 1);
                SaveData();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный номер.");
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        static void ShowAllEmployees()
        {
            Console.WriteLine("=== СПИСОК ВСЕХ СОТРУДНИКОВ РЕГИСТРАТУРЫ ===\n");
            if (employees.Count == 0)
            {
                Console.WriteLine("Сотрудников нет.");
            }
            else
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}]");
                    employees[i].Print();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        static void AddDoctorToPolyclinic()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ ВРАЧА В ПОЛИКЛИНИКУ ===");
            Console.Write("Введите номер поликлиники: ");
            int.TryParse(Console.ReadLine(), out int num);

            Polyclinic p = polyclinics.Find(x => x.Number == num);
            if (p == null)
            {
                p = new Polyclinic();
                p.Number = num;
                Console.Write("Введите адрес поликлиники: ");
                p.Address = Console.ReadLine();
                p.Doctors = new List<Doctor>();
                p.Employees = new List<Employee>();
                polyclinics.Add(p);
            }

            ShowAllDoctors();
            Console.Write("Введите номер врача: ");
            if (int.TryParse(Console.ReadLine(), out int i) && i > 0 && i <= doctors.Count)
            {
                p.Doctors.Add(doctors[i - 1]);
                SaveData();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный номер.");
                Console.ResetColor();
                Console.ReadKey();
            }
            Console.WriteLine();
            p.Print();
        }

        static void AddEmployeeToPolyclinic()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ СОТРУДНИКА В ПОЛИКЛИНИКУ ===");
            Console.Write("Введите номер поликлиники: ");
            int.TryParse(Console.ReadLine(), out int num);

            Polyclinic p = polyclinics.Find(x => x.Number == num);
            if (p == null)
            {
                p = new Polyclinic();
                p.Number = num;
                Console.Write("Введите адрес поликлиники: ");
                p.Address = Console.ReadLine();
                p.Doctors = new List<Doctor>();
                p.Employees = new List<Employee>();
                polyclinics.Add(p);
            }

            ShowAllEmployees();
            Console.Write("Введите номер сотрудника: ");
            if (int.TryParse(Console.ReadLine(), out int i) && i > 0 && i <= employees.Count)
            {
                p.Employees.Add(employees[i - 1]);
                SaveData();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный номер.");
                Console.ResetColor();
                Console.ReadKey();
            }
            Console.WriteLine();
            p.Print();
        }

        static void SaveData()
        {
            using (StreamWriter sw = new StreamWriter(doctorFile))
            {
                foreach (var doctor in doctors)
                {
                    sw.WriteLine($"{doctor.Name},{doctor.Specialty},{doctor.Experience}");
                }
            }

            using (StreamWriter sw = new StreamWriter(employeeFile))
            {
                foreach (var employee in employees)
                {
                    sw.WriteLine($"{employee.Name},{employee.Position},{employee.Experience}");
                }
            }

            using (StreamWriter sw = new StreamWriter(polyclinicFile))
            {
                foreach (var polyclinic in polyclinics)
                {
                    sw.WriteLine($"{polyclinic.Number},{polyclinic.Address}");
                    foreach (var doctor in polyclinic.Doctors)
                    {
                        sw.WriteLine($"  D,{doctor.Name},{doctor.Specialty},{doctor.Experience}");
                    }
                    foreach (var employee in polyclinic.Employees)
                    {
                        sw.WriteLine($"  E,{employee.Name},{employee.Position},{employee.Experience}");
                    }
                }
            }
        }

        static void LoadData()
        {
            if (File.Exists(doctorFile))
            {
                using (StreamReader sr = new StreamReader(doctorFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        var doctor = new Doctor
                        {
                            Name = parts[0],
                            Specialty = parts[1],
                            Experience = int.TryParse(parts[2], out int exp) ? exp : 0
                        };
                        doctors.Add(doctor);
                    }
                }
            }

            if (File.Exists(employeeFile))
            {
                using (StreamReader sr = new StreamReader(employeeFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        var employee = new Employee
                        {
                            Name = parts[0],
                            Position = parts[1],
                            Experience = int.TryParse(parts[2], out int exp) ? exp : 0
                        };
                        employees.Add(employee);
                    }
                }
            }

            if (File.Exists(polyclinicFile))
            {
                using (StreamReader sr = new StreamReader(polyclinicFile))
                {
                    string line;
                    Polyclinic polyclinic = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("  "))
                        {
                            var parts = line.Trim().Split(',');
                            if (parts[0] == "D")
                            {
                                var doctor = new Doctor
                                {
                                    Name = parts[1],
                                    Specialty = parts[2],
                                    Experience = int.TryParse(parts[3], out int exp) ? exp : 0
                                };
                                polyclinic.Doctors.Add(doctor);
                            }
                            else if (parts[0] == "E")
                            {
                                var employee = new Employee
                                {
                                    Name = parts[1],
                                    Position = parts[2],
                                    Experience = int.TryParse(parts[3], out int exp) ? exp : 0
                                };
                                polyclinic.Employees.Add(employee);
                            }
                        }
                        else
                        {
                            var parts = line.Split(',');
                            polyclinic = new Polyclinic
                            {
                                Number = int.Parse(parts[0]),
                                Address = parts[1],
                                Doctors = new List<Doctor>(),
                                Employees = new List<Employee>()
                            };
                            polyclinics.Add(polyclinic);
                        }
                    }
                }
            }
        }
    }
}