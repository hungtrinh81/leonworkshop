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
using System.Text;

namespace TransDoc
{
	/// <summary>
	/// top 的摘要描述。
	/// </summary>
	public class top : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlGenericControl[] anylinkmenus;
		protected System.Web.UI.HtmlControls.HtmlAnchor[] anylinkmenuanchors;
		protected System.Web.UI.WebControls.TextBox txtSearch;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.ListBox lstSearch;
		protected System.Web.UI.WebControls.ListBox lstSearch2;
		protected System.Web.UI.WebControls.PlaceHolder ph;
		protected System.Web.UI.WebControls.Label lblSearchMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hdnTabIndex;

		private string alternativeColor(int index)
		{
			string rtnColor = "lightyellow";

			if(index%7==1)
			{rtnColor = "yellow";}
			else if(index%7==2)
			{rtnColor = "lightgreen";}
			else if(index%7==3)
			{rtnColor = "gold";}
			else if(index%7==4)
			{rtnColor = "pink";}
			else if(index%7==5)
			{rtnColor = "lightblue";}
			else if(index%7==6)
			{rtnColor = "lightgrey";}
			else
			{rtnColor = "#6699cc";}

			return rtnColor;
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			//Parameter Read In
			string BaseDir = @"C:\Projects\DGPRSB_RADAR\TransDocSolution\TransDoc";
			string RecursiveRule = "*";
			int ColumnSpan = 4;
			string[] RecursiveSubDirList = null;
			string Pattern = "*.htm";

			string sBASE_DIR=System.Configuration.ConfigurationSettings.AppSettings["BASE_DIR"] as string;
			string sRECURSIVE_RULE=System.Configuration.ConfigurationSettings.AppSettings["RECURSIVE_RULE"] as string;
			string sCOLUMN_SPAN=System.Configuration.ConfigurationSettings.AppSettings["COLUMN_SPAN"] as string;

			BaseDir = sBASE_DIR;
			RecursiveRule = sRECURSIVE_RULE;
			ColumnSpan = int.Parse(sCOLUMN_SPAN);

			//Determine Control's Count
			if(RecursiveRule=="*")
			{
				string[] tmpSubDirList = Directory.GetDirectories(BaseDir);
				RecursiveSubDirList = new string[tmpSubDirList.Length];
				for(int i=0;i<tmpSubDirList.Length;i++)
				{
					RecursiveSubDirList[i] = new DirectoryInfo(tmpSubDirList[i]).Name;
				}
			}
			else
			{
				RecursiveSubDirList = RecursiveRule.Split(',');
			}
			Trace.Warn("RecursiveSubDirList", string.Join(",",RecursiveSubDirList));

			//Initial AnyLink Controls
			anylinkmenus = new HtmlGenericControl[RecursiveSubDirList.Length];
			anylinkmenuanchors = new HtmlAnchor[RecursiveSubDirList.Length];

			for(int i=0;i<RecursiveSubDirList.Length;i++)
			{
				anylinkmenuanchors[i] = new HtmlAnchor();
				anylinkmenus[i] = new HtmlGenericControl("div");

				InitialAnyLinkControl(anylinkmenuanchors[i], "※" + RecursiveSubDirList[i] + "※", "anylinkmenu"+(i+1).ToString(), "90px", anylinkmenus[i], "360px", alternativeColor(i+1), ((i+1)%ColumnSpan==0) ? true : false);
				GenLinkByOP(BaseDir, RecursiveSubDirList[i], Pattern, anylinkmenus[i]);
			}

			Trace.Warn("MappingLink Count",Global.htMappingLink.Count.ToString());
		}

		private void InitialAnyLinkControl(HtmlAnchor ha, string anchor_innerHTML, string anchor_id, string anchor_width, HtmlGenericControl hgc, string hgc_width, string hgc_bgcolor, bool breakline)
		{
			ha.InnerHtml=anchor_innerHTML;
			ha.HRef="#";
			ha.Attributes.Add("onClick","return clickreturnvalue()");
			ha.Attributes.Add("onMouseOver","dropdownmenu(this, event, '"+anchor_id+"')");
			ha.Attributes.Add("style","WIDTH: "+anchor_width+";BACKGROUND-COLOR: "+hgc_bgcolor+"");
			
			hgc.ID=anchor_id;
			hgc.Attributes.Add("class","anylinkcss");
			hgc.Attributes.Add("style","WIDTH: "+hgc_width+"; BACKGROUND-COLOR: "+hgc_bgcolor+"");
			hgc.Attributes.Add("runat","server");

			ph.Controls.Add(ha);
			ph.Controls.Add(hgc);

			if(breakline)
			{
				ph.Controls.Add(new HtmlGenericControl("br"));
				ph.Controls.Add(new HtmlGenericControl("hr"));
			}
		}

		private void GenLinkByOP(string BaseDir, string OP, string Pattern, HtmlGenericControl hgc)
		{
			string[] FileList = Directory.GetFiles(Path.Combine(BaseDir, OP), Pattern);

			ArrayList al = new ArrayList();
			for(int i=0;i<FileList.Length;i++)
			{
				FileInfo fi = new FileInfo(FileList[i]);
				al.Add(new string[]{"./"+new DirectoryInfo(BaseDir).Name+"/"+OP+"/"+fi.Name, fi.Name});
			}

			for(int i=0;i<al.Count;i++)
			{
				string[] ss = al[i] as string[];
				HtmlAnchor a = new HtmlAnchor();
				Trace.Warn("ss[0]",ss[0]);
				Trace.Warn("ss[1]",ss[1]);
				
				if(!Global.htMappingLink.ContainsKey(ss[1]))
				{
					Global.htMappingLink.Add(ss[1], ss[0]);
				}
				else
				{
					Global.htMappingLink[ss[1]] = ss[0];
				}

				a.HRef = ss[0];
				a.InnerHtml = ss[1];
				a.Attributes.Add("Onclick","return ToLink('"+ss[0]+"')");
				hgc.Controls.Add(a);
			}

		}

		#region Web Form 設計工具產生的程式碼
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 此為 ASP.NET Web Form 設計工具所需的呼叫。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 此為設計工具支援所必須的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			hdnTabIndex.Value = "2";
			lstSearch.Items.Clear();
			lstSearch2.Items.Clear();

			string KeyWord = txtSearch.Text.Trim();
			foreach(string key in Global.htMappingLink.Keys)
			{
				if(Global.htMappingLink[key].ToString().ToLower().IndexOf(KeyWord.ToLower())!=-1)
				{
					lstSearch.Items.Add(key);
					lstSearch2.Items.Add(Global.htMappingLink[key].ToString());
				}
			}

			lblSearchMessage.Text = "搜尋結果： [" + lstSearch.Items.Count.ToString() + "] 筆";
		}
	}
}
