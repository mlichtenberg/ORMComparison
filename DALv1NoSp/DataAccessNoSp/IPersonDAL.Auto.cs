
// Generated 4/21/2016 11:12:01 PM
// Do not modify the contents of this code file.
// Interface IPersonDAL based upon dbo.Person.

#region using

using System;
using System.Data.SqlClient;
using CustomDataAccess;
using ContosoUniversity.DataObjects;

#endregion using

namespace ContosoUniversity.DataAccessNoSp
{
	public interface IPersonDAL
	{
		Person PersonSelectAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int iD);

		Person PersonSelectAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int iD);

		CustomGenericList<CustomDataRow> PersonSelectAutoRaw(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int iD);

		CustomGenericList<CustomDataRow> PersonSelectAutoRaw(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int iD);

		Person PersonInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			string lastName,
			string firstName,
			DateTime? hireDate,
			DateTime? enrollmentDate,
			string discriminator);

		Person PersonInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			string lastName,
			string firstName,
			DateTime? hireDate,
			DateTime? enrollmentDate,
			string discriminator);

		Person PersonInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, Person value);

		Person PersonInsertAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName, Person value);

		bool PersonDeleteAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int iD);

		bool PersonDeleteAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int iD);

		Person PersonUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction,
			int iD,
			string lastName,
			string firstName,
			DateTime? hireDate,
			DateTime? enrollmentDate,
			string discriminator);

		Person PersonUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName,
			int iD,
			string lastName,
			string firstName,
			DateTime? hireDate,
			DateTime? enrollmentDate,
			string discriminator);

		Person PersonUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, Person value);

		Person PersonUpdateAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName, Person value);

		CustomDataAccessStatus<Person> PersonManageAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, Person value);

		CustomDataAccessStatus<Person> PersonManageAuto(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string connectionKeyName, Person value);


	}
}

