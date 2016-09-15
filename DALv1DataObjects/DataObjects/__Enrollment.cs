
// Generated 4/7/2016 8:39:03 PM
// Do not modify the contents of this code file.
// This abstract class __Enrollment is based upon dbo.Enrollment.

#region How To Implement

// To implement, create another code file as outlined in the following example.
// It is recommended the code file you create be in the same project as this code file.
// Example:
// using System;
//
// namespace ContosoUniversity.DataObjects
// {
//		[Serializable]
// 		public class Enrollment : __Enrollment
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
	public abstract class __Enrollment : CustomObjectBase, ICloneable, IComparable, IDisposable, ISetValues
	{
		#region Constructors
		
		/// <summary>
		/// Default constructor.
		/// </summary>
		public __Enrollment()
		{
		}

		/// <summary>
		/// Overloaded constructor specifying each column value.
		/// </summary>
		/// <param name="enrollmentID"></param>
		/// <param name="courseID"></param>
		/// <param name="studentID"></param>
		/// <param name="grade"></param>
		public __Enrollment(int enrollmentID, 
			int courseID, 
			int studentID, 
			int? grade) : this()
		{
			_EnrollmentID = enrollmentID;
			CourseID = courseID;
			StudentID = studentID;
			Grade = grade;
		}
		
		#endregion Constructors
		
		#region Destructor
		
		/// <summary>
		///
		/// </summary>
		~__Enrollment()
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
					case "EnrollmentID" :
					{
						_EnrollmentID = (int)column.Value;
						break;
					}
					case "CourseID" :
					{
						_CourseID = (int)column.Value;
						break;
					}
					case "StudentID" :
					{
						_StudentID = (int)column.Value;
						break;
					}
					case "Grade" :
					{
						_Grade = (int?)column.Value;
						break;
					}
								}
			}
			
			IsNew = false;
		}
		
		#endregion Set Values
		
		#region Properties
		
		#region EnrollmentID
		
		private int _EnrollmentID = default(int);
		
		/// <summary>
		/// Column: EnrollmentID;
		/// DBMS data type: int; Auto key;
		/// </summary>
		[ColumnDefinition("EnrollmentID", DbTargetType=SqlDbType.Int, Ordinal=1, NumericPrecision=10, IsAutoKey=true, IsInPrimaryKey=true)]
		public int EnrollmentID
		{
			get
			{
				return _EnrollmentID;
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
		
		#endregion EnrollmentID
		
		#region CourseID
		
		private int _CourseID = default(int);
		
		/// <summary>
		/// Column: CourseID;
		/// DBMS data type: int;
		/// </summary>
		[ColumnDefinition("CourseID", DbTargetType=SqlDbType.Int, Ordinal=2, NumericPrecision=10, IsInForeignKey=true)]
		public int CourseID
		{
			get
			{
				return _CourseID;
			}
			set
			{
				if (_CourseID != value)
				{
					_CourseID = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion CourseID
		
		#region StudentID
		
		private int _StudentID = default(int);
		
		/// <summary>
		/// Column: StudentID;
		/// DBMS data type: int;
		/// </summary>
		[ColumnDefinition("StudentID", DbTargetType=SqlDbType.Int, Ordinal=3, NumericPrecision=10, IsInForeignKey=true)]
		public int StudentID
		{
			get
			{
				return _StudentID;
			}
			set
			{
				if (_StudentID != value)
				{
					_StudentID = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion StudentID
		
		#region Grade
		
		private int? _Grade = null;
		
		/// <summary>
		/// Column: Grade;
		/// DBMS data type: int; Nullable;
		/// </summary>
		[ColumnDefinition("Grade", DbTargetType=SqlDbType.Int, Ordinal=4, NumericPrecision=10, IsNullable=true)]
		public int? Grade
		{
			get
			{
				return _Grade;
			}
			set
			{
				if (_Grade != value)
				{
					_Grade = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion Grade
			
		#endregion Properties

		#region From Array serialization
		
		/// <summary>
		/// Deserializes the byte array and returns an instance of <see cref="__Enrollment"/>.
		/// </summary>
		/// <returns>If the byte array can be deserialized and cast to an instance of <see cref="__Enrollment"/>, 
		/// returns an instance of <see cref="__Enrollment"/>; otherwise returns null.</returns>
		public static new __Enrollment FromArray(byte[] byteArray)
		{
			__Enrollment o = null;
			
			try
			{
				o = (__Enrollment) CustomObjectBase.FromArray(byteArray);
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
		/// Compares this instance with a specified object. Throws an ArgumentException if the specified object is not of type <see cref="__Enrollment"/>.
		/// </summary>
		/// <param name="obj">An <see cref="__Enrollment"/> object to compare with this instance.</param>
		/// <returns>0 if the specified object equals this instance; -1 if the specified object does not equal this instance.</returns>
		public virtual int CompareTo(Object obj)
		{
			if (obj is __Enrollment)
			{
				__Enrollment o = (__Enrollment) obj;
				
				if (
					o.IsNew == IsNew &&
					o.IsDeleted == IsDeleted &&
					o.EnrollmentID == EnrollmentID &&
					o.CourseID == CourseID &&
					o.StudentID == StudentID &&
					o.Grade == Grade 
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
				throw new ArgumentException("Argument is not of type __Enrollment");
			}
		}
 		
		#endregion CompareTo
		
		#region Operators
		
		/// <summary>
		/// Equality operator (==) returns true if the values of its operands are equal, false otherwise.
		/// </summary>
		/// <param name="a">The first <see cref="__Enrollment"/> object to compare.</param>
		/// <param name="b">The second <see cref="__Enrollment"/> object to compare.</param>
		/// <returns>true if values of operands are equal, false otherwise.</returns>
		public static bool operator == (__Enrollment a, __Enrollment b)
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
		/// <param name="a">The first <see cref="__Enrollment"/> object to compare.</param>
		/// <param name="b">The second <see cref="__Enrollment"/> object to compare.</param>
		/// <returns>false if values of operands are equal, false otherwise.</returns>
		public static bool operator !=(__Enrollment a, __Enrollment b)
		{
			return !(a == b);
		}
		
		/// <summary>
		/// Returns true the specified object is equal to this object instance, false otherwise.
		/// </summary>
		/// <param name="obj">The <see cref="__Enrollment"/> object to compare with the current <see cref="__Enrollment"/>.</param>
		/// <returns>true if specified object is equal to the instance of this object, false otherwise.</returns>
		public override bool Equals(Object obj)
		{
			if (!(obj is __Enrollment))
			{
				return false;
			}
			
			return this == (__Enrollment) obj;
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
		/// list.Sort(SortOrder.Ascending, __Enrollment.SortColumn.EnrollmentID);
		/// </summary>
		[Serializable]
		public sealed class SortColumn
		{	
			public const string EnrollmentID = "EnrollmentID";	
			public const string CourseID = "CourseID";	
			public const string StudentID = "StudentID";	
			public const string Grade = "Grade";
		}
				
		#endregion SortColumn
	}
}
// end of source generation

