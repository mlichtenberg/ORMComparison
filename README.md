# ORMComparison

This Visual Studio solution contains a MVC web site which allows a user to run a series of CRUD operations against a SQL Server database using one or more ORM frameworks and data access libraries.  The site records the time taken to perform the CRUD operations and displays the results.

The ORMs that can be tested using this solution are:

1) Entity Framework 6.1.3 (out-of-the-box, no optimization)
2) Entity Framework 6.1.3 (optimized)
3) NHibernate (optimized)
4) Fluent NHibernate (optimized)
5) A custom data access library.  Essentially straight ADO.NET.  Uses stored procedures for the CRUD operations.
6) A custom data access library.  Essentially straight ADO.NET.  Uses inline parameterized SQL for the CRUD operations.

To set up your environment to run this web site, do the following:

1) Create a SQL Server database.  Any version of SQL Server should do, including SQL Express.
2) Run the database script found in the DBScripts folder to create and populate the necessary database objects.  
3) Rename the web.config.template file found in the MVCTestHarness folder to web.config.
4) Update the database connection string in the web.config file to point to the new database.


I found that both Entity Framework and NHibernate perform rather poorly in their out-of-the-box configurations.  However, with some optimization, they can be made to perform comparably to the more-or-less straight ADO.NET data access libraries.  The code that drives the CRUD operations and includes most of the optimizations is found in the TestController.cs module in the MVCTestHarness project.  Some additional NHibernate optimizations are located in the NHibernateSession.cs modules found in the NH and FluentNH projects.

Here are some outcomes from my tests, including some non-optimized tests that the site no longer executes.  I have included them here to show how the out-of-the-box Entity Framework and NHibernate configurations affect performance.  Note that test results will vary on different hardware configurations.

Iterations  Library                        Operation  Start Time   End Time     Elapsed Time (seconds)

10000       Custom DAL                     Insert     7:29:18 PM   7:29:24 PM   5.9526039
10000       Custom DAL                     Select     7:29:24 PM   7:29:26 PM   1.9980745
10000       Custom DAL                     Update     7:29:26 PM   7:29:31 PM   5.0850357
10000       Custom DAL                     Delete     7:29:31 PM   7:29:35 PM   3.7785886

10000       Custom DAL (no SPs)            Insert     7:29:35 PM   7:29:40 PM   5.2251725
10000       Custom DAL (no SPs)            Select     7:29:40 PM   7:29:42 PM   2.0028176
10000       Custom DAL (no SPs)            Update     7:29:42 PM   7:29:46 PM   4.5381994
10000       Custom DAL (no SPs)            Delete     7:29:46 PM   7:29:50 PM   3.7064278

10000       Entity Framework               Insert     8:10:12 AM   8:27:27 AM   1034.6319736
10000	    Entity Framework               Select     8:27:27 AM   8:27:33 AM   5.9435846
10000	    Entity Framework               Update     8:27:33 AM   9:08:25 AM   2452.065295
10000	    Entity Framework               Delete     9:08:25 AM   9:08:48 AM   23.2425452

10000       EF (Optimized)                 Insert     7:29:50 PM   7:30:05 PM   14.7847024
10000       EF (Optimized)                 Select     7:30:05 PM   7:30:10 PM   5.5516514
10000       EF (Optimized)                 Update     7:30:10 PM   7:30:24 PM   13.823694
10000       EF (Optimized)                 Delete     7:30:24 PM   7:30:34 PM   10.0770142

10000       NHibernate	                   Insert     10:21:38 AM  10:21:45 AM  6.919129
10000       NHibernate	                   Select     10:21:45 AM  10:21:52 AM  7.101463
10000       NHibernate	                   Update     10:21:52 AM  10:26:23 AM  271.2916764
10000       NHibernate                     Delete     10:26:23 AM  10:26:32 AM  8.7065311

10000       NHibernate (Optimized)         Insert     7:30:34 PM   7:30:39 PM   5.0894047
10000       NHibernate (Optimized)         Select     7:30:39 PM   7:30:45 PM   5.2877312
10000       NHibernate (Optimized)         Update     7:30:45 PM   7:32:59 PM   133.9417387
10000       NHibernate (Optimized)         Delete     7:32:59 PM   7:33:04 PM   5.6669841

10000       Fluent NHibernate              Insert     10:26:32 AM  10:26:45 AM  12.7986932
10000       Fluent NHibernate              Select     10:26:45 AM  10:26:52 AM  7.0402496
10000       Fluent NHibernate              Update     10:26:52 AM  10:31:26 AM  273.8297312
10000       Fluent NHibernate              Delete     10:31:26 AM  10:31:39 AM  13.0518099

10000       Fluent NHibernate (Optimized)  Insert     7:33:04 PM   7:33:09 PM   5.0175024
10000       Fluent NHibernate (Optimized)  Select     7:33:09 PM   7:33:15 PM   5.2698945
10000       Fluent NHibernate (Optimized)  Update     7:33:15 PM   7:35:23 PM   128.3563561
10000       Fluent NHibernate (Optimized)  Delete     7:35:23 PM   7:35:28 PM   5.5299521


