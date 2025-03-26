using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsul
{
    internal class BankAccount
    {
        private double _balance;
        public BankAccount(double initialBalance)
        {
            if (initialBalance >= 0)
            {
                _balance = initialBalance;
            }
            else
            {
                _balance = 0;
                Console.WriteLine("Баланс не может быть отрицательным");
            }
        }
        public void Deposit(double amount)
        {
            if (amount >= 0)
            {
                _balance += amount;
                Console.WriteLine("Пополнение на " + amount + "Новый баланс: " + _balance);
            }
            else
            {
                Console.WriteLine("Сумма пополнения должна быть положительной");
            }
        }
        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= _balance)
            {
                _balance -= amount;
                Console.WriteLine("Снятие " + amount + "руб. Остаток: " + _balance + " руб.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств или некорректнаяя сумма");
            }
        }
        public void ShowBalance()
        {
            Console.WriteLine("Текущий баланс: " + _balance);
        }
    }
}
