
// Generated 4/7/2016 8:38:56 PM
// Do not modify the contents of this code file.
// This abstract class __Course is based upon dbo.Course.

#region How To Implement

// To implement, create another code file as outlined in the following example.
// It is recommended the code file you create be in the same project as this code file.
// Example:
// using System;
//
// namespace ContosoUniversity.DataObjects
// {
//		[Serializable]
// 		public class Course : __Course
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
	public abstract class __Course : CustomObjectBase, ICloneable, IComparable, IDisposable, ISetValues
	{
		#region Constructors
		
		/// <summary>
		/// Default constructor.
		/// </summary>
		public __Course()
		{
		}

		/// <summary>
		/// Overloaded constructor specifying each column value.
		/// </summary>
		/// <param name="courseID"></param>
		/// <param name="title"></param>
		/// <param name="credits"></param>
		/// <param name="departmentID"></param>
		public __Course(int courseID, 
			string title, 
			int credits, 
			int departmentID) : this()
		{
			CourseID = courseID;
			Title = title;
			Credits = credits;
			DepartmentID = departmentID;
		}
		
		#endregion Constructors
		
		#region Destructor
		
		/// <summary>
		///
		/// </summary>
		~__Course()
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
					case "CourseID" :
					{
						_CourseID = (int)column.Value;
						break;
					}
					case "Title" :
					{
						_Title = (string)column.Value;
						break;
					}
					case "Credits" :
					{
						_Credits = (int)column.Value;
						break;
					}
					case "DepartmentID" :
					{
						_DepartmentID = (int)column.Value;
						break;
					}
								}
			}
			
			IsNew = false;
		}
		
		#endregion Set Values
		
		#region Properties
		
		#region CourseID
		
		private int _CourseID = default(int);
		
		/// <summary>
		/// Column: CourseID;
		/// DBMS data type: int;
		/// </summary>
		[ColumnDefinition("CourseID", DbTargetType=SqlDbType.Int, Ordinal=1, NumericPrecision=10, IsInForeignKey=true, IsInPrimaryKey=true)]
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
		
		#region Title
		
		private string _Title = null;
		
		/// <summary>
		/// Column: Title;
		/// DBMS data type: nvarchar(50); Nullable;
		/// </summary>
		[ColumnDefinition("Title", DbTargetType=SqlDbType.NVarChar, Ordinal=2, CharacterMaxLength=50, IsNullable=true)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				if (value != null) value = CalibrateValue(value, 50);
				if (_Title != value)
				{
					_Title = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion Title
		
		#region Credits
		
		private int _Credits = default(int);
		
		/// <summary>
		/// Column: Credits;
		/// DBMS data type: int;
		/// </summary>
		[ColumnDefinition("Credits", DbTargetType=SqlDbType.Int, Ordinal=3, NumericPrecision=10)]
		public int Credits
		{
			get
			{
				return _Credits;
			}
			set
			{
				if (_Credits != value)
				{
					_Credits = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion Credits
		
		#region DepartmentID
		
		private int _DepartmentID = default(int);
		
		/// <summary>
		/// Column: DepartmentID;
		/// DBMS data type: int;
		/// </summary>
		[ColumnDefinition("DepartmentID", DbTargetType=SqlDbType.Int, Ordinal=4, NumericPrecision=10, IsInForeignKey=true)]
		public int DepartmentID
		{
			get
			{
				return _DepartmentID;
			}
			set
			{
				if (_DepartmentID != value)
				{
					_DepartmentID = value;
					_IsDirty = true;
				}
			}
		}
		
		#endregion DepartmentID
			
		#endregion Properties

		#region From Array serialization
		
		/// <summary>
		/// Deserializes the byte array and returns an instance of <see cref="__Course"/>.
		/// </summary>
		/// <returns>If the byte array can be deserialized and cast to an instance of <see cref="__Course"/>, 
		/// returns an instance of <see cref="__Course"/>; otherwise returns null.</returns>
		public static new __Course FromArray(byte[] byteArray)
		{
			__Course o = null;
			
			try
			{
				o = (__Course) CustomObjectBase.FromArray(byteArray);
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
		/// Compares this instance with a specified object. Throws an ArgumentException if the specified object is not of type <see cref="__Course"/>.
		/// </summary>
		/// <param name="obj">An <see cref="__Course"/> object to compare with this instance.</param>
		/// <returns>0 if the specified object equals this instance; -1 if the specified object does not equal this instance.</returns>
		public virtual int CompareTo(Object obj)
		{
			if (obj is __Course)
			{
				__Course o = (__Course) obj;
				
				if (
					o.IsNew == IsNew &&
					o.IsDeleted == IsDeleted &&
					o.CourseID == CourseID &&
					GetComparisonString(o.Title) == GetComparisonString(Title) &&
					o.Credits == Credits &&
					o.DepartmentID == DepartmentID 
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
				throw new ArgumentException("Argument is not of type __Course");
			}
		}
 		
		#endregion CompareTo
		
		#region Operators
		
		/// <summary>
		/// Equality operator (==) returns true if the values of its operands are equal, false otherwise.
		/// </summary>
		/// <param name="a">The first <see cref="__Course"/> object to compare.</param>
		/// <param name="b">The second <see cref="__Course"/> object to compare.</param>
		/// <returns>true if values of operands are equal, false otherwise.</returns>
		public static bool operator == (__Course a, __Course b)
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
		/// <param name="a">The first <see cref="__Course"/> object to compare.</param>
		/// <param name="b">The second <see cref="__Course"/> object to compare.</param>
		/// <returns>false if values of operands are equal, false otherwise.</returns>
		public static bool operator !=(__Course a, __Course b)
		{
			return !(a == b);
		}
		
		/// <summary>
		/// Returns true the specified object is equal to this object instance, false otherwise.
		/// </summary>
		/// <param name="obj">The <see cref="__Course"/> object to compare with the current <see cref="__Course"/>.</param>
		/// <returns>true if specified object is equal to the instance of this object, false otherwise.</returns>
		public override bool Equals(Object obj)
		{
			if (!(obj is __Course))
			{
				return false;
			}
			
			return this == (__Course) obj;
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
		/// list.Sort(SortOrder.Ascending, __Course.SortColumn.CourseID);
		/// </summary>
		[Serializable]
		public sealed class SortColumn
		{	
			public const string CourseID = "CourseID";	
			public const string Title = "Title";	
			public const string Credits = "Credits";	
			public const string DepartmentID = "DepartmentID";
		}
				
		#endregion SortColumn
	}
}
// end of source generation

