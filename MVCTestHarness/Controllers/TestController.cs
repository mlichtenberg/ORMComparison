using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using DA = ContosoUniversity.DataAccess;
using DANoSp = ContosoUniversity.DataAccessNoSp;
using Fluent = ContosoUniversity.FluentNH;
using FluentDomain = ContosoUniversity.FluentNH.Domain;
using NH = ContosoUniversity.NH;
using NHDomain = ContosoUniversity.NH.Domain;
using NHibernate.Linq;

namespace ContosoUniversity.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.Iterations = 500;
            List<Test> tests = new List<Test>();
            return View(tests);
        }

        // POST: Test
        [HttpPost]
        public ActionResult Index(string submit, string iterations)
        {
            ViewBag.Iterations = iterations;

            List<Test> tests = new List<Test>();

            if (submit == "All" || submit == "DALv1")
            {
                Dalv1Tests(tests, "DAL v1", Convert.ToInt32(iterations));
            }

            if (submit == "All" || submit == "DALv1-NoSp")
            {
                Dalv1NoSpTests(tests, "DAL v1 (no SPs)", Convert.ToInt32(iterations));
            }

            //if (submit == "All" || submit == "EF")
            if (submit == "EF")
            {
                DalEFTests(tests, "Entity Framework", Convert.ToInt32(iterations));
            }

            if (submit == "All" || submit == "EF-Optimized")
            {
                //DalEFOptiTests1(tests, "Entity Framework (No Autodetect)", Convert.ToInt32(iterations));
                //DalEFOptiTests2(tests, "Entity Framework (No Autodetect + Refresh Context)", Convert.ToInt32(iterations));
                DalEFOptiTests2(tests, "EF (Optimized)", Convert.ToInt32(iterations));
            }

            if (submit == "All" || submit == "NH")
            {
                DalNHTests(tests, "NHibernate (Optimized)", Convert.ToInt32(iterations));
            }

            if (submit == "All" || submit == "FluentNH")
            {
                DalFluentNHTests(tests, "Fluent NHibernate (Optimized)", Convert.ToInt32(iterations));
            }

            return View(tests);
        }

        private void Dalv1Tests(List<Test> tests, string library, int iterations)
        {
            List<int> ids = new List<int>();
            DA.EnrollmentDAL enrollmentDAL = new DA.EnrollmentDAL();

            // INSERT
            Test test = new Test(library, "Insert", iterations, DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                DataObjects.Enrollment enrollment = enrollmentDAL.EnrollmentInsertAuto(null, null, 101, 1, null);
                ids.Add(enrollment.EnrollmentID);
            }

            test.EndTime = DateTime.Now;
            tests.Add(test);

            //SELECT
            test = new Test(library, "Select", iterations, DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                DataObjects.Enrollment enrollment = enrollmentDAL.EnrollmentSelectAuto(null, null, ids[x]);
            }

            test.EndTime = DateTime.Now;
            tests.Add(test);

            // UPDATE
            test = new Test(library, "Update", iterations, DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                DataObjects.Enrollment enrollment = enrollmentDAL.EnrollmentUpdateAuto(null, null, ids[x], 101, 1, 0);
            }

            test.EndTime = DateTime.Now;
            tests.Add(test);

            // DELETE
            test = new Test(library, "Delete", iterations, DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                enrollmentDAL.EnrollmentDeleteAuto(null, null, ids[x]);
            }

            test.EndTime = DateTime.Now;
            tests.Add(test);
        }

        private void Dalv1NoSpTests(List<Test> tests, string library, int iterations)
        {
            List<int> ids = new List<int>();
            DANoSp.EnrollmentDAL enrollmentDALNoSp = new DANoSp.EnrollmentDAL();

            // INSERT
            Test test = new Test(library, "Insert", Convert.ToInt32(iterations), DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                DataObjects.Enrollment enrollment = enrollmentDALNoSp.EnrollmentInsertAuto(null, null, 101, 1, null);
                ids.Add(enrollment.EnrollmentID);
            }

            test.EndTime = DateTime.Now;
            tests.Add(test);

            //SELECT
            test = new Test(library, "Select", Convert.ToInt32(iterations), DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                DataObjects.Enrollment enrollment = enrollmentDALNoSp.EnrollmentSelectAuto(null, null, ids[x]);
            }

            test.EndTime = DateTime.Now;
            tests.Add(test);

            // UPDATE
            test = new Test(library, "Update", Convert.ToInt32(iterations), DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                DataObjects.Enrollment enrollment = enrollmentDALNoSp.EnrollmentUpdateAuto(null, null, ids[x], 101, 1, 0);
            }

            test.EndTime = DateTime.Now;
            tests.Add(test);

            // DELETE
            test = new Test(library, "Delete", Convert.ToInt32(iterations), DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                enrollmentDALNoSp.EnrollmentDeleteAuto(null, null, ids[x]);
            }

            test.EndTime = DateTime.Now;
            tests.Add(test);
        }

        private void DalEFTests(List<Test> tests, string library, int iterations)
        {
            List<int> ids = new List<int>();

            //INSERT
            using (SchoolContext db = new SchoolContext())
            {
                Test test = new Test(library, "Insert", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    Models.Enrollment enrollment = new Models.Enrollment { CourseID = 101, StudentID = 1, Grade = null };
                    db.Enrollments.Add(enrollment); // Takes about 25% of the time in this loop.  This statement alone makes EF INSERTs slower than the other frameworks.
                    db.SaveChanges();               // Takes the remaining 75% of the time in this loop
                    ids.Add(enrollment.EnrollmentID);
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //SELECT
            using (SchoolContext db = new SchoolContext())
            {
                Test test = new Test(library, "Select", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    int enrollmentID = ids[x];

                    // Option 1
                    // AsNoTracking() offers a slight performance improvement in disconnected scenarios (like web sites)
                    var enrollment = (from e in db.Enrollments.AsNoTracking() where e.EnrollmentID == enrollmentID select e).FirstOrDefault();

                    // Option 2
                    // Comparible performance to the previous statement
                    //var enrollment = db.Enrollments.AsNoTracking().FirstOrDefault(e => e.EnrollmentID == enrollmentID);

                    // Option 3
                    // (Much) slower than the previous two options.  AsNoTracking() cannot be used with the Find() method.
                    //var enrollment = db.Enrollments.Find(enrollmentID);
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //UPDATE
            using (SchoolContext db = new SchoolContext())
            {
                Test test = new Test(library, "Update", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    Models.Enrollment enrollment = new Models.Enrollment { EnrollmentID = ids[x], CourseID = 101, StudentID = 1, Grade = Grade.A };
                    db.Entry(enrollment).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //DELETE
            using (SchoolContext db = new SchoolContext())
            {
                Test test = new Test(library, "Delete", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    Models.Enrollment enrollment = new Models.Enrollment { EnrollmentID = ids[x] };
                    db.Entry(enrollment).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }
        }

        /// <summary>
        /// Turn off autodetect of changes
        /// </summary>
        /// <param name="tests"></param>
        /// <param name="library"></param>
        /// <param name="iterations"></param>
        private void DalEFOptiTests1(List<Test> tests, string library, int iterations)
        {
            List<int> ids = new List<int>();

            //INSERT
            using (SchoolContext db = new SchoolContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;

                Test test = new Test(library, "Insert", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    Models.Enrollment enrollment = new Models.Enrollment { CourseID = 101, StudentID = 1, Grade = null };
                    db.Enrollments.Add(enrollment); // Takes about 25% of the time in this loop.  This statement alone makes EF INSERTs slower than the other frameworks.
                    db.ChangeTracker.DetectChanges();
                    db.SaveChanges();               // Takes the remaining 75% of the time in this loop
                    ids.Add(enrollment.EnrollmentID);
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //SELECT
            using (SchoolContext db = new SchoolContext())
            {
                Test test = new Test(library, "Select", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    int enrollmentID = ids[x];

                    // AsNoTracking() offers a slight performance improvement in disconnected scenarios (like web sites)
                    var enrollment = (from e in db.Enrollments.AsNoTracking() where e.EnrollmentID == enrollmentID select e).FirstOrDefault();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //UPDATE
            using (SchoolContext db = new SchoolContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;

                Test test = new Test(library, "Update", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    Models.Enrollment enrollment = new Models.Enrollment { EnrollmentID = ids[x], CourseID = 101, StudentID = 1, Grade = Grade.A };
                    db.Entry(enrollment).State = System.Data.Entity.EntityState.Modified;
                    db.ChangeTracker.DetectChanges();
                    db.SaveChanges();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //DELETE
            using (SchoolContext db = new SchoolContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;

                Test test = new Test(library, "Delete", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    Models.Enrollment enrollment = new Models.Enrollment { EnrollmentID = ids[x] };
                    db.Entry(enrollment).State = System.Data.Entity.EntityState.Deleted;
                    db.ChangeTracker.DetectChanges();
                    db.SaveChanges();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }
        }

        /// <summary>
        /// Turn off autodetect of changes, and create a new dbContext after every 100 inserted/updated/deleted records
        /// </summary>
        /// <param name="tests"></param>
        /// <param name="library"></param>
        /// <param name="iterations"></param>
        private void DalEFOptiTests2(List<Test> tests, string library, int iterations)
        {
            List<int> ids = new List<int>();

            /*
			Here are some potential solutions to the performance issues with EF:
			http://stackoverflow.com/questions/10103310/dbcontext-is-very-slow-when-adding-and-deleting
			http://stackoverflow.com/questions/5943394/why-is-inserting-entities-in-ef-4-1-so-slow-compared-to-objectcontext/5943699#5943699
			http://stackoverflow.com/questions/5940225/fastest-way-of-inserting-in-entity-framework/5942176#5942176
			
			dbContext.Configuration.AutoDetectChangesEnabled = false;
			// Now do all your changes
			dbContext.ChangeTracker.DetectChanges();
			dbContext.SaveChanges();

			Calling SaveChanges() for each record slows bulk inserts extremely down. I would do a few simple 
			tests which will very likely improve the performance:
			- Call SaveChanges() once after ALL records.
			- Call SaveChanges() after for example 100 records.
			- Call SaveChanges() after for example 100 records and dispose the context and create a new one.
            ++ Dispose the context and create a new one after saving 100 records
			++ Disable change detection
			*/

            //INSERT
            Test insertTest = new Test(library, "Insert", Convert.ToInt32(iterations), DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                // Use a new context after every 100 Insert operations
                using (SchoolContext db = new SchoolContext())
                {
                    // 50% or better improvement by setting AutoDetectChangesEnabled and calling DetectChanges before SaveChanges
                    db.Configuration.AutoDetectChangesEnabled = false;

                    int count = 1;
                    for (int y = x; y < Convert.ToInt32(iterations); y++)
                    {
                        Models.Enrollment enrollment = new Models.Enrollment { CourseID = 101, StudentID = 1, Grade = null };
                        db.Enrollments.Add(enrollment);
                        db.ChangeTracker.DetectChanges();
                        db.SaveChanges();
                        ids.Add(enrollment.EnrollmentID);

                        count++;
                        if (count >= 100) break;
                        x++;
                    }
                }
            }

            insertTest.EndTime = DateTime.Now;
            tests.Add(insertTest);

            //SELECT
            using (SchoolContext db = new SchoolContext())
            {
                Test test = new Test(library, "Select", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    int enrollmentID = ids[x];

                    // AsNoTracking() offers a slight performance improvement in disconnected scenarios (like web sites)
                    var enrollment = (from e in db.Enrollments.AsNoTracking() where e.EnrollmentID == enrollmentID select e).FirstOrDefault();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //UPDATE
            Test updateTest = new Test(library, "Update", Convert.ToInt32(iterations), DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                // Use a new context after every 100 Update operations
                using (SchoolContext db = new SchoolContext())
                {
                    // 50% or better improvement by setting AutoDetectChangesEnabled and calling DetectChanges before SaveChanges
                    db.Configuration.AutoDetectChangesEnabled = false;

                    int count = 1;
                    for (int y = x; y < Convert.ToInt32(iterations); y++)
                    {
                        Models.Enrollment enrollment = new Models.Enrollment { EnrollmentID = ids[y], CourseID = 101, StudentID = 1, Grade = Grade.A };
                        db.Entry(enrollment).State = System.Data.Entity.EntityState.Modified;
                        db.ChangeTracker.DetectChanges();
                        db.SaveChanges();

                        count++;
                        if (count >= 100) break;
                        x++;
                    }
                }
            }

            updateTest.EndTime = DateTime.Now;
            tests.Add(updateTest);

            //DELETE
            Test deleteTest = new Test(library, "Delete", Convert.ToInt32(iterations), DateTime.Now);

            for (int x = 0; x < Convert.ToInt32(iterations); x++)
            {
                // Use a new context after every 100 Delete operations
                using (SchoolContext db = new SchoolContext())
                {
                    // Minor improvement by setting AutoDetectChangesEnabled and calling DetectChanges before SaveChanges
                    db.Configuration.AutoDetectChangesEnabled = false;

                    int count = 1;
                    for (int y = x; y < Convert.ToInt32(iterations); y++)
                    {
                        Models.Enrollment enrollment = new Models.Enrollment { EnrollmentID = ids[y] };
                        db.Entry(enrollment).State = System.Data.Entity.EntityState.Deleted;
                        db.ChangeTracker.DetectChanges();
                        db.SaveChanges();

                        count++;
                        if (count >= 100) break;
                        x++;
                    }
                }
            }

            deleteTest.EndTime = DateTime.Now;
            tests.Add(deleteTest);
        }


        /*
        Consider the following references for ideas on how to optimize both NHibernate and FluentNHibernate

        http://weblogs.asp.net/ricardoperes/on-nhibernate-performance

        Also Google 'nhibernate update optimization'

        */

        private void DalNHTests(List<Test> tests, string library, int iterations)
        {
            List<int> ids = new List<int>();

            //INSERT
            using (var session = NH.NhibernateSession.OpenSession("SchoolContext"))
            {
                var course = session.Get<NHDomain.Course>(101);
                var student = session.Get<NHDomain.Person>(1);

                Test test = new Test(library, "Insert", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    var enrollment = new NHDomain.Enrollment { Course = course, Person = student, Grade = null };
                    session.SaveOrUpdate(enrollment);

                    ids.Add(enrollment.Enrollmentid);
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //SELECT
            using (var session = NH.NhibernateSession.OpenSession("SchoolContext"))
            {
                Test test = new Test(library, "Select", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    int enrollmentID = ids[x];
                    // Faster
                    var enrollment = session.Get<NHDomain.Enrollment>(enrollmentID);

                    // (Much) Slower
                    //var enrollment2 = (from e in session.Query<NHDomain.Enrollment>()
                    //                 where e.Enrollmentid == enrollmentID
                    //                 select e).First();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //UPDATE
            using (var session = NH.NhibernateSession.OpenSession("SchoolContext"))
            {
                var course = session.Get<NHDomain.Course>(101);
                var student = session.Get<NHDomain.Person>(1);

                Test test = new Test(library, "Update", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    var enrollment = new NHDomain.Enrollment { Enrollmentid = ids[x], Course = course, Person = student, Grade = 1 };
                    session.Update(enrollment);
                    session.Flush();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //DELETE
            using (var session = NH.NhibernateSession.OpenSession("SchoolContext"))
            {
                var course = session.Get<NHDomain.Course>(101);
                var student = session.Get<NHDomain.Person>(1);

                Test test = new Test(library, "Delete", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    var enrollment = new NHDomain.Enrollment { Enrollmentid = ids[x], Course = course, Person = student, Grade = 1 };
                    session.Delete(enrollment);
                    session.Flush();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }
        }

        private void DalFluentNHTests(List<Test> tests, string library, int iterations)
        {
            List<int> ids = new List<int>();

            //INSERT
            using (var session = Fluent.NhibernateSession.OpenSession("SchoolContext"))
            {
                var course = session.Get<FluentDomain.Course>(101);
                var student = session.Get<FluentDomain.Person>(1);
                
                Test test = new Test(library, "Insert", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    var enrollment = new FluentDomain.Enrollment { Course = course, Person = student, Grade = null };
                    session.SaveOrUpdate(enrollment);

                    ids.Add(enrollment.Enrollmentid);
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //SELECT
            using (var session = Fluent.NhibernateSession.OpenSession("SchoolContext"))
            {
                Test test = new Test(library, "Select", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    int enrollmentID = ids[x];
                    // Faster
                    var enrollment = session.Get<FluentDomain.Enrollment>(enrollmentID);

                    // (Much) Slower
                    //var enrollment2 = (from e in session.Query<FluentDomain.Enrollment>()
                    //                 where e.Enrollmentid == enrollmentID
                    //                 select e).First();
 
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //UPDATE
            using (var session = Fluent.NhibernateSession.OpenSession("SchoolContext"))
            {
                var course = session.Get<FluentDomain.Course>(101);
                var student = session.Get<FluentDomain.Person>(1);

                Test test = new Test(library, "Update", Convert.ToInt32(iterations), DateTime.Now);

                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    var enrollment = new FluentDomain.Enrollment { Enrollmentid = ids[x], Course = course, Person = student, Grade = 1 };
                    session.Update(enrollment);
                    session.Flush();
                }

                test.EndTime = DateTime.Now;
                tests.Add(test);
            }

            //DELETE
            using (var session = Fluent.NhibernateSession.OpenSession("SchoolContext"))
            {
                Test test = new Test(library, "Delete", Convert.ToInt32(iterations), DateTime.Now);
                
                for (int x = 0; x < Convert.ToInt32(iterations); x++)
                {
                    int enrollmentID = ids[x];
                    var enrollment = new FluentDomain.Enrollment();
                    enrollment.Enrollmentid = enrollmentID;
                    session.Delete(enrollment);
                    session.Flush();
                }
                
                test.EndTime = DateTime.Now;
                tests.Add(test);
            }
        }
    }
}
 