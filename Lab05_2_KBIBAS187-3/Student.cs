using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05_2_KBIBAS187_3
{
    class Student
    {
        private static Int32 StudentsFrom1Course(ref ListBox list, Int32 course)
        {
            Int32 count = 0;
            foreach (Student student in list.Items)
            {
                if (student.Course == course)
                {
                    count++;
                }
            }

            return count;
        }

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
                    throw new ArgumentException("Сущетвует ли направление на которое учятся более 10 лет?");
                }
            }
        }

        public DateTime BirthDateTime { get; set; }
        public String PlaceOfBirth { get; set; }

        private Int32 _course;
    }
}
