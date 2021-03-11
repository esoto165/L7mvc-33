//tinfo200:[2021-03-03-sotoe-dykstra1] - created the Enrollment class to use as one student entity for multiple enrollments allowing to be assigned to one course


namespace ContosoUniversity.Models
{
    //tinfo200:[2021-03-03-sotoe-dykstra1] - enumaration of valid grade input for student course attribute
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        //tinfo200:[2021-03-03-sotoe-dykstra1] - auto implemented primary keys with the grade attribute allowing
        // for a nullible value which may relate to a class currently in progress and final grade not assigned yet
        // grade is encapsulated within the student/course
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public Student Student { get; set; }
    }
}