using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12_Filatov_Vladyslav_Serhiyovych
{
    class Person
    {
        private string name;
        private int age;
        private Status status;
        private TimeSpan elapsedTime;
        private (int, int) coordinate;
        public int Age { 
            get { return age; }
            private set
            {
                if (value < 110 && value > 10)
                    age = value;
                else
                    throw new ArgumentException("Age entered incorrectly");                
            }
        }
        public string Name {
            get { return name; }
            private set
            {
                if (string.Compare(value, "") != 0)
                    name = value;
                else
                    throw new ArgumentException("Name must be filled");
            }
        }
        public Status Status { 
            get { return status; } 
            private set {
                if (value == Status.Ordinary || value == Status.Disabled)
                    status = value;
                else
                    throw new ArgumentException("No such status exists");
            }
        }
        public TimeSpan ElapsedTime { 
            get { return elapsedTime; }
            private set { 
                if(elapsedTime < new TimeSpan(01,00,00))
                    elapsedTime = value;
                else
                    throw new ArgumentException("Servicing can not take more than an hour");
            } }
        public (int, int) Coordinate { 
            get { return coordinate; } 
            private set { coordinate = value; } 
        }

        public Person(string name, int age, int status, TimeSpan elapsedTime, (int, int) coordinate)
        {
            Name = name;
            Age = age;
            Status = (Status)status;
            ElapsedTime = elapsedTime;
            Coordinate = coordinate;
        }

        public static bool ParsePerson(string input, out Person person)
        {
            string[] elements = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool ifParsed;

            string Name = "";
            int Age = 0;
            int Status = 0;
            TimeSpan ElapsedTime = new TimeSpan(0, 0, 0);
            (int,int) Coordinate = (0,0);

            try
            {
                Name = elements[0];
                Age = Convert.ToInt32(elements[1]);
                Status = Convert.ToInt32(elements[2]);
                TimeSpan.TryParse(elements[3].Trim(), out TimeSpan elapsedTime);
                ElapsedTime = elapsedTime;
                Coordinate = (Convert.ToInt32(elements[4]), Convert.ToInt32(elements[5]));

                ifParsed = true;
            }
            catch (FormatException)
            {
                ifParsed = false;
            }
            catch (NullReferenceException)
            {
                ifParsed = false;
            }
            catch (IndexOutOfRangeException)
            {
                ifParsed = false;
            }

            person = new Person(Name, Age, Status, ElapsedTime, Coordinate);

            return ifParsed;
        }

        public Status Priority() => (Status)((int)Status * Age);

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append($"Name: {name}");
            str.Append($"\nAge: {age}");
            str.Append($"\nStatus: {status}");
            str.Append($"\nTime: {elapsedTime}");
            str.Append($"\nCoordinate: {Coordinate}");
            str.Append($"\n");
            return str.ToString();  
        }
    }
}
