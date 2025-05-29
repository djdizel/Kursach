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
        static List<Area> areas = new List<Area>();
        static List<PatientCard> patientCards = new List<PatientCard>();
        static List<Polyclinic> polyclinics = new List<Polyclinic>();
        static string doctorFile = "doctors.txt";
        static string employeeFile = "employees.txt";
        static string areaFile = "areas.txt";
        static string patientCardFile = "patientCards.txt";
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
                            Console.WriteLine("Сотрудник успешно добавлен");
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
                        try
                        {
                            Console.Clear();
                            AddArea();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Участок успешно добавлен");
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
                    case '5':
                        try
                        {
                            Console.Clear();
                            AddPatientCard();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Карточка пациента успешно добавлена");
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
                    case '6':
                        flag = false;
                        break;
                    case '7':
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
                                    try
                                    {
                                        Console.Clear();
                                        ShowPatientsByDoctor();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Список пациентов выведен");
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
                                case '5':
                                    try
                                    {
                                        Console.Clear();
                                        ShowDoctorScheduleBySpecialty();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Расписание выведено");
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
                                case '6':
                                    try
                                    {
                                        Console.Clear();
                                        ShowDoctorPatientCount();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Статистика выведена");
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
                                case '7':
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
                        bool flagQueries = true;
                        while (flagQueries)
                        {
                            Console.Clear();
                            ShowQueriesMenu();
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    try
                                    {
                                        Console.Clear();
                                        ShowNursesByArea();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Информация о медсестрах выведена");
                                        Console.ResetColor();
                                        Console.Write("Хотите продолжить? (Да/Нет): ");
                                        string answer = Console.ReadLine();
                                        if (answer.ToLower() == "нет")
                                            flagQueries = false;
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
                                        ShowPatientDetails();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Информация о пациенте выведена");
                                        Console.ResetColor();
                                        Console.Write("Хотите продолжить? (Да/Нет): ");
                                        string answer = Console.ReadLine();
                                        if (answer.ToLower() == "нет")
                                            flagQueries = false;
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
                                    flagQueries = false;
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
            Console.WriteLine("[3] Добавление сотрудника");
            Console.WriteLine("[4] Добавление участка");
            Console.WriteLine("[5] Добавление карточки пациента");
            Console.WriteLine("[6] Выход из первого меню");
            Console.WriteLine("[7] Выход из программы для сохранения данных");
            Console.ResetColor();
        }

        static void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("ГЛАВНОЕ МЕНЮ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] Врачи");
            Console.WriteLine("[2] Запросы");
            Console.WriteLine("[3] Выход из программы");
            Console.ResetColor();
        }

        static void ShowDoctorsMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] Вывод информации о врачах");
            Console.WriteLine("[2] Редактировать врача");
            Console.WriteLine("[3] Удалить врача");
            Console.WriteLine("[4] Список пациентов врача");
            Console.WriteLine("[5] Расписание врачей по специальности");
            Console.WriteLine("[6] Количество пациентов за месяц");
            Console.WriteLine("[7] Выход в главное меню");
            Console.ResetColor();
        }

        static void ShowQueriesMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[1] Количество медсестер на участках");
            Console.WriteLine("[2] Информация о пациенте");
            Console.WriteLine("[3] Выход в главное меню");
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
            d.Schedule = new Schedule();
            Console.WriteLine("Укажите до 3 дней недели для приема (например, Понедельник, Среда): ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"День {i + 1} (или Enter для завершения): ");
                string day = Console.ReadLine();
                if (string.IsNullOrEmpty(day)) break;
                if (Enum.TryParse<DayOfWeek>(day, true, out DayOfWeek dayOfWeek))
                    d.Schedule.Days[i] = dayOfWeek;
            }
            doctors.Add(d);
            SaveData();
        }

        static void AddEmployee()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ СОТРУДНИКА ===");
            Employee e = new Employee();
            Console.Write("ФИО: ");
            e.Name = Console.ReadLine();
            Console.Write("Должность (например, Медсестра): ");
            e.Position = Console.ReadLine();
            Console.Write("Стаж (в годах): ");
            if (int.TryParse(Console.ReadLine(), out int experience))
                e.Experience = experience;
            else
                e.Experience = 0;
            Console.Write("Номер участка (или Enter, если не применимо): ");
            if (int.TryParse(Console.ReadLine(), out int areaNumber))
                e.AreaNumber = areaNumber;
            employees.Add(e);
            SaveData();
        }

        static void AddArea()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ УЧАСТКА ===");
            Area a = new Area();
            Console.Write("Номер участка: ");
            if (int.TryParse(Console.ReadLine(), out int number))
                a.Number = number;
            areas.Add(a);
            SaveData();
        }

        static void AddPatientCard()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ КАРТОЧКИ ПАЦИЕНТА ===");
            PatientCard p = new PatientCard();
            Console.Write("ФИО пациента: ");
            p.Name = Console.ReadLine();
            Console.Write("Адрес: ");
            p.Address = Console.ReadLine();
            Console.Write("Диагноз: ");
            p.Diagnosis = Console.ReadLine();
            Console.Write("Дата последнего посещения (гггг-мм-дд): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime lastVisit))
                p.LastVisit = lastVisit;
            ShowAllDoctors();
            Console.Write("Введите номер врача: ");
            if (int.TryParse(Console.ReadLine(), out int i) && i > 0 && i <= doctors.Count)
            {
                p.Doctor = doctors[i - 1];
                doctors[i - 1].Patients.Add(p);
            }
            patientCards.Add(p);
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
                Console.WriteLine("Обновить расписание? (Да/Нет): ");
                if (Console.ReadLine().ToLower() == "да")
                {
                    d.Schedule = new Schedule();
                    Console.WriteLine("Укажите до 3 дней недели для приема: ");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"День {j + 1} (или Enter для завершения): ");
                        string day = Console.ReadLine();
                        if (string.IsNullOrEmpty(day)) break;
                        if (Enum.TryParse<DayOfWeek>(day, true, out DayOfWeek dayOfWeek))
                            d.Schedule.Days[j] = dayOfWeek;
                    }
                }
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
                Doctor d = doctors[i - 1];
                foreach (var patient in patientCards.Where(p => p.Doctor == d))
                {
                    patient.Doctor = null;
                }
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

        static void ShowPatientsByDoctor()
        {
            ShowAllDoctors();
            Console.Write("Введите номер врача: ");
            if (int.TryParse(Console.ReadLine(), out int i) && i > 0 && i <= doctors.Count)
            {
                var doctor = doctors[i - 1];
                Console.WriteLine($"Пациенты врача {doctor.Name}:");
                if (doctor.Patients.Count == 0)
                    Console.WriteLine("Нет пациентов.");
                else
                    foreach (var patient in doctor.Patients)
                        Console.WriteLine($"- {patient.Name}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный номер.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        static void ShowNursesByArea()
        {
            Console.WriteLine("=== КОЛИЧЕСТВО МЕДСЕСТЕР НА УЧАСТКАХ ===");
            if (areas.Count == 0)
            {
                Console.WriteLine("Участков нет.");
            }
            else
            {
                foreach (var area in areas)
                {
                    int nurseCount = employees.Count(e => e.Position.ToLower() == "медсестра" && e.AreaNumber == area.Number);
                    Console.WriteLine($"Участок №{area.Number}: {nurseCount} медсестер");
                }
            }
            Console.ReadKey();
        }

        static void ShowDoctorScheduleBySpecialty()
        {
            Console.Write("Введите специальность: ");
            string specialty = Console.ReadLine();
            var matchingDoctors = doctors.Where(d => d.Specialty.Equals(specialty, StringComparison.OrdinalIgnoreCase)).ToList();
            if (matchingDoctors.Count == 0)
            {
                Console.WriteLine("Врачей с такой специальностью нет.");
            }
            else
            {
                Console.WriteLine($"Расписание врачей ({specialty}):");
                foreach (var doctor in matchingDoctors)
                {
                    Console.WriteLine($"\nВрач: {doctor.Name}");
                    doctor.Schedule.Print();
                }
            }
            Console.ReadKey();
        }

        static void ShowPatientDetails()
        {
            Console.Write("Введите ФИО пациента: ");
            string name = Console.ReadLine();
            var patient = patientCards.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (patient == null)
            {
                Console.WriteLine("Пациент не найден.");
            }
            else
            {
                Console.WriteLine($"Пациент: {patient.Name}");
                Console.WriteLine($"Адрес: {patient.Address}");
                Console.WriteLine($"Дата последнего посещения: {patient.LastVisit:yyyy-MM-dd}");
                Console.WriteLine($"Диагноз: {patient.Diagnosis}");
                Console.WriteLine($"Лечащий врач: {(patient.Doctor != null ? patient.Doctor.Name : "Не назначен")}");
            }
            Console.ReadKey();
        }

        static void ShowDoctorPatientCount()
        {
            Console.WriteLine("=== КОЛИЧЕСТВО ПАЦИЕНТОВ ЗА ПОСЛЕДНИЙ МЕСЯЦ ===");
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            foreach (var doctor in doctors)
            {
                int patientCount = doctor.Patients.Count(p => p.LastVisit >= lastMonth);
                Console.WriteLine($"Врач {doctor.Name}: {patientCount} пациентов");
            }
            Console.ReadKey();
        }

        static void SaveData()
        {
            using (StreamWriter sw = new StreamWriter(doctorFile))
            {
                foreach (var doctor in doctors)
                {
                    string days = string.Join(";", doctor.Schedule.Days.Where(d => d != null).Select(d => d.ToString()));
                    sw.WriteLine($"{doctor.Name},{doctor.Specialty},{doctor.Experience},{days}");
                }
            }

            using (StreamWriter sw = new StreamWriter(employeeFile))
            {
                foreach (var employee in employees)
                {
                    sw.WriteLine($"{employee.Name},{employee.Position},{employee.Experience},{employee.AreaNumber}");
                }
            }

            using (StreamWriter sw = new StreamWriter(areaFile))
            {
                foreach (var area in areas)
                {
                    sw.WriteLine($"{area.Number}");
                }
            }

            using (StreamWriter sw = new StreamWriter(patientCardFile))
            {
                foreach (var patient in patientCards)
                {
                    string doctorName = patient.Doctor != null ? patient.Doctor.Name : "";
                    sw.WriteLine($"{patient.Name},{patient.Address},{patient.Diagnosis},{patient.LastVisit:yyyy-MM-dd},{doctorName}");
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
                        sw.WriteLine($"  E,{employee.Name},{employee.Position},{employee.Experience},{employee.AreaNumber}");
                    }
                    foreach (var area in polyclinic.Areas)
                    {
                        sw.WriteLine($"  A,{area.Number}");
                    }
                    foreach (var patient in polyclinic.PatientCards)
                    {
                        string doctorName = patient.Doctor != null ? patient.Doctor.Name : "";
                        sw.WriteLine($"  P,{patient.Name},{patient.Address},{patient.Diagnosis},{patient.LastVisit:yyyy-MM-dd},{doctorName}");
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
                            Experience = int.TryParse(parts[2], out int exp) ? exp : 0,
                            Schedule = new Schedule()
                        };
                        if (parts.Length > 3 && !string.IsNullOrEmpty(parts[3]))
                        {
                            var days = parts[3].Split(';');
                            for (int i = 0; i < days.Length && i < 3; i++)
                            {
                                if (Enum.TryParse<DayOfWeek>(days[i], true, out DayOfWeek day))
                                    doctor.Schedule.Days[i] = day;
                            }
                        }
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
                            Experience = int.TryParse(parts[2], out int exp) ? exp : 0,
                            AreaNumber = int.TryParse(parts[3], out int area) ? area : 0
                        };
                        employees.Add(employee);
                    }
                }
            }

            if (File.Exists(areaFile))
            {
                using (StreamReader sr = new StreamReader(areaFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        var area = new Area
                        {
                            Number = int.Parse(parts[0])
                        };
                        areas.Add(area);
                    }
                }
            }

            if (File.Exists(patientCardFile))
            {
                using (StreamReader sr = new StreamReader(patientCardFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        var patient = new PatientCard
                        {
                            Name = parts[0],
                            Address = parts[1],
                            Diagnosis = parts[2],
                            LastVisit = DateTime.TryParse(parts[3], out DateTime date) ? date : DateTime.MinValue
                        };
                        if (parts.Length > 4 && !string.IsNullOrEmpty(parts[4]))
                        {
                            patient.Doctor = doctors.FirstOrDefault(d => d.Name == parts[4]);
                            if (patient.Doctor != null)
                                patient.Doctor.Patients.Add(patient);
                        }
                        patientCards.Add(patient);
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
                                var doctor = doctors.FirstOrDefault(d => d.Name == parts[1]);
                                if (doctor != null)
                                    polyclinic.Doctors.Add(doctor);
                            }
                            else if (parts[0] == "E")
                            {
                                var employee = employees.FirstOrDefault(e => e.Name == parts[1]);
                                if (employee != null)
                                    polyclinic.Employees.Add(employee);
                            }
                            else if (parts[0] == "A")
                            {
                                var area = areas.FirstOrDefault(a => a.Number == int.Parse(parts[1]));
                                if (area != null)
                                    polyclinic.Areas.Add(area);
                            }
                            else if (parts[0] == "P")
                            {
                                var patient = patientCards.FirstOrDefault(p => p.Name == parts[1]);
                                if (patient != null)
                                    polyclinic.PatientCards.Add(patient);
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
                                Employees = new List<Employee>(),
                                Areas = new List<Area>(),
                                PatientCards = new List<PatientCard>()
                            };
                            polyclinics.Add(polyclinic);
                        }
                    }
                }
            }
        }
    }
}