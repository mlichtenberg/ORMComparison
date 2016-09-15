
// Generated 4/21/2016 11:12:01 PM
// Do not modify the contents of this code file.
// This is part of a data access layer. 
// This partial class PersonDAL is based upon dbo.Person.

#region How To Implement

// To implement, create another code file as outlined in the following example.
// The code file you create must be in the same project as this code file.
// Example:
// using System;
//
// namespace ContosoUniversity.DataAccessNoSp
// {
// 		public partial class PersonDAL
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
	partial class PersonDAL : IPersonDAL
	{
 		#region ===== SELECT =====

		/// <summary>
		/// Select values from dbo.Person by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="iD"></param>
		/// <returns>Object of type Person.</returns>
		public Person PersonSelectAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int iD)
		{
			return PersonSelectAuto(	sqlConnection, sqlTransaction, "SchoolContext",	iD );
		}
			
		/// <summary>
		/// Select values from dbo.Person by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="iD"></param>
		/// <returns>Object of type Person.</returns>
		public Person PersonSelectAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int iD )
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings( connectionKeyName ), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("PersonSelectAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("ID", SqlDbType.Int, null, false, iD)))
			{
				using (CustomSqlHelper<Person> helper = new CustomSqlHelper<Person>())
				{
					CustomGenericList<Person> list = helper.ExecuteReader(command);
					if (list.Count > 0)
					{
						Person o = list[0];
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
		/// Select values from dbo.Person by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="iD"></param>
		/// <returns>CustomGenericList&lt;CustomDataRow&gt;</returns>
		public CustomGenericList<CustomDataRow> PersonSelectAutoRaw(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int iD)
		{
			return PersonSelectAutoRaw( sqlConnection, sqlTransaction, "SchoolContext", iD );
		}
		
		/// <summary>
		/// Select values from dbo.Person by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="iD"></param>
		/// <returns>CustomGenericList&lt;CustomDataRow&gt;</returns>
		public CustomGenericList<CustomDataRow> PersonSelectAutoRaw(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int iD)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("PersonSelectAuto", connection, transaction,
				CustomSqlHelper.CreateInputParameter("ID", SqlDbType.Int, null, false, iD)))
			{
				return CustomSqlHelper.ExecuteReaderAndReturnRows(command);
			}
		}
		
		#endregion ===== SELECT =====

 		#region ===== INSERT =====

		/// <summary>
		/// Insert values into dbo.Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="lastName"></param>
		/// <param name="firstName"></param>
		/// <param name="hireDate"></param>
		/// <param name="enrollmentDate"></param>
		/// <param name="discriminator"></param>
		/// <returns>Object of type Person.</returns>
		public Person PersonInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string lastName,
			string firstName,
			DateTime? hireDate,
			DateTime? enrollmentDate,
			string discriminator)
		{
			return PersonInsertAuto( sqlConnection, sqlTransaction, "SchoolContext", lastName, firstName, hireDate, enrollmentDate, discriminator );
		}
		
		/// <summary>
		/// Insert values into dbo.Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="lastName"></param>
		/// <param name="firstName"></param>
		/// <param name="hireDate"></param>
		/// <param name="enrollmentDate"></param>
		/// <param name="discriminator"></param>
		/// <returns>Object of type Person.</returns>
		public Person PersonInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			string lastName,
			string firstName,
			DateTime? hireDate,
			DateTime? enrollmentDate,
			string discriminator)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("PersonInsertAuto", connection, transaction, 
				CustomSqlHelper.CreateOutputParameter("ID", SqlDbType.Int, null, false),
					CustomSqlHelper.CreateInputParameter("LastName", SqlDbType.NVarChar, 50, false, lastName),
					CustomSqlHelper.CreateInputParameter("FirstName", SqlDbType.NVarChar, 50, false, firstName),
					CustomSqlHelper.CreateInputParameter("HireDate", SqlDbType.DateTime, null, true, hireDate),
					CustomSqlHelper.CreateInputParameter("EnrollmentDate", SqlDbType.DateTime, null, true, enrollmentDate),
					CustomSqlHelper.CreateInputParameter("Discriminator", SqlDbType.NVarChar, 128, false, discriminator), 
					CustomSqlHelper.CreateReturnValueParameter("ReturnCode", SqlDbType.Int, null, false)))
			{
				using (CustomSqlHelper<Person> helper = new CustomSqlHelper<Person>())
				{
					CustomGenericList<Person> list = helper.ExecuteReader(command);
					if (list.Count > 0)
					{
						Person o = list[0];
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
		/// Insert values into dbo.Person. Returns an object of type Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="value">Object of type Person.</param>
		/// <returns>Object of type Person.</returns>
		public Person PersonInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			Person value)
		{
			return PersonInsertAuto(sqlConnection, sqlTransaction, "SchoolContext", value);
		}
		
		/// <summary>
		/// Insert values into dbo.Person. Returns an object of type Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="value">Object of type Person.</param>
		/// <returns>Object of type Person.</returns>
		public Person PersonInsertAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			Person value)
		{
			return PersonInsertAuto(sqlConnection, sqlTransaction, connectionKeyName,
				value.LastName,
				value.FirstName,
				value.HireDate,
				value.EnrollmentDate,
				value.Discriminator);
		}
		
		#endregion ===== INSERT =====

		#region ===== DELETE =====

		/// <summary>
		/// Delete values from dbo.Person by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="iD"></param>
		/// <returns>true if successful otherwise false.</returns>
		public bool PersonDeleteAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int iD)
		{
			return PersonDeleteAuto( sqlConnection, sqlTransaction, "SchoolContext", iD );
		}
		
		/// <summary>
		/// Delete values from dbo.Person by primary key(s).
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="iD"></param>
		/// <returns>true if successful otherwise false.</returns>
		public bool PersonDeleteAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int iD)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("PersonDeleteAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("ID", SqlDbType.Int, null, false, iD), 
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
		/// Update values in dbo.Person. Returns an object of type Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="iD"></param>
		/// <param name="lastName"></param>
		/// <param name="firstName"></param>
		/// <param name="hireDate"></param>
		/// <param name="enrollmentDate"></param>
		/// <param name="discriminator"></param>
		/// <returns>Object of type Person.</returns>
		public Person PersonUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			int iD,
			string lastName,
			string firstName,
			DateTime? hireDate,
			DateTime? enrollmentDate,
			string discriminator)
		{
			return PersonUpdateAuto( sqlConnection, sqlTransaction, "SchoolContext", iD, lastName, firstName, hireDate, enrollmentDate, discriminator);
		}
		
		/// <summary>
		/// Update values in dbo.Person. Returns an object of type Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="iD"></param>
		/// <param name="lastName"></param>
		/// <param name="firstName"></param>
		/// <param name="hireDate"></param>
		/// <param name="enrollmentDate"></param>
		/// <param name="discriminator"></param>
		/// <returns>Object of type Person.</returns>
		public Person PersonUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			int iD,
			string lastName,
			string firstName,
			DateTime? hireDate,
			DateTime? enrollmentDate,
			string discriminator)
		{
			SqlConnection connection = CustomSqlHelper.CreateConnection(CustomSqlHelper.GetConnectionStringFromConnectionStrings(connectionKeyName), sqlConnection);
			SqlTransaction transaction = sqlTransaction;
			
			using (SqlCommand command = CustomSqlHelper.CreateCommand("PersonUpdateAuto", connection, transaction, 
				CustomSqlHelper.CreateInputParameter("ID", SqlDbType.Int, null, false, iD),
					CustomSqlHelper.CreateInputParameter("LastName", SqlDbType.NVarChar, 50, false, lastName),
					CustomSqlHelper.CreateInputParameter("FirstName", SqlDbType.NVarChar, 50, false, firstName),
					CustomSqlHelper.CreateInputParameter("HireDate", SqlDbType.DateTime, null, true, hireDate),
					CustomSqlHelper.CreateInputParameter("EnrollmentDate", SqlDbType.DateTime, null, true, enrollmentDate),
					CustomSqlHelper.CreateInputParameter("Discriminator", SqlDbType.NVarChar, 128, false, discriminator), 
					CustomSqlHelper.CreateReturnValueParameter("ReturnCode", SqlDbType.Int, null, false)))
			{
				using (CustomSqlHelper<Person> helper = new CustomSqlHelper<Person>())
				{
					CustomGenericList<Person> list = helper.ExecuteReader(command);
					if (list.Count > 0)
					{
						Person o = list[0];
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
		/// Update values in dbo.Person. Returns an object of type Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="value">Object of type Person.</param>
		/// <returns>Object of type Person.</returns>
		public Person PersonUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			Person value)
		{
			return PersonUpdateAuto(sqlConnection, sqlTransaction, "SchoolContext", value );
		}
		
		/// <summary>
		/// Update values in dbo.Person. Returns an object of type Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="value">Object of type Person.</param>
		/// <returns>Object of type Person.</returns>
		public Person PersonUpdateAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			Person value)
		{
			return PersonUpdateAuto(sqlConnection, sqlTransaction, connectionKeyName,
				value.ID,
				value.LastName,
				value.FirstName,
				value.HireDate,
				value.EnrollmentDate,
				value.Discriminator);
		}
		
		#endregion ===== UPDATE =====

		#region ===== MANAGE =====
		
		/// <summary>
		/// Manage dbo.Person object.
		/// If the object is of type CustomObjectBase, 
		/// then either insert values into, delete values from, or update values in dbo.Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="value">Object of type Person.</param>
		/// <returns>Object of type CustomDataAccessStatus<Person>.</returns>
		public CustomDataAccessStatus<Person> PersonManageAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			Person value  )
		{
			return PersonManageAuto( sqlConnection, sqlTransaction, "SchoolContext", value  );
		}
		
		/// <summary>
		/// Manage dbo.Person object.
		/// If the object is of type CustomObjectBase, 
		/// then either insert values into, delete values from, or update values in dbo.Person.
		/// </summary>
		/// <param name="sqlConnection">Sql connection or null.</param>
		/// <param name="sqlTransaction">Sql transaction or null.</param>
		/// <param name="connectionKeyName">Connection key name located in config file.</param>
		/// <param name="value">Object of type Person.</param>
		/// <returns>Object of type CustomDataAccessStatus<Person>.</returns>
		public CustomDataAccessStatus<Person> PersonManageAuto(
			SqlConnection sqlConnection, 
			SqlTransaction sqlTransaction, 
			string connectionKeyName,
			Person value  )
		{
			if (value.IsNew && !value.IsDeleted)
			{
				
				
				Person returnValue = PersonInsertAuto(sqlConnection, sqlTransaction, connectionKeyName,
					value.LastName,
						value.FirstName,
						value.HireDate,
						value.EnrollmentDate,
						value.Discriminator);
				
				return new CustomDataAccessStatus<Person>(
					CustomDataAccessContext.Insert, 
					true, returnValue);
			}
			else if (!value.IsNew && value.IsDeleted)
			{
				if (PersonDeleteAuto(sqlConnection, sqlTransaction, connectionKeyName,
					value.ID))
				{
				return new CustomDataAccessStatus<Person>(
					CustomDataAccessContext.Delete, 
					true, value);
				}
				else
				{
				return new CustomDataAccessStatus<Person>(
					CustomDataAccessContext.Delete, 
					false, value);
				}
			}
			else if (value.IsDirty && !value.IsDeleted)
			{
				
				Person returnValue = PersonUpdateAuto(sqlConnection, sqlTransaction, connectionKeyName,
					value.ID,
						value.LastName,
						value.FirstName,
						value.HireDate,
						value.EnrollmentDate,
						value.Discriminator);
					
				return new CustomDataAccessStatus<Person>(
					CustomDataAccessContext.Update, 
					true, returnValue);
			}
			else
			{
				return new CustomDataAccessStatus<Person>(
					CustomDataAccessContext.NA, 
					false, value);
			}
		}
		
		#endregion ===== MANAGE =====

	}	
}

