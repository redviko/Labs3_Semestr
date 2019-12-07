using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05_2_KBIBAS187_3
{
    public class Student
    {
        public static Student Student1 { get; set; } //Реализцаия передачи данных между формами посредством статической переменной
        public static string[] AttributesNameStrings { get; } = new[]
            {"Имя", "Фамилия", "Отчество", "Специальность", "Курс", "Дата_рождения", "Место_рождения"};

        //private static Int32 StudentsFrom1Course(ref ListBox list, Int32 course)
        //{
        //    Int32 count = 0;
        //    foreach (Student student in list.Items)
        //    {
        //        if (student.Course == course)
        //        {
        //            count++;
        //        }
        //    }

        //    return count;
        //}

        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Name;
                    break;
                    case 1:
                        return Surname;
                    break;
                    case 2:
                        return Otchestvo;
                        break;
                    case 3:
                        return Specialization;
                    case 4:
                        return Course.ToString();
                    case 5:
                        return BirthDateTime.Day.ToString() + "." + BirthDateTime.Month.ToString() + "." +
                               BirthDateTime.Year.ToString();
                    break;
                    case 6:
                        return PlaceOfBirth;
                    break;
                    default:
                        throw new ArgumentException("Что-то не так с индесатором");
                        break;
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Name = value;
                        break;
                    case 1:
                         Surname= value;
                        break;
                    case 2:
                        Otchestvo= value;
                        break;
                    case 3: 
                        Specialization= value;
                        break;
                    case 4:
                        Course= int.Parse(value);
                        break;
                    case 5:
                        BirthDateTime=DateTime.Parse(value);
                        break;
                    case 6:
                        PlaceOfBirth=value;
                        break;
                    default:
                        throw new ArgumentException("Что-то не так с индесатором");
                        break;
                }
            }
        }

        public Student(String name, String surname, String otchestvo, String specialization, Int32 course, DateTime birthDateTime, String placeOfBirth)
        {
            if (surname != null) Surname = surname;
            if (otchestvo != null) Otchestvo = otchestvo;
            Course = course;
            if (name != null) Name = name;
            if (specialization != null) Specialization = specialization;
            BirthDateTime = birthDateTime;
            if (placeOfBirth != null) PlaceOfBirth = placeOfBirth;
        }

        
        public Student()
        {
        }

        public String Otchestvo { get; set; }
        public String Surname { get; set; }
        public String Name { get; set; }
        public String Specialization { get; set; }

        public int Course
        {
            get
            {
                if (_course != 0)
                {
                    return _course;
                }
                else
                {
                    throw new ArgumentNullException("Ошибка");
                }
            }
            set
            {
                if (value > 0 && value <= 10)
                {
                    _course = value;
                }
                else
                {
                    throw new ArgumentException("Сущетвует ли направление на которое учятся более 10 лет или вообще уходят в -лет?");
                }
            }
        }

        public DateTime BirthDateTime { get; set; }
        public String PlaceOfBirth { get; set; }

        private Int32 _course;
    }
}
