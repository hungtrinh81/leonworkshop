using System;
using System.Web;

namespace TransDoc 

{ 
	class DocPair
	{
		private string _SourceFile;
		private string _DestinationFile;

		public string SourceFile
		{
			get{return _SourceFile;}
			set{_SourceFile=value;}
		}

		public string DestinationFile
		{
			get{return _DestinationFile;}
			set{_DestinationFile=value;}
		}


		public DocPair(string sf, string df)
		{
			_SourceFile = sf;
			_DestinationFile = df;
		}
	}
	class DocConverter
	{

		public static void Convert(System.Web.UI.Page page, DocPair[] dps)
		{
			// Use for the parameter whose type are not known or  
			// say Missing
			object Unknown =Type.Missing;

			//Creating the instance of Word Application
			Word.Application newApp = new Word.Application(); 

			for(int i=0;i<dps.Length;i++)
			{
				// specifying the Source & Target file names
				object Source=dps[i].SourceFile;
				object Target=dps[i].DestinationFile;

				try
				{
					// Source document open here
					// Additional Parameters are not known so that are  
					// set as a missing type
					newApp.Documents.Open(ref Source,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown,
						ref Unknown,ref Unknown);

					// Specifying the format in which you want the output file 
					object format = Word.WdSaveFormat.wdFormatHTML;

					//Changing the format of the document
					newApp.ActiveDocument.SaveAs(ref Target,ref format, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown,ref Unknown, 
						ref Unknown,ref Unknown);
				}
				catch(Exception ex)
				{
					//log

					newApp.ActiveDocument.Close(ref Unknown,ref Unknown,ref Unknown);
					page.Trace.Warn("Ex=" + ex.Message);
				}
				finally
				{
					//log
				}
			}
			

			// for closing the application
			newApp.Quit(ref Unknown,ref Unknown,ref Unknown);
		}
		public static void Convert(System.Web.UI.Page page, DocPair dp)
		{ 
			DocPair[] dps= new DocPair[1];
			dps[0] = dp;
			Convert(page, dps);
		} 
	} 
}