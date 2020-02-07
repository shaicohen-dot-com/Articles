using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationMapping.Standard
{
	#region Enums

	public enum DocumentType
	{
		None = 0,
		Spreadsheet = 1,
		Presentation = 2,
		Article = 3
	}

	#endregion //Enums

	public class StandardEnum
	{
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
}
