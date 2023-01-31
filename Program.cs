using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        Hospital hospital = new Hospital();
        hospital.Work();
    }
}

class Hospital
{
    private List<Patient> _patients = new List<Patient>();

    public Hospital()
    {
        PlacePatients();
    }

    public void Work()
    {
        const string CommandFilterName = "1";
        const string CommandFilterAge = "2";
        const string CommandFilterDisease = "3";
        const string CommandExit = "4";
        bool isExit = false;

        while(isExit == false)
        {
            Console.Clear();
            Console.WriteLine("Отсортировать всех пациентов по фио - " + CommandFilterName);
            Console.WriteLine("Отсортировать всех пациентов по возрасту - " + CommandFilterAge);
            Console.WriteLine("Вывести пациентов с определенным заболеванием - " + CommandFilterDisease);
            Console.WriteLine("выйти - " + CommandExit);
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case CommandFilterName:
                    OrderByName();
                    break;

                case CommandFilterAge:
                    OrderByAge();
                    break;

                case CommandFilterDisease:
                    ShowFilteredDiseases();
                    break;

                case CommandExit:
                    isExit = true;
                    break;
            }
        }
    }

    private void ShowPatients(List<Patient> patients)
    {
        Console.Clear();
        int line = 0;
        int columnName = 0;
        int columnAge = 35;
        int columnDisease = 50;

        foreach(Patient patient in patients)
        {
            Console.SetCursorPosition(columnName, line);
            Console.WriteLine(patient.FullName);
            Console.SetCursorPosition(columnAge, line);
            Console.Write("Возраст: " + patient.Age);
            Console.SetCursorPosition(columnDisease, line);
            Console.Write("Заболевание: " + patient.Disease);
            line++;
        }

        Console.ReadKey();
    }

    private void OrderByName()
    {
        var filteredName = _patients.OrderBy(patient => patient.FullName);

        ShowPatients(filteredName.ToList());
    }

    private void OrderByAge()
    {
        var filteredAge = _patients.OrderBy(patient => patient.Age);

        ShowPatients(filteredAge.ToList());
    }

    private void ShowFilteredDiseases()
    {
        Console.WriteLine("Для сортировки пациентов по болезни, введите название заболевания: ");
        string disease = Console.ReadLine();

        var filteredDisease = from Patient patient in _patients where patient.Disease == disease select patient;

        ShowPatients(filteredDisease.ToList());
    }

    private void PlacePatients()
    {
        _patients.Add(new Patient("Иванов Иван Иванович", 36, "Расстройство средней среднести"));
        _patients.Add(new Patient("Петров Пётр Петрович", 42, "Уникальность имени"));
        _patients.Add(new Patient("Смирнов Смирный Смирнововидный", 24, "Фантазия поколений"));
        _patients.Add(new Patient("Губка Боб Бобович", 27, "Мульт-синдром А"));
        _patients.Add(new Patient("Патрик Звезда Умнейшев", 29, "Мульт-синдром Б"));
        _patients.Add(new Patient("Лайт Ягами Рюкович", 46, "Размышленческий гипофиз стёртости"));
        _patients.Add(new Patient("Шеньшен Олег Олегович", 55, "Перфоратор в заднем проходе"));
        _patients.Add(new Patient("Мармеладова Мария Михайловна", 19, "Сладкие щёчки"));
        _patients.Add(new Patient("Шестопалова Вероника Романовна", 33, "Любование симметричными объектами"));
        _patients.Add(new Patient("Параходов Михаил Сергеевич", 44, "Непереносимость лактозы"));
        _patients.Add(new Patient("Старательный Максим Андреевич", 41, "Президентский недуг"));
        _patients.Add(new Patient("Успехов Марк Эдуардович", 30, "По кайфу тут"));
        _patients.Add(new Patient("Вареник Дарья Петровна", 40, "Простуда"));
        _patients.Add(new Patient("Соколова Оксана Олеговна", 22, "Зеркальный фантом"));
        _patients.Add(new Patient("Солнцева Татьяна Васильевна", 28, "Лучезарность через край"));
    }
}

class Patient
{
    public Patient(string fullName, int age, string disease)
    {
        FullName = fullName;
        Age = age;
        Disease = disease;
    }

    public string FullName { get; private set; }
    public int Age { get; private set; }
    public string Disease { get; private set; }
}
