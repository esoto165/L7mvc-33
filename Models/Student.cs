//tinfo200:[2021-03-03-sotoe-dykstra1] - created the Student class to use as one student entity for multiple class enrollments

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Student
    {
        //tinfo200:[2021-03-03-sotoe-dykstra1] - Auto implemented primary keys establishing Student attributes,
        // attributes with the capability of multiple assignements are contained in a list for CRUD operations (class list for student)
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
