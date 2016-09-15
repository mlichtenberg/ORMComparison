
// Generated 4/7/2016 8:38:49 PM
// Do not modify the contents of this code file.
// This abstract class __Person is based upon dbo.Person.

#region How To Implement

// To implement, create another code file as outlined in the following example.
// It is recommended the code file you create be in the same project as this code file.
// Example:
// using System;
//
// namespace ContosoUniversity.DataObjects
// {
//		[Serializable]
// 		public class Person : __Person
//		{
//		}
// }

#endregion How To Implement

#region Using 

using System;
using System.Data;
using CustomDataAccess;

#endregion Using

namespace ContosoUniversity.DataObjects
{
	[Serializable]
	public abstract class __Person : CustomObjectBase, ICloneable, IComparable, IDisposable, ISetValues
	{
		#region Constructors
		
		/// <summary>
		/// Default constructor.
		/// </summary>
		public __Person()
		{
		}

		/// <summary>
		/// Overloaded constructor specifying each column value.
		/// </summary>
		/// <param name="iD"></param>
		/// <param name="lastName"></param>
		/// <param name="firstName"></param>
		/// <param name="hireDate"></param>
		/// <param name="enrollmentDate"></param>
		/// <param name="discriminator"></param>
		public __Person(int iD, 
			string lastName, 
			string firstName, 
			DateTime? hireDate, 
			DateTime? enrollmentDate, 
			string discriminator) : this()
		{
			_ID = iD;
			LastName = lastName;
			FirstName = firstName;
			HireDate = hireDate;
			EnrollmentDate = enrollmentDate;
			Discriminator = discriminator;
		}
		
		#endregion Constructors
		
		#region Destructor
		
		/// <summary>
		///
		/// </summary>
		~__Person()
		{
		}
		
		#endregion Destructor
		
		#region Set Values
		
		/// <summary>
		/// Set the property values of this instance from the specified <see cref="CustomDataRow"/>.
		/// </summary>
		public virtual void SetValues(CustomDataRow row)
		{
			foreach (CustomDataColumn column in row)
			{
				switch (column.Name)
				{
					case "ID" :
					{
						_ID = (int)column.Value;
						break;
					}
					case "LastName" :
					{
						_LastName = (string)column.Value;
						break;
					}
					case "FirstName" :
					{
						_FirstName = (string)column.Value;
						break;
					}
					case "HireDate" :
					{
						_HireDate = (DateTime?)column.Value;
						break;
					}
					case "EnrollmentDate" :
					{
						_EnrollmentDate = (DateTime?)column.Value;
						break;
					}
					case "Discriminator" :
					{
						_Discriminator = (string)column.Value;
						break;
					}
								}
			}
			
			IsNew = false;
		}
		
		#endregion Set Values
		
		#region Properties
		
		#region ID
		
		private int _ID = default(int);
		
		/// <summary>
		/// Column: ID;
		/// DBMS data type: int; Auto key;
		/// </summary>
		[ColumnDefinition("ID", DbTargetType=SqlDbType.Int, Ordinal=1, NumericPrecision=10, IsAutoKey=true, IsInForeignKey=true, IsInPrimaryKey=true)]
		public int ID
		{
			get
			{
				return _ID;
			}
			set
			{
				// NOTE: This dummy setter provides a work-around for the following: Read-only properties cannot be exposed by XML Web Services
				// see http://support.microsoft.com/kb/313584
				// Cause: When an object is passed i.e. marshalled to or from a Web service, it must be serialized into an XML stream and then deserialized back into an object.
				// The XML Serializer cannot deserialize the XML back into an object because it cannot load the read-only properties. 
				// Thus the read-only properties are not exposed through the Web Services Description Language (WSDL). 
				// Because the Web service proxy is generated from the WSDL, the proxy also excludes any read-only properties.
			}
		}
		
		#endregion ID
		
		#region LastName
		
		private string _LastName = string.Empty;
		
		/// <summary>
		/// Column: LastName;
		/// DBMS data type: nvarchar(50);
		/// </summary>
		[ColumnDefinition("LastName", DbTargetType=SqlDbType.NVarChar, Ordinal=2, CharacterMaxLength=50)]
		public string LastName
		{
			get
			{
				return _LastName;
			}
			set
			{
				if (value != null) value = CalibrateValue(value, 50);
				if (_LastName != value)
				{
					_LastName = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion LastName
		
		#region FirstName
		
		private string _FirstName = string.Empty;
		
		/// <summary>
		/// Column: FirstName;
		/// DBMS data type: nvarchar(50);
		/// </summary>
		[ColumnDefinition("FirstName", DbTargetType=SqlDbType.NVarChar, Ordinal=3, CharacterMaxLength=50)]
		public string FirstName
		{
			get
			{
				return _FirstName;
			}
			set
			{
				if (value != null) value = CalibrateValue(value, 50);
				if (_FirstName != value)
				{
					_FirstName = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion FirstName
		
		#region HireDate
		
		private DateTime? _HireDate = null;
		
		/// <summary>
		/// Column: HireDate;
		/// DBMS data type: datetime; Nullable;
		/// </summary>
		[ColumnDefinition("HireDate", DbTargetType=SqlDbType.DateTime, Ordinal=4, IsNullable=true)]
		public DateTime? HireDate
		{
			get
			{
				return _HireDate;
			}
			set
			{
				if (_HireDate != value)
				{
					_HireDate = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion HireDate
		
		#region EnrollmentDate
		
		private DateTime? _EnrollmentDate = null;
		
		/// <summary>
		/// Column: EnrollmentDate;
		/// DBMS data type: datetime; Nullable;
		/// </summary>
		[ColumnDefinition("EnrollmentDate", DbTargetType=SqlDbType.DateTime, Ordinal=5, IsNullable=true)]
		public DateTime? EnrollmentDate
		{
			get
			{
				return _EnrollmentDate;
			}
			set
			{
				if (_EnrollmentDate != value)
				{
					_EnrollmentDate = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion EnrollmentDate
		
		#region Discriminator
		
		private string _Discriminator = string.Empty;
		
		/// <summary>
		/// Column: Discriminator;
		/// DBMS data type: nvarchar(128);
		/// </summary>
		[ColumnDefinition("Discriminator", DbTargetType=SqlDbType.NVarChar, Ordinal=6, CharacterMaxLength=128)]
		public string Discriminator
		{
			get
			{
				return _Discriminator;
			}
			set
			{
				if (value != null) value = CalibrateValue(value, 128);
				if (_Discriminator != value)
				{
					_Discriminator = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion Discriminator
			
		#endregion Properties

		#region From Array serialization
		
		/// <summary>
		/// Deserializes the byte array and returns an instance of <see cref="__Person"/>.
		/// </summary>
		/// <returns>If the byte array can be deserialized and cast to an instance of <see cref="__Person"/>, 
		/// returns an instance of <see cref="__Person"/>; otherwise returns null.</returns>
		public static new __Person FromArray(byte[] byteArray)
		{
			__Person o = null;
			
			try
			{
				o = (__Person) CustomObjectBase.FromArray(byteArray);
			}
			catch (Exception e)
			{
				throw e;
			}

			return o;
		}
		
		#endregion From Array serialization

		#region CompareTo
		
		/// <summary>
		/// Compares this instance with a specified object. Throws an ArgumentException if the specified object is not of type <see cref="__Person"/>.
		/// </summary>
		/// <param name="obj">An <see cref="__Person"/> object to compare with this instance.</param>
		/// <returns>0 if the specified object equals this instance; -1 if the specified object does not equal this instance.</returns>
		public virtual int CompareTo(Object obj)
		{
			if (obj is __Person)
			{
				__Person o = (__Person) obj;
				
				if (
					o.IsNew == IsNew &&
					o.IsDeleted == IsDeleted &&
					o.ID == ID &&
					GetComparisonString(o.LastName) == GetComparisonString(LastName) &&
					GetComparisonString(o.FirstName) == GetComparisonString(FirstName) &&
					o.HireDate == HireDate &&
					o.EnrollmentDate == EnrollmentDate &&
					GetComparisonString(o.Discriminator) == GetComparisonString(Discriminator) 
				)
				{
					o = null;
					return 0; // true
				}
				else
				{
					o = null;
					return -1; // false
				}
			}
			else
			{
				throw new ArgumentException("Argument is not of type __Person");
			}
		}
 		
		#endregion CompareTo
		
		#region Operators
		
		/// <summary>
		/// Equality operator (==) returns true if the values of its operands are equal, false otherwise.
		/// </summary>
		/// <param name="a">The first <see cref="__Person"/> object to compare.</param>
		/// <param name="b">The second <see cref="__Person"/> object to compare.</param>
		/// <returns>true if values of operands are equal, false otherwise.</returns>
		public static bool operator == (__Person a, __Person b)
		{
			if (((Object) a) == null || ((Object) b) == null)
			{
				if (((Object) a) == null && ((Object) b) == null)
				{
					return true;
				}
			}
			else
			{
				int r = a.CompareTo(b);
				
				if (r == 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			return false;
		}
		
		/// <summary>
		/// Inequality operator (!=) returns false if its operands are equal, true otherwise.
		/// </summary>
		/// <param name="a">The first <see cref="__Person"/> object to compare.</param>
		/// <param name="b">The second <see cref="__Person"/> object to compare.</param>
		/// <returns>false if values of operands are equal, false otherwise.</returns>
		public static bool operator !=(__Person a, __Person b)
		{
			return !(a == b);
		}
		
		/// <summary>
		/// Returns true the specified object is equal to this object instance, false otherwise.
		/// </summary>
		/// <param name="obj">The <see cref="__Person"/> object to compare with the current <see cref="__Person"/>.</param>
		/// <returns>true if specified object is equal to the instance of this object, false otherwise.</returns>
		public override bool Equals(Object obj)
		{
			if (!(obj is __Person))
			{
				return false;
			}
			
			return this == (__Person) obj;
		}
	
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>Hash code for this instance as an integer.</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		#endregion Operators
		
		#region SortColumn
		
		/// <summary>
		/// Use when defining sort columns for a collection sort request.
		/// For example where list is a instance of <see cref="CustomGenericList">, 
		/// list.Sort(SortOrder.Ascending, __Person.SortColumn.ID);
		/// </summary>
		[Serializable]
		public sealed class SortColumn
		{	
			public const string ID = "ID";	
			public const string LastName = "LastName";	
			public const string FirstName = "FirstName";	
			public const string HireDate = "HireDate";	
			public const string EnrollmentDate = "EnrollmentDate";	
			public const string Discriminator = "Discriminator";
		}
				
		#endregion SortColumn
	}
}
// end of source generation

