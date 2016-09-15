
// Generated 4/7/2016 8:39:03 PM
// Do not modify the contents of this code file.
// This is part of a data access layer. 
// This partial class EnrollmentDAL is based upon dbo.Enrollment.

#region How To Implement

// To implement, create another code file as outlined in the following example.
// The code file you create must be in the same project as this code file.
// Example:
// using System;
//
// namespace ContosoUniversity.DataAccess
// {
// 		public partial class EnrollmentDAL
//		{
//		}
// }

#endregion How To Implement

#region using

using System;
using System.Data;
using System.Data.SqlClient;
using CustomDataAccess;
using ContosoUniversity.DataObjects;

#endregion using

namespace ContosoUniversity.DataAccess
{
	partial class EnrollmentDAL : IEnrollmentDAL
	{
 		#region ===== SELECT =====

		/// <summary>
		/// Select values from dbo.Enrollment by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="enrollmentID"></param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentSelectAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int enrollmentID)
		{
			return EnrollmentSelectAuto(	sqlConnection, sqlTransaction, "SchoolContext",	enrollmentID );
		}
			
		/// <summary>
		/// Select values from dbo.Enrollment by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="enrollmentID"></param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentSelectAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int enrollmentID )
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings( connectionKeyName ), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("EnrollmentSelectAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("EnrollmentID", SqlDbType.Int, null, false, enrollmentID)))
			{
				using (CustomSqlHelper<Enrollment> helper = new CustomSqlHelper<Enrollment>())
				{
					CustomGenericList<Enrollment> list = helper.ExecuteReader(command);
					if (list.Count > 0)
					{
						Enrollment o = list[0];
						list = null;
						return o;
					}
					else
					{
						return null;
					}
				}
			}
		}
		
		/// <summary>
		/// Select values from dbo.Enrollment by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="enrollmentID"></param>
		/// <returns>CustomGenericList&lt;CustomDataRow&gt;</returns>
		public CustomGenericList<CustomDataRow> EnrollmentSelectAutoRaw(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int enrollmentID)
		{
			return EnrollmentSelectAutoRaw( sqlConnection, sqlTransaction, "SchoolContext", enrollmentID );
		}
		
		/// <summary>
		/// Select values from dbo.Enrollment by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="enrollmentID"></param>
		/// <returns>CustomGenericList&lt;CustomDataRow&gt;</returns>
		public CustomGenericList<CustomDataRow> EnrollmentSelectAutoRaw(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int enrollmentID)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("EnrollmentSelectAuto", connection, transaction,
				CustomSqlHelper.CreateInputParameter("EnrollmentID", SqlDbType.Int, null, false, enrollmentID)))
			{
				return CustomSqlHelper.ExecuteReaderAndReturnRows(command);
			}
		}
		
		#endregion ===== SELECT =====

 		#region ===== INSERT =====

		/// <summary>
		/// Insert values into dbo.Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="courseID"></param>
		/// <param name="studentID"></param>
		/// <param name="grade"></param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int courseID,
			int studentID,
			int? grade)
		{
			return EnrollmentInsertAuto( sqlConnection, sqlTransaction, "SchoolContext", courseID, studentID, grade );
		}
		
		/// <summary>
		/// Insert values into dbo.Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="courseID"></param>
		/// <param name="studentID"></param>
		/// <param name="grade"></param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int courseID,
			int studentID,
			int? grade)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("EnrollmentInsertAuto", connection, transaction, 
				CustomSqlHelper.CreateOutputParameter("EnrollmentID", SqlDbType.Int, null, false),
					CustomSqlHelper.CreateInputParameter("CourseID", SqlDbType.Int, null, false, courseID),
					CustomSqlHelper.CreateInputParameter("StudentID", SqlDbType.Int, null, false, studentID),
					CustomSqlHelper.CreateInputParameter("Grade", SqlDbType.Int, null, true, grade), 
					CustomSqlHelper.CreateReturnValueParameter("ReturnCode", SqlDbType.Int, null, false)))
			{
				using (CustomSqlHelper<Enrollment> helper = new CustomSqlHelper<Enrollment>())
				{
					CustomGenericList<Enrollment> list = helper.ExecuteReader(command);
					if (list.Count > 0)
					{
						Enrollment o = list[0];
						list = null;
						return o;
					}
					else
					{
						return null;
					}
				}
			}
		}

		/// <summary>
		/// Insert values into dbo.Enrollment. Returns an object of type Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="value">Object of type Enrollment.</param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			Enrollment value)
		{
			return EnrollmentInsertAuto(sqlConnection, sqlTransaction, "SchoolContext", value);
		}
		
		/// <summary>
		/// Insert values into dbo.Enrollment. Returns an object of type Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="value">Object of type Enrollment.</param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			Enrollment value)
		{
			return EnrollmentInsertAuto(sqlConnection, sqlTransaction, connectionKeyName,
				value.CourseID,
				value.StudentID,
				value.Grade);
		}
		
		#endregion ===== INSERT =====

		#region ===== DELETE =====

		/// <summary>
		/// Delete values from dbo.Enrollment by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="enrollmentID"></param>
		/// <returns>true if successful otherwise false.</returns>
		public bool EnrollmentDeleteAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int enrollmentID)
		{
			return EnrollmentDeleteAuto( sqlConnection, sqlTransaction, "SchoolContext", enrollmentID );
		}
		
		/// <summary>
		/// Delete values from dbo.Enrollment by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="enrollmentID"></param>
		/// <returns>true if successful otherwise false.</returns>
		public bool EnrollmentDeleteAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int enrollmentID)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("EnrollmentDeleteAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("EnrollmentID", SqlDbType.Int, null, false, enrollmentID), 
					CustomSqlHelper.CreateReturnValueParameter("ReturnCode", SqlDbType.Int, null, false)))
			{
				int returnCode = CustomSqlHelper.ExecuteNonQuery(command, "ReturnCode");
				
				if (transaction == null)
				{
					CustomSqlHelper.CloseConnection(connection);
				}
				
				if (returnCode == 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		
		#endregion ===== DELETE =====

 		#region ===== UPDATE =====

		/// <summary>
		/// Update values in dbo.Enrollment. Returns an object of type Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="enrollmentID"></param>
		/// <param name="courseID"></param>
		/// <param name="studentID"></param>
		/// <param name="grade"></param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int enrollmentID,
			int courseID,
			int studentID,
			int? grade)
		{
			return EnrollmentUpdateAuto( sqlConnection, sqlTransaction, "SchoolContext", enrollmentID, courseID, studentID, grade);
		}
		
		/// <summary>
		/// Update values in dbo.Enrollment. Returns an object of type Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="enrollmentID"></param>
		/// <param name="courseID"></param>
		/// <param name="studentID"></param>
		/// <param name="grade"></param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int enrollmentID,
			int courseID,
			int studentID,
			int? grade)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("EnrollmentUpdateAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("EnrollmentID", SqlDbType.Int, null, false, enrollmentID),
					CustomSqlHelper.CreateInputParameter("CourseID", SqlDbType.Int, null, false, courseID),
					CustomSqlHelper.CreateInputParameter("StudentID", SqlDbType.Int, null, false, studentID),
					CustomSqlHelper.CreateInputParameter("Grade", SqlDbType.Int, null, true, grade), 
					CustomSqlHelper.CreateReturnValueParameter("ReturnCode", SqlDbType.Int, null, false)))
			{
				using (CustomSqlHelper<Enrollment> helper = new CustomSqlHelper<Enrollment>())
				{
					CustomGenericList<Enrollment> list = helper.ExecuteReader(command);
					if (list.Count > 0)
					{
						Enrollment o = list[0];
						list = null;
						return o;
					}
					else
					{
						return null;
					}
				}
			}
		}
		
		/// <summary>
		/// Update values in dbo.Enrollment. Returns an object of type Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="value">Object of type Enrollment.</param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			Enrollment value)
		{
			return EnrollmentUpdateAuto(sqlConnection, sqlTransaction, "SchoolContext", value );
		}
		
		/// <summary>
		/// Update values in dbo.Enrollment. Returns an object of type Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="value">Object of type Enrollment.</param>
		/// <returns>Object of type Enrollment.</returns>
		public Enrollment EnrollmentUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			Enrollment value)
		{
			return EnrollmentUpdateAuto(sqlConnection, sqlTransaction, connectionKeyName,
				value.EnrollmentID,
				value.CourseID,
				value.StudentID,
				value.Grade);
		}
		
		#endregion ===== UPDATE =====

		#region ===== MANAGE =====
		
		/// <summary>
		/// Manage dbo.Enrollment object.
		/// If the object is of type CustomObjectBase, 
		/// then either insert values into, delete values from, or update values in dbo.Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="value">Object of type Enrollment.</param>
		/// <returns>Object of type CustomDataAccessStatus<Enrollment>.</returns>
		public CustomDataAccessStatus<Enrollment> EnrollmentManageAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			Enrollment value  )
		{
			return EnrollmentManageAuto( sqlConnection, sqlTransaction, "SchoolContext", value  );
		}
		
		/// <summary>
		/// Manage dbo.Enrollment object.
		/// If the object is of type CustomObjectBase, 
		/// then either insert values into, delete values from, or update values in dbo.Enrollment.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="value">Object of type Enrollment.</param>
		/// <returns>Object of type CustomDataAccessStatus<Enrollment>.</returns>
		public CustomDataAccessStatus<Enrollment> EnrollmentManageAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			Enrollment value  )
		{
			if (value.IsNew && !value.IsDeleted)
			{
				
				
				Enrollment returnValue = EnrollmentInsertAuto(sqlConnection, sqlTransaction, connectionKeyName,
					value.CourseID,
						value.StudentID,
						value.Grade);
				
				return new CustomDataAccessStatus<Enrollment>(
					CustomDataAccessContext.Insert, 
					true, returnValue);
			}
			else if (!value.IsNew && value.IsDeleted)
			{
				if (EnrollmentDeleteAuto(sqlConnection, sqlTransaction, connectionKeyName,
					value.EnrollmentID))
				{
				return new CustomDataAccessStatus<Enrollment>(
					CustomDataAccessContext.Delete, 
					true, value);
				}
				else
				{
				return new CustomDataAccessStatus<Enrollment>(
					CustomDataAccessContext.Delete, 
					false, value);
				}
			}
			else if (value.IsDirty && !value.IsDeleted)
			{
				
				Enrollment returnValue = EnrollmentUpdateAuto(sqlConnection, sqlTransaction, connectionKeyName,
					value.EnrollmentID,
						value.CourseID,
						value.StudentID,
						value.Grade);
					
				return new CustomDataAccessStatus<Enrollment>(
					CustomDataAccessContext.Update, 
					true, returnValue);
			}
			else
			{
				return new CustomDataAccessStatus<Enrollment>(
					CustomDataAccessContext.NA, 
					false, value);
			}
		}
		
		#endregion ===== MANAGE =====

	}	
}

