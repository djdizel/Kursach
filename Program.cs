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
        static string doctorFile = "doctors.txt";
        static string employeeFile = "employees.txt";
        static string areaFile = "areas.txt";
        static string patientCardFile = "patientCards.txt";

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
                            RegisterPatient();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Пациент успешно зарегистрирован");
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
                        try
                        {
                            Console.Clear();
                            AddVisit();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Посещение успешно добавлено");
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
                    case '7':
                        flag = false;
                        break;
                    case '8':
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

                // Главное меню
                if (!flag)
                {
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
                            case '4':
                                flag = true;
                                flagMain = false;
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
            Console.WriteLine("[5] Регистрация пациента");
            Console.WriteLine("[6] Добавление посещения");
            Console.WriteLine("[7] Выход из первого меню");
            Console.WriteLine("[8] Выход из программы для сохранения данных");
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
            Console.WriteLine("[4] Вернуться в первое меню");
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
            Doctor d = new Doctor { ID = doctors.Count + 1 };
            Console.Write("ФИО: ");
            d.FIO = Console.ReadLine();
            Console.Write("Специализация: ");
            d.Specialization = Console.ReadLine();
            Console.Write("Категория: ");
            d.Category = Console.ReadLine();
            Console.Write("Стаж (в годах): ");
            if (int.TryParse(Console.ReadLine(), out int experience))
                d.Experience = experience;
            Console.Write("Дата рождения (гггг-мм-дд): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                d.BirthDate = birthDate;
            Console.Write("Номер кабинета: ");
            d.CabinetNumber = Console.ReadLine();
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
            Console.Write("Часы приема (например, 9:00-12:00): ");
            d.Schedule.Hours = Console.ReadLine();
            Console.WriteLine("Назначить участки (введите номера через запятую): ");
            string[] areaNumbers = Console.ReadLine().Split(',');
            foreach (var num in areaNumbers)
            {
                if (int.TryParse(num.Trim(), out int areaNum))
                {
                    var area = areas.FirstOrDefault(a => a.Number == areaNum);
                    if (area != null)
                        d.Areas.Add(area);
                }
            }
            doctors.Add(d);
            SaveData();
        }

        static void AddEmployee()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ СОТРУДНИКА ===");
            Employee e = new Employee();
            Console.Write("ФИО: ");
            e.FIO = Console.ReadLine();
            Console.Write("Должность (например, Медсестра): ");
            e.Position = Console.ReadLine();
            Console.Write("Стаж (в годах): ");
            if (int.TryParse(Console.ReadLine(), out int experience))
                e.Experience = experience;
            Console.Write("Номер участка (или Enter, если не применимо): ");
            if (int.TryParse(Console.ReadLine(), out int areaNumber))
                e.AreaNumber = areaNumber;
            employees.Add(e);
            SaveData();
        }

        static void AddArea()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ УЧАСТКА ===");
            Area a = new Area { Number = areas.Count + 1 };
            Console.Write("Название участка: ");
            a.Name = Console.ReadLine();
            Console.Write("Адрес участка: ");
            a.Address = Console.ReadLine();
            areas.Add(a);
            SaveData();
        }

        static void RegisterPatient()
        {
            Console.WriteLine("=== РЕГИСТРАЦИЯ ПАЦИЕНТА ===");
            PatientCard p = new PatientCard { Number = patientCards.Count + 1, CreationDate = DateTime.Now };
            Console.Write("ФИО: ");
            p.FIO = Console.ReadLine();
            Console.Write("Адрес: ");
            p.Address = Console.ReadLine();
            Console.Write("Пол (М/Ж): ");
            p.Gender = Console.ReadLine();
            Console.Write("Возраст: ");
            if (int.TryParse(Console.ReadLine(), out int age))
                p.Age = age;
            Console.Write("Номер страхового полиса: ");
            p.InsurancePolicyNumber = Console.ReadLine();
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

        static void AddVisit()
        {
            Console.WriteLine("=== ДОБАВЛЕНИЕ ПОСЕЩЕНИЯ ===");
            Console.Write("Введите номер карточки пациента: ");
            if (int.TryParse(Console.ReadLine(), out int cardNumber))
            {
                var patient = patientCards.FirstOrDefault(p => p.Number == cardNumber);
                if (patient != null)
                {
                    Visit v = new Visit();
                    Console.Write("Дата посещения (гггг-мм-дд): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime visitDate))
                        v.Date = visitDate;
                    Console.Write("Жалобы: ");
                    v.Complaints = Console.ReadLine();
                    Console.Write("Предварительный диагноз: ");
                    v.PreliminaryDiagnosis = Console.ReadLine();
                    Console.Write("Назначения: ");
                    v.Prescriptions = Console.ReadLine();
                    Console.Write("Выписан больничный? (Да/Нет): ");
                    v.SickLeaveIssued = Console.ReadLine().ToLower() == "да";
                    if (v.SickLeaveIssued)
                    {
                        Console.Write("Срок больничного (дней): ");
                        if (int.TryParse(Console.ReadLine(), out int duration))
                            v.SickLeaveDuration = duration;
                    }
                    ShowAllDoctors();
                    Console.Write("Введите номер врача: ");
                    if (int.TryParse(Console.ReadLine(), out int i) && i > 0 && i <= doctors.Count)
                    {
                        v.DoctorName = doctors[i - 1].FIO;
                        if (patient.Doctor != doctors[i - 1])
                        {
                            patient.Doctor?.Patients.Remove(patient);
                            patient.Doctor = doctors[i - 1];
                            doctors[i - 1].Patients.Add(patient);
                        }
                    }
                    patient.Visits.Add(v);
                    SaveData();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Карточка не найдена.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
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
                if (input != "") d.FIO = input;
                Console.Write("Новая специализация: ");
                input = Console.ReadLine();
                if (input != "") d.Specialization = input;
                Console.Write("Новая категория: ");
                input = Console.ReadLine();
                if (input != "") d.Category = input;
                Console.Write("Новый стаж: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int exp)) d.Experience = exp;
                Console.Write("Новая дата рождения (гггг-мм-дд): ");
                input = Console.ReadLine();
                if (DateTime.TryParse(input, out DateTime birthDate)) d.BirthDate = birthDate;
                Console.Write("Новый номер кабинета: ");
                input = Console.ReadLine();
                if (input != "") d.CabinetNumber = input;
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
                    Console.Write("Часы приема: ");
                    d.Schedule.Hours = Console.ReadLine();
                }
                Console.WriteLine("Обновить участки? (Да/Нет): ");
                if (Console.ReadLine().ToLower() == "да")
                {
                    d.Areas.Clear();
                    Console.WriteLine("Назначить участки (введите номера через запятую): ");
                    string[] areaNumbers = Console.ReadLine().Split(',');
                    foreach (var num in areaNumbers)
                    {
                        if (int.TryParse(num.Trim(), out int areaNum))
                        {
                            var area = areas.FirstOrDefault(a => a.Number == areaNum);
                            if (area != null)
                                d.Areas.Add(area);
                        }
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
                Console.WriteLine("Переназначить участки и пациентов? (Да/Нет): ");
                if (Console.ReadLine().ToLower() == "да")
                {
                    ShowAllDoctors();
                    Console.Write("Введите номер нового врача: ");
                    if (int.TryParse(Console.ReadLine(), out int newDoctorIndex) && newDoctorIndex > 0 && newDoctorIndex <= doctors.Count && newDoctorIndex != i)
                    {
                        Doctor newDoctor = doctors[newDoctorIndex - 1];
                        foreach (var area in d.Areas)
                            if (!newDoctor.Areas.Contains(area))
                                newDoctor.Areas.Add(area);
                        foreach (var patient in d.Patients)
                        {
                            patient.Doctor = newDoctor;
                            newDoctor.Patients.Add(patient);
                        }
                    }
                }
                d.Patients.Clear();
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
                Console.WriteLine($"Пациенты врача {doctor.FIO}:");
                if (doctor.Patients.Count == 0)
                    Console.WriteLine("Нет пациентов.");
                else
                    foreach (var patient in doctor.Patients)
                        Console.WriteLine($"- {patient.FIO} (Карточка №{patient.Number})");
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
                    Console.WriteLine($"Участок №{area.Number} ({area.Name}): {nurseCount} медсестер");
                }
            }
            Console.ReadKey();
        }

        static void ShowDoctorScheduleBySpecialty()
        {
            Console.Write("Введите специализацию: ");
            string specialization = Console.ReadLine();
            var matchingDoctors = doctors.Where(d => d.Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase)).ToList();
            if (matchingDoctors.Count == 0)
            {
                Console.WriteLine("Врачей с такой специализацией нет.");
            }
            else
            {
                Console.WriteLine($"Расписание врачей ({specialization}):");
                foreach (var doctor in matchingDoctors)
                {
                    Console.WriteLine($"\nВрач: {doctor.FIO}, Кабинет: {doctor.CabinetNumber}");
                    doctor.Schedule.Print();
                    Console.WriteLine($"Участки: {string.Join(", ", doctor.Areas.Select(a => $"№{a.Number}"))}");
                }
            }
            Console.ReadKey();
        }

        static void ShowPatientDetails()
        {
            Console.Write("Введите ФИО пациента: ");
            string fio = Console.ReadLine();
            var patient = patientCards.FirstOrDefault(p => p.FIO.Equals(fio, StringComparison.OrdinalIgnoreCase));
            if (patient == null)
            {
                Console.WriteLine("Пациент не найден.");
            }
            else
            {
                var lastVisit = patient.Visits.OrderByDescending(v => v.Date).FirstOrDefault();
                Console.WriteLine($"Пациент: {patient.FIO}");
                Console.WriteLine($"Адрес: {patient.Address}");
                Console.WriteLine($"Дата последнего посещения: {(lastVisit != null ? lastVisit.Date.ToString("yyyy-MM-dd") : "Нет посещений")}");
                Console.WriteLine($"Диагноз: {(lastVisit != null ? lastVisit.PreliminaryDiagnosis : "Нет данных")}");
                Console.WriteLine($"Лечащий врач: {(patient.Doctor != null ? patient.Doctor.FIO : "Не назначен")}");
            }
            Console.ReadKey();
        }

        static void ShowDoctorPatientCount()
        {
            Console.WriteLine("=== КОЛИЧЕСТВО ПАЦИЕНТОВ ЗА ПОСЛЕДНИЙ МЕСЯЦ ===");
            DateTime lastMonth = DateTime.Now.AddMonths(-1);
            foreach (var doctor in doctors)
            {
                int patientCount = patientCards
                    .SelectMany(p => p.Visits)
                    .Count(v => v.DoctorName == doctor.FIO && v.Date >= lastMonth);
                Console.WriteLine($"Врач {doctor.FIO}: {patientCount} пациентов");
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
                    string areas = string.Join(";", doctor.Areas.Select(a => a.Number));
                    sw.WriteLine($"{doctor.ID},{doctor.FIO},{doctor.Specialization},{doctor.Category},{doctor.Experience},{doctor.BirthDate:yyyy-MM-dd},{doctor.CabinetNumber},{days},{doctor.Schedule.Hours},{areas}");
                }
            }

            using (StreamWriter sw = new StreamWriter(employeeFile))
            {
                foreach (var employee in employees)
                {
                    sw.WriteLine($"{employee.FIO},{employee.Position},{employee.Experience},{employee.AreaNumber}");
                }
            }

            using (StreamWriter sw = new StreamWriter(areaFile))
            {
                foreach (var area in areas)
                {
                    sw.WriteLine($"{area.Number},{area.Name},{area.Address}");
                }
            }

            using (StreamWriter sw = new StreamWriter(patientCardFile))
            {
                foreach (var patient in patientCards)
                {
                    string doctorFIO = patient.Doctor != null ? patient.Doctor.FIO : "";
                    sw.WriteLine($"P,{patient.Number},{patient.FIO},{patient.Address},{patient.Gender},{patient.Age},{patient.InsurancePolicyNumber},{patient.CreationDate:yyyy-MM-dd},{doctorFIO}");
                    foreach (var visit in patient.Visits)
                    {
                        sw.WriteLine($"V,{patient.Number},{visit.Date:yyyy-MM-dd},{visit.Complaints},{visit.PreliminaryDiagnosis},{visit.Prescriptions},{visit.SickLeaveIssued},{visit.SickLeaveDuration},{visit.DoctorName}");
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
                            ID = int.Parse(parts[0]),
                            FIO = parts[1],
                            Specialization = parts[2],
                            Category = parts[3],
                            Experience = int.TryParse(parts[4], out int exp) ? exp : 0,
                            BirthDate = DateTime.TryParse(parts[5], out DateTime bd) ? bd : DateTime.MinValue,
                            CabinetNumber = parts[6],
                            Schedule = new Schedule(),
                            Areas = new List<Area>(),
                            Patients = new List<PatientCard>()
                        };
                        if (parts.Length > 7 && !string.IsNullOrEmpty(parts[7]))
                        {
                            var days = parts[7].Split(';');
                            for (int i = 0; i < days.Length && i < 3; i++)
                            {
                                if (Enum.TryParse<DayOfWeek>(days[i], true, out DayOfWeek day))
                                    doctor.Schedule.Days[i] = day;
                            }
                        }
                        doctor.Schedule.Hours = parts.Length > 8 ? parts[8] : "";
                        if (parts.Length > 9 && !string.IsNullOrEmpty(parts[9]))
                        {
                            var areaNumbers = parts[9].Split(';').Select(int.Parse);
                            foreach (var num in areaNumbers)
                            {
                                var area = areas.FirstOrDefault(a => a.Number == num);
                                if (area != null)
                                    doctor.Areas.Add(area);
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
                            FIO = parts[0],
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
                            Number = int.Parse(parts[0]),
                            Name = parts[1],
                            Address = parts[2]
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
                    PatientCard currentPatient = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts[0] == "P")
                        {
                            currentPatient = new PatientCard
                            {
                                Number = int.Parse(parts[1]),
                                FIO = parts[2],
                                Address = parts[3],
                                Gender = parts[4],
                                Age = int.TryParse(parts[5], out int age) ? age : 0,
                                InsurancePolicyNumber = parts[6],
                                CreationDate = DateTime.TryParse(parts[7], out DateTime cd) ? cd : DateTime.Now,
                                Visits = new List<Visit>()
                            };
                            if (parts.Length > 8 && !string.IsNullOrEmpty(parts[8]))
                            {
                                currentPatient.Doctor = doctors.FirstOrDefault(d => d.FIO == parts[8]);
                                if (currentPatient.Doctor != null)
                                    currentPatient.Doctor.Patients.Add(currentPatient);
                            }
                            patientCards.Add(currentPatient);
                        }
                        else if (parts[0] == "V" && currentPatient != null)
                        {
                            var visit = new Visit
                            {
                                Date = DateTime.TryParse(parts[2], out DateTime date) ? date : DateTime.MinValue,
                                Complaints = parts[3],
                                PreliminaryDiagnosis = parts[4],
                                Prescriptions = parts[5],
                                SickLeaveIssued = bool.Parse(parts[6]),
                                SickLeaveDuration = int.TryParse(parts[7], out int duration) ? duration : 0,
                                DoctorName = parts[8]
                            };
                            currentPatient.Visits.Add(visit);
                        }
                    }
                }
            }
        }
    }
}