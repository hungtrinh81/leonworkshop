using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Chess
{
	/// <summary>
	/// 開局庫資料類別
	/// </summary>
	public class book
	{
		/// <summary>
		/// 開局庫的所有棋譜集合(以move[][]型態存放)
		/// BOOK.DAT內一行為一個棋譜, 一個棋譜內含一組棋步(move[])
		/// </summary>
		private move[][] m_Lines;
		/// <summary>
		/// 表示開局庫所內含的行數, 也就是棋譜數量
		/// </summary>
		private long m_Length;
		/// <summary>
		/// 是否已載入開局庫的判別旗標
		/// </summary>
		private bool m_LoadFlag;
		/// <summary>
		/// 取得開局庫的所有棋譜集合
		/// </summary>
		public move[][] Lines
		{
			get{return m_Lines;}
		}
		/// <summary>
		/// 取得棋譜數量
		/// </summary>
		public long Length
		{
			get{return m_Lines.Length;}
		}
		/// <summary>
		/// 取得是否已載入開局庫的判別旗標
		/// </summary>
		public bool LoadFlag
		{
			get{return m_LoadFlag;}
		}
		/// <summary>
		/// 預設建構子
		/// </summary>
		public book()
		{
			m_Lines = null;
			m_Length = 0;
			m_LoadFlag = false;
		}
		/// <summary>
		/// 主要函式, 讀取BOOK.DAT資料並存入move[][]資料結構體內
		/// 在此處要特別注意的是棋譜的格式是使用VSCCP的座標格式
		/// 所以是使用VSCCP_BoardCodeEnum來解析座標點的值(Note:非常重要)
		/// </summary>
		public void Load()
		{
			string BookPath = string.Empty;
			StreamReader oReader = null;
			string CurrentLine = string.Empty;
			move[] CurrentLineMoves = null;
			string[] sp_Line = null;
			ArrayList al_Lines = new ArrayList();
			
			try
			{
				//載入BOOK.DAT
				BookPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName) + @"\sys\"+"BOOK.DAT";
				oReader = new StreamReader(new FileStream(BookPath,FileMode.Open), Encoding.Default);
				
				while((CurrentLine=oReader.ReadLine()) != null)
				{
					if(CurrentLine.StartsWith(";"))
					{
						//以分號開頭的為註解行, 不處理
					}
					else
					{
						//實際要存入的開佈局棋譜(Line)
						//ex:H2E2 B9C7 H0G2 H7F7 I0H0 H9G7 G3G4 C6C5 B0A2 G9E7 B2C2 A9B9 A0B0 B7B3
						//先以空白切割出來, 再Parse進move
						sp_Line = CurrentLine.Split(' ');
						CurrentLineMoves = new move[sp_Line.Length];
						for(int i=0;i<sp_Line.Length;i++){CurrentLineMoves[i] = new move(sp_Line[i], typeof(VSCCP_BoardCodeEnum));}
						al_Lines.Add(CurrentLineMoves);
					}
				}
				//Convert ArrayList alLines back to Lines(move[][] type)
				m_Lines = new move[al_Lines.Count][];
				for(int i=0;i<m_Lines.Length;i++)
				{
					m_Lines[i] = (move[])al_Lines[i];
				}

				m_Length = al_Lines.Count;
				m_LoadFlag = true;
			}
			catch(Exception e)
			{
				m_Lines = null;
				m_Length = 0;
				m_LoadFlag = false;
				throw e;
			}
			finally
			{
				oReader.Close();
				oReader = null;
			}
		}
	}
}
