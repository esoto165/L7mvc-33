//tinfo200:[2021-03-03-sotoe-dykstra1] - created the Course class to use as multiple enrollments to be assigned to one course entity (multiple seats in one class)


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Course
    {
        //tinfo200:[2021-03-03-sotoe-dykstra1] - Auto implemented attributes of course
        // and attributes list of enrollment entities for the primary key of CourseID
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollemnts { get; set; }
    }
}
