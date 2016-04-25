using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTinyCollege.Models
{
    public class Course
    {

        /*By default the ID property will become the Primary Key of the database table
         * that corresponds to this class.  By default the EF (Entity Framework) 
         * interprets a property that's named ID or ClassNameID as the PK.
         * Also, this PK will have an IDENTITY Property, you can override it using 
         * the DatabaseGeneratedOption enum:
         *  -Computed:  Database generates a value when row is inserted or updated
         *  -Identity:  Database generates a value when row is inserted
         *  -None:      Database does not generate values
         */
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
         [Display(Name ="Number")]
        public int CourseID { get; set; }//PK - Note:  with No Identity Property

        [StringLength(50, MinimumLength =3)]
        public string Title { get; set; }

        [Range(0,5)]//Credits can be between 0 and 5
        public int Credits { get; set; }

        public int DepartmentID { get; set; }//FK to department


        //================== Navigation properties =======================

        //1 course to many enrollments
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        //1 course to many instructors
        public virtual ICollection<Instructor> Instructors { get; set; }

        //course belongs to a department
        public virtual Department Department { get; set; }

        //Combine the CourseID and title in on property
        public string CourseIdTitle
        {
            get
            {
                return CourseID + ": " + Title;
            }
        }

    }

}