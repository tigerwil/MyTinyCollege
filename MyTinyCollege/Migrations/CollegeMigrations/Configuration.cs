namespace MyTinyCollege.Migrations.CollegeMigrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyTinyCollege.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CollegeMigrations";
        }

        protected override void Seed(MyTinyCollege.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //1.  Add some students
            var students = new List<Student>
            {
                new Student {FirstName="Carson",
                             LastName ="Alexander" ,
                             EnrollmentDate=DateTime.Parse("2015-02-01"),
                             Email = "calexander@tinycollege.com"},
                new Student {FirstName="Alonso",
                             LastName ="Arturo" ,
                             EnrollmentDate=DateTime.Parse("2015-03-01"),
                             Email = "aarturo@tinycollege.com"},
                new Student {FirstName="John",
                             LastName ="Smith" ,
                             EnrollmentDate=DateTime.Parse("2015-05-10"),
                             Email = "jsmith@tinycollege.com"},
                new Student {FirstName="Fadi",
                             LastName ="Fakhouri" ,
                             EnrollmentDate=DateTime.Parse("2015-04-20"),
                             Email = "ffakhouri@tinycollege.com"},
                new Student {FirstName="Laura",
                             LastName ="Norman" ,
                             EnrollmentDate=DateTime.Parse("2015-02-15"),
                             Email = "lnorman@tinycollege.com"}
            };

            //Loop each student and add to database (only if they are not already present)
            //using the AddOrUpdate Method
            //The first parameter of this method specifies the property to check if a row already exists
            students.ForEach(s => context.Students.AddOrUpdate(p => p.Email,s));
            context.SaveChanges();

            //2. Add some instructors
            var instructors = new List<Instructor>
            {
                new Instructor { FirstName="Marc",
                                 LastName="Williams",
                                 HireDate=DateTime.Parse("1996-09-01"),
                                 Email="mwilliams@faculty.tinycollege.com"},
                new Instructor { FirstName="Frank",
                                 LastName="Bekkering",
                                 HireDate=DateTime.Parse("1996-07-01"),
                                 Email="fbekkering@faculty.tinycollege.com"}
            };
            instructors.ForEach(s => context.Instructors.AddOrUpdate(p => p.Email, s));
            context.SaveChanges();

            //3. Add some courses
            var courses = new List<Course>
            {
                new Course {CourseID =1045, Title="Chemistry",Credits=3},
                new Course {CourseID =4022, Title="Physics",Credits=3},
                new Course {CourseID =3141, Title="Calculus",Credits=3},
                new Course {CourseID =2021, Title="Literature",Credits=3},
            };

            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();
            //4. Add some enrollments



        }
    }
}
