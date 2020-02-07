using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumerationMapping.StringBasedEnum.EnumToStringMapperAttribute;
using static EnumerationMapping.StringBasedEnum;

namespace EnumerationMapping
{
	class Program
	{
		static void Main(string[] args)
		{
			string value = GetAttributeValue<DocumentType>(DocumentType.Presentation);
			var enumValue = GetEnum<DocumentType>(value);
			string value2 = DocumentType.Presentation.ToValue();
			var enumValue2 = value2.ToDocumentType();
		}
	}
}
