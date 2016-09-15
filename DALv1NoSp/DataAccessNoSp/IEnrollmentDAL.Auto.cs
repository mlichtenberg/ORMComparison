
// Generated 4/21/2016 11:12:48 PM
// Do not modify the contents of this code file.
// Interface IEnrollmentDAL based upon dbo.Enrollment.

#region using

using System;
using System.Data.SqlClient;
using CustomDataAccess;
using ContosoUniversity.DataObjects;

#endregion using

namespace ContosoUniversity.DataAccessNoSp
{
	public interface IEnrollmentDAL
	{
		Enrollment EnrollmentSelectAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int enrollmentID);

		Enrollment EnrollmentSelectAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int enrollmentID);

		CustomGenericList<CustomDataRow> EnrollmentSelectAutoRaw(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int enrollmentID);

		CustomGenericList<CustomDataRow> EnrollmentSelectAutoRaw(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int enrollmentID);

		Enrollment EnrollmentInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int courseID,
			int studentID,
			int? grade);

		Enrollment EnrollmentInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int courseID,
			int studentID,
			int? grade);

		Enrollment EnrollmentInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, Enrollment value);

		Enrollment EnrollmentInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName, Enrollment value);

		bool EnrollmentDeleteAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int enrollmentID);

		bool EnrollmentDeleteAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int enrollmentID);

		Enrollment EnrollmentUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int enrollmentID,
			int courseID,
			int studentID,
			int? grade);

		Enrollment EnrollmentUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int enrollmentID,
			int courseID,
			int studentID,
			int? grade);

		Enrollment EnrollmentUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, Enrollment value);

		Enrollment EnrollmentUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName, Enrollment value);

		CustomDataAccessStatus<Enrollment> EnrollmentManageAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, Enrollment value);

		CustomDataAccessStatus<Enrollment> EnrollmentManageAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName, Enrollment value);


	}
}

