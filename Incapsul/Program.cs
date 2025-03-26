using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsul
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bank = new BankAccount(1000000);
            bank.ShowBalance();
            bank.Deposit(500);
            bank.Withdraw(46703);
            bank.Withdraw(1000000);
            bank.ShowBalance();

            Person person = new Person(25);
            person.ShowInfo();
            person.SetAge(-5);
            person.SetAge(30);
            person.ShowInfo();
            Console.ReadKey();
        }
        public class Person {
            private int _age;
            public Person(int age)
            {
                SetAge(age);
            }
        public int getAge()
            {
                return _age;
            }
            public void SetAge(int newAge)
            {
                if (newAge >= 0)
                {
                    _age = newAge;
                }
                else
                {
                    Console.WriteLine("Возраст не может быть отрицательным");
                }
            }
            public void ShowInfo()
            {
                Console.WriteLine("Возраст: " + _age);
            }
        }

    }
}
