using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationMapping
{
	public class StringBasedEnum
	{
		#region Enums

		public enum DocumentType
		{
			None = 0,
			[EnumToStringMapper("spreadsheet")]
			Spreadsheet = 1,
			[EnumToStringMapper("powerpoint presentation")]
			Presentation = 2,
			[EnumToStringMapper("article")]
			Article = 3
		}



		#endregion //Enums

		#region Attributes

		public class EnumToStringMapperAttribute : Attribute
		{
			public string AttributeValue { get; private set; }

			public EnumToStringMapperAttribute(string attributeValue)
			{
				this.AttributeValue = attributeValue;
			}

			public static string GetAttributeValue<E>(E enumValue) where E : Enum
			{
				//retrieve type of enum
				var type = typeof(E);
				//retrieve the property named "MappingValue" from the type
				MemberInfo enumMember = type.GetField(enumValue.ToString());
				if (enumMember == null) return null;
				//retrieve the MapperAttribute from the property
				EnumToStringMapperAttribute attribute = (EnumToStringMapperAttribute)Attribute.GetCustomAttribute(enumMember, typeof(EnumToStringMapperAttribute));
				if (attribute == null) return null;
				//return the value of "MappingValue" from the attribute
				return attribute.AttributeValue;
			}

			public static T GetEnum<T>(string value) where T : Enum
			{
				var type = typeof(T);
				foreach (var field in type.GetFields())
				{
					var attribute = (EnumToStringMapperAttribute)Attribute.GetCustomAttribute(field, typeof(EnumToStringMapperAttribute));
					if (attribute != null)
					{
						if (attribute.AttributeValue == value)
							return (T)field.GetValue(null);
					}
				}
				return default(T);
			}
		}

		#endregion //Attributes

		#region Classes

		public class Document
		{
			public int Id { get; set; }
			public DocumentType Type { get; set; }
			public string Name { get; set; }
		}

		#endregion //Classes

		#region Methods - Static

		public static DocumentType GetDocumentType(int value)
		{
			return (DocumentType)Enum.Parse(typeof(DocumentType), value.ToString());
		}


		#endregion //Methods - Static

	}
	public static class EnumMapperExtensions
	{
		public static string ToValue(this StringBasedEnum.DocumentType documentType)
		{
			return StringBasedEnum.EnumToStringMapperAttribute.GetAttributeValue<StringBasedEnum.DocumentType>(documentType);
		}

		public static StringBasedEnum.DocumentType  ToDocumentType(this string documentType)
		{
			return StringBasedEnum.EnumToStringMapperAttribute.GetEnum<StringBasedEnum.DocumentType>(documentType);
		}
	}
}