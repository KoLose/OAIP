using System;
using System.Runtime.CompilerServices;

namespace ClassExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Book example
            Console.WriteLine("Введите данные для книги:");
            Console.Write("Название: ");
            string bookTitle = Console.ReadLine();
            Console.Write("Автор: ");
            string bookAuthor = Console.ReadLine();
            Console.Write("Количество страниц: ");
            int bookPages = int.Parse(Console.ReadLine());

            Book book1 = new Book(bookTitle, bookAuthor, bookPages);
            book1.PrintInfo();
            Console.WriteLine("----------------------------------");

            // Student example
            Console.WriteLine("Введите данные для студента:");
            Console.Write("Имя: ");
            string studentName = Console.ReadLine();
            Console.Write("Возраст: ");
            int studentAge = int.Parse(Console.ReadLine());
            Console.Write("Группа (если есть, иначе нажмите Enter): ");
            string studentGroup = Console.ReadLine();

            Student student1;
            if (string.IsNullOrEmpty(studentGroup))
            {
                student1 = new Student(studentName, studentAge);
            }
            else
            {
                student1 = new Student(studentName, studentAge, studentGroup);
            }

            student1.ShowInfo();
            Console.WriteLine("----------------------------------");

            // Car example
            Console.WriteLine("Введите данные для автомобиля:");
            Console.Write("Марка: ");
            string carBrand = Console.ReadLine();
            Console.Write("Пробег: ");
            int carMileage = int.Parse(Console.ReadLine());

            Car myCar = new Car(carBrand, carMileage);
            myCar.Drive(200);
            myCar.ShowMileage();
            Console.WriteLine("----------------------------------");

            // Rectangle example
            Console.WriteLine("Введите данные для прямоугольника:");
            Console.Write("Ширина: ");
            int rectWidth = int.Parse(Console.ReadLine());
            Console.Write("Высота: ");
            int rectHeight = int.Parse(Console.ReadLine());

            Rectangle rect = new Rectangle(rectWidth, rectHeight);
            rect.PrintInfo();
            Console.WriteLine("----------------------------------");

            // BankAccount example
            Console.WriteLine("Введите данные для банковского счета:");
            Console.Write("Начальный баланс: ");
            int initialBalance = int.Parse(Console.ReadLine());

            BankAccount myAccount = new BankAccount(initialBalance);
            myAccount.Deposit(500);
            myAccount.Withdraw(200);
            myAccount.ShowBalance();
            Console.WriteLine("----------------------------------");

            Console.ReadKey();
        }
    }

    class Book
    {
        public string title;
        public string author;
        public int pages;

        public Book(string bookTitle, string bookAuthor, int bookPages)
        {
            title = bookTitle;
            author = bookAuthor;
            pages = bookPages;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Книга: " + title + ", Автор: " + author + ", Страниц: " + pages);
        }
    }

    class Student
    {
        public string name;
        public int age;
        public string group;

        public Student(string studentName, int studentAge, string studentGroup)
        {
            name = studentName;
            age = studentAge;
            group = studentGroup;
        }

        public Student(string studentName, int studentAge)
        {
            name = studentName;
            age = studentAge;
            group = "Неизвестная группа";
        }

        public void ShowInfo()
        {
            Console.WriteLine("Студент: " + name + ", Возраст: " + age + ", Группа: " + group);
        }
    }

    class Car
    {
        public string brand;
        public int mileage;

        public Car(string carBrand, int carMileage)
        {
            brand = carBrand;
            mileage = carMileage;
        }

        public void Drive(int distance)
        {
            mileage += distance;
        }

        public void ShowMileage()
        {
            Console.WriteLine("Марка: " + brand + ", Пробег: " + mileage + " км");
        }
    }

    class Rectangle
    {
        public int width;
        public int height;

        public Rectangle(int rectWidth, int rectHeight)
        {
            width = rectWidth;
            height = rectHeight;
        }

        public int GetArea()
        {
            return width * height;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Ширина: " + width + ", Высота: " + height + ", Площадь: " + GetArea());
        }
    }

    class BankAccount
    {
        public int balance;

        public BankAccount(int initialBalance)
        {
            balance = initialBalance;
        }

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете.");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine("Текущий баланс: " + balance + " руб.");
        }
    }
}