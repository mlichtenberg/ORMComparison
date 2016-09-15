
// Generated 4/7/2016 8:38:56 PM
// Do not modify the contents of this code file.
// Interface ICourseDAL based upon dbo.Course.

#region using

using System;
using System.Data.SqlClient;
using CustomDataAccess;
using ContosoUniversity.DataObjects;

#endregion using

namespace ContosoUniversity.DataAccess
{
	public interface ICourseDAL
	{
		Course CourseSelectAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int courseID);

		Course CourseSelectAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int courseID);

		CustomGenericList<CustomDataRow> CourseSelectAutoRaw(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int courseID);

		CustomGenericList<CustomDataRow> CourseSelectAutoRaw(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int courseID);

		Course CourseInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int courseID,
			string title,
			int credits,
			int departmentID);

		Course CourseInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int courseID,
			string title,
			int credits,
			int departmentID);

		Course CourseInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, Course value);

		Course CourseInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName, Course value);

		bool CourseDeleteAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int courseID);

		bool CourseDeleteAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int courseID);

		Course CourseUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int courseID,
			string title,
			int credits,
			int departmentID);

		Course CourseUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int courseID,
			string title,
			int credits,
			int departmentID);

		Course CourseUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, Course value);

		Course CourseUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName, Course value);

		CustomDataAccessStatus<Course> CourseManageAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, Course value);

		CustomDataAccessStatus<Course> CourseManageAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName, Course value);


	}
}

