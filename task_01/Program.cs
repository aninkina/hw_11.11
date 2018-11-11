/*
 Задача с семинара номер 1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_01
{
    class Birthday
    {
        string _name, _timeBirth;
        int _year, _day, _month;

        public Birthday(string name, int year, int month, int day)
        {
            _name = name;
            _year = year;
            _month = month;
            _day = day;
        }

        DateTime Date
        {
            get { return new DateTime(_year, _month, _day); }
        }
        public string Information
        {
            get
            {
                return _name + ", дата рождения " + _day + ":" + _month + ":" + _year;
            }
        }
        // Calculate number of days to the next birthday
        public int HowManyDays
        {
            get
            {
                int nowDOY = DateTime.Now.DayOfYear;
                int myDOY = Date.DayOfYear;
                int period = myDOY <= nowDOY ? myDOY - nowDOY + 365 : myDOY - nowDOY;
                return period;
            }
        }
        // Info of birthday(as ' 1st Janary 1999 ')
        public string BirthInfo_1
        {
            get
            {
                string monthInfo = "";
                switch (_month)
                {
                    case 1: monthInfo = "Января"; break;
                    case 2: monthInfo = "Февраля"; break;
                    case 3: monthInfo = "Марта"; break;
                    case 4: monthInfo = "Апреля"; break;
                    case 5: monthInfo = "Мая"; break;
                    case 6: monthInfo = "Июня"; break;
                    case 7: monthInfo = "Июля"; break;
                    case 8: monthInfo = "Августа"; break;
                    case 9: monthInfo = "Сентября"; break;
                    case 10: monthInfo = "Октября"; break;
                    case 11: monthInfo = "Ноября"; break;
                    case 12: monthInfo = "Декабря"; break;
                }
                return $"{_day} {monthInfo} {_year}";
            }
        }
        // Info of birthday(as ' 01-01-99')
        public string BirthInfo_2
        {
            get
            {
                int yearNewFormat = _year % 100;
                string dayNewFormat = (0 + _day / 10).ToString() + (_day % 10).ToString();
                string monthNewFormat = (0 + _month / 10).ToString() + (_month % 10).ToString();


                return $"{dayNewFormat}-{monthNewFormat}-{yearNewFormat}";


            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            // Create date of birhday, calculate how many days to next birhday
            Birthday md = new Birthday("Чапаев", 1887, 2, 9);
            Console.WriteLine(md.Information);
            Console.WriteLine("До следующего дня рождения дней осталось: ");
            Console.WriteLine(md.HowManyDays);
            Console.WriteLine();
            Console.WriteLine(md.BirthInfo_1);
            Console.WriteLine(md.BirthInfo_2);

            Birthday km = new Birthday("Маркс Карл", 1818, 5, 4);
            Console.WriteLine(km.Information);
            Console.WriteLine("До следующего дня рождения дней осталось: ");
            Console.WriteLine(km.HowManyDays);
            Console.ReadKey();

        }
    }
}
