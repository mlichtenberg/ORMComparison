
// Generated 4/21/2016 11:12:10 PM
// Do not modify the contents of this code file.
// This is part of a data access layer. 
// This partial class CourseDAL is based upon dbo.Course.

#region How To Implement

// To implement, create another code file as outlined in the following example.
// The code file you create must be in the same project as this code file.
// Example:
// using System;
//
// namespace ContosoUniversity.DataAccessNoSp
// {
// 		public partial class CourseDAL
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

namespace ContosoUniversity.DataAccessNoSp
{
	partial class CourseDAL : ICourseDAL
	{
 		#region ===== SELECT =====

		/// <summary>
		/// Select values from dbo.Course by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="courseID"></param>
		/// <returns>Object of type Course.</returns>
		public Course CourseSelectAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int courseID)
		{
			return CourseSelectAuto(	sqlConnection, sqlTransaction, "SchoolContext",	courseID );
		}
			
		/// <summary>
		/// Select values from dbo.Course by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="courseID"></param>
		/// <returns>Object of type Course.</returns>
		public Course CourseSelectAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int courseID )
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings( connectionKeyName ), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("CourseSelectAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("CourseID", SqlDbType.Int, null, false, courseID)))
			{
				using (CustomSqlHelper<Course> helper = new CustomSqlHelper<Course>())
				{
					CustomGenericList<Course> list = helper.ExecuteReader(command);
					if (list.Count > 0)
					{
						Course o = list[0];
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
		/// Select values from dbo.Course by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="courseID"></param>
		/// <returns>CustomGenericList&lt;CustomDataRow&gt;</returns>
		public CustomGenericList<CustomDataRow> CourseSelectAutoRaw(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int courseID)
		{
			return CourseSelectAutoRaw( sqlConnection, sqlTransaction, "SchoolContext", courseID );
		}
		
		/// <summary>
		/// Select values from dbo.Course by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="courseID"></param>
		/// <returns>CustomGenericList&lt;CustomDataRow&gt;</returns>
		public CustomGenericList<CustomDataRow> CourseSelectAutoRaw(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int courseID)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("CourseSelectAuto", connection, transaction,
				CustomSqlHelper.CreateInputParameter("CourseID", SqlDbType.Int, null, false, courseID)))
			{
				return CustomSqlHelper.ExecuteReaderAndReturnRows(command);
			}
		}
		
		#endregion ===== SELECT =====

 		#region ===== INSERT =====

		/// <summary>
		/// Insert values into dbo.Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="courseID"></param>
		/// <param name="title"></param>
		/// <param name="credits"></param>
		/// <param name="departmentID"></param>
		/// <returns>Object of type Course.</returns>
		public Course CourseInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int courseID,
			string title,
			int credits,
			int departmentID)
		{
			return CourseInsertAuto( sqlConnection, sqlTransaction, "SchoolContext", courseID, title, credits, departmentID );
		}
		
		/// <summary>
		/// Insert values into dbo.Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="courseID"></param>
		/// <param name="title"></param>
		/// <param name="credits"></param>
		/// <param name="departmentID"></param>
		/// <returns>Object of type Course.</returns>
		public Course CourseInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int courseID,
			string title,
			int credits,
			int departmentID)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("CourseInsertAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("CourseID", SqlDbType.Int, null, false, courseID),
					CustomSqlHelper.CreateInputParameter("Title", SqlDbType.NVarChar, 50, true, title),
					CustomSqlHelper.CreateInputParameter("Credits", SqlDbType.Int, null, false, credits),
					CustomSqlHelper.CreateInputParameter("DepartmentID", SqlDbType.Int, null, false, departmentID), 
					CustomSqlHelper.CreateReturnValueParameter("ReturnCode", SqlDbType.Int, null, false)))
			{
				using (CustomSqlHelper<Course> helper = new CustomSqlHelper<Course>())
				{
					CustomGenericList<Course> list = helper.ExecuteReader(command);
					if (list.Count > 0)
					{
						Course o = list[0];
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
		/// Insert values into dbo.Course. Returns an object of type Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="value">Object of type Course.</param>
		/// <returns>Object of type Course.</returns>
		public Course CourseInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			Course value)
		{
			return CourseInsertAuto(sqlConnection, sqlTransaction, "SchoolContext", value);
		}
		
		/// <summary>
		/// Insert values into dbo.Course. Returns an object of type Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="value">Object of type Course.</param>
		/// <returns>Object of type Course.</returns>
		public Course CourseInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			Course value)
		{
			return CourseInsertAuto(sqlConnection, sqlTransaction, connectionKeyName,
				value.CourseID,
				value.Title,
				value.Credits,
				value.DepartmentID);
		}
		
		#endregion ===== INSERT =====

		#region ===== DELETE =====

		/// <summary>
		/// Delete values from dbo.Course by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="courseID"></param>
		/// <returns>true if successful otherwise false.</returns>
		public bool CourseDeleteAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int courseID)
		{
			return CourseDeleteAuto( sqlConnection, sqlTransaction, "SchoolContext", courseID );
		}
		
		/// <summary>
		/// Delete values from dbo.Course by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="courseID"></param>
		/// <returns>true if successful otherwise false.</returns>
		public bool CourseDeleteAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int courseID)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("CourseDeleteAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("CourseID", SqlDbType.Int, null, false, courseID), 
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
		/// Update values in dbo.Course. Returns an object of type Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="courseID"></param>
		/// <param name="title"></param>
		/// <param name="credits"></param>
		/// <param name="departmentID"></param>
		/// <returns>Object of type Course.</returns>
		public Course CourseUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int courseID,
			string title,
			int credits,
			int departmentID)
		{
			return CourseUpdateAuto( sqlConnection, sqlTransaction, "SchoolContext", courseID, title, credits, departmentID);
		}
		
		/// <summary>
		/// Update values in dbo.Course. Returns an object of type Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="courseID"></param>
		/// <param name="title"></param>
		/// <param name="credits"></param>
		/// <param name="departmentID"></param>
		/// <returns>Object of type Course.</returns>
		public Course CourseUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int courseID,
			string title,
			int credits,
			int departmentID)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("CourseUpdateAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("CourseID", SqlDbType.Int, null, false, courseID),
					CustomSqlHelper.CreateInputParameter("Title", SqlDbType.NVarChar, 50, true, title),
					CustomSqlHelper.CreateInputParameter("Credits", SqlDbType.Int, null, false, credits),
					CustomSqlHelper.CreateInputParameter("DepartmentID", SqlDbType.Int, null, false, departmentID), 
					CustomSqlHelper.CreateReturnValueParameter("ReturnCode", SqlDbType.Int, null, false)))
			{
				using (CustomSqlHelper<Course> helper = new CustomSqlHelper<Course>())
				{
					CustomGenericList<Course> list = helper.ExecuteReader(command);
					if (list.Count > 0)
					{
						Course o = list[0];
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
		/// Update values in dbo.Course. Returns an object of type Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="value">Object of type Course.</param>
		/// <returns>Object of type Course.</returns>
		public Course CourseUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			Course value)
		{
			return CourseUpdateAuto(sqlConnection, sqlTransaction, "SchoolContext", value );
		}
		
		/// <summary>
		/// Update values in dbo.Course. Returns an object of type Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="value">Object of type Course.</param>
		/// <returns>Object of type Course.</returns>
		public Course CourseUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			Course value)
		{
			return CourseUpdateAuto(sqlConnection, sqlTransaction, connectionKeyName,
				value.CourseID,
				value.Title,
				value.Credits,
				value.DepartmentID);
		}
		
		#endregion ===== UPDATE =====

		#region ===== MANAGE =====
		
		/// <summary>
		/// Manage dbo.Course object.
		/// If the object is of type CustomObjectBase, 
		/// then either insert values into, delete values from, or update values in dbo.Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="value">Object of type Course.</param>
		/// <returns>Object of type CustomDataAccessStatus<Course>.</returns>
		public CustomDataAccessStatus<Course> CourseManageAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			Course value  )
		{
			return CourseManageAuto( sqlConnection, sqlTransaction, "SchoolContext", value  );
		}
		
		/// <summary>
		/// Manage dbo.Course object.
		/// If the object is of type CustomObjectBase, 
		/// then either insert values into, delete values from, or update values in dbo.Course.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="value">Object of type Course.</param>
		/// <returns>Object of type CustomDataAccessStatus<Course>.</returns>
		public CustomDataAccessStatus<Course> CourseManageAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			Course value  )
		{
			if (value.IsNew && !value.IsDeleted)
			{
				
				
				Course returnValue = CourseInsertAuto(sqlConnection, sqlTransaction, connectionKeyName,
					value.CourseID,
						value.Title,
						value.Credits,
						value.DepartmentID);
				
				return new CustomDataAccessStatus<Course>(
					CustomDataAccessContext.Insert, 
					true, returnValue);
			}
			else if (!value.IsNew && value.IsDeleted)
			{
				if (CourseDeleteAuto(sqlConnection, sqlTransaction, connectionKeyName,
					value.CourseID))
				{
				return new CustomDataAccessStatus<Course>(
					CustomDataAccessContext.Delete, 
					true, value);
				}
				else
				{
				return new CustomDataAccessStatus<Course>(
					CustomDataAccessContext.Delete, 
					false, value);
				}
			}
			else if (value.IsDirty && !value.IsDeleted)
			{
				
				Course returnValue = CourseUpdateAuto(sqlConnection, sqlTransaction, connectionKeyName,
					value.CourseID,
						value.Title,
						value.Credits,
						value.DepartmentID);
					
				return new CustomDataAccessStatus<Course>(
					CustomDataAccessContext.Update, 
					true, returnValue);
			}
			else
			{
				return new CustomDataAccessStatus<Course>(
					CustomDataAccessContext.NA, 
					false, value);
			}
		}
		
		#endregion ===== MANAGE =====

	}	
}

