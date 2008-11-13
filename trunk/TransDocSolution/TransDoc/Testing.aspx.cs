using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace TransDoc
{
	public class Testing : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSingleFileFrom;
		protected System.Web.UI.HtmlControls.HtmlInputFile fSingleFileFrom;
		protected System.Web.UI.WebControls.Button btnSingleFileConvert;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

		}

		private void SingleFileConvert(string SourceFilePath, string DestinationFilePath)
		{
			if(File.Exists(SourceFilePath))
			{
				DocConverter.Convert(this, new DocPair(SourceFilePath, DestinationFilePath));
			}
		}

		#region Web Form �]�p�u�㲣�ͪ��{���X
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: ���� ASP.NET Web Form �]�p�u��һݪ��I�s�C
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����]�p�u��䴩�ҥ�������k - �ФŨϥε{���X�s�边�ק�
		/// �o�Ӥ�k�����e�C
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSingleFileConvert.Click += new System.EventHandler(this.btnSingleFileConvert_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSingleFileConvert_Click(object sender, System.EventArgs e)
		{
			string SourceFilePath = fSingleFileFrom.Value;
			string DestinationFilePath = fSingleFileFrom.Value.Replace("doc","htm");
			SingleFileConvert(SourceFilePath, DestinationFilePath);
		}
	}
}
