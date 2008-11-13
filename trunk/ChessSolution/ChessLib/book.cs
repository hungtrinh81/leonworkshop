using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Chess
{
	/// <summary>
	/// �}���w������O
	/// </summary>
	public class book
	{
		/// <summary>
		/// �}���w���Ҧ����ж��X(�Hmove[][]���A�s��)
		/// BOOK.DAT���@�欰�@�Ӵ���, �@�Ӵ��Ф��t�@�մѨB(move[])
		/// </summary>
		private move[][] m_Lines;
		/// <summary>
		/// ��ܶ}���w�Ҥ��t�����, �]�N�O���мƶq
		/// </summary>
		private long m_Length;
		/// <summary>
		/// �O�_�w���J�}���w���P�O�X��
		/// </summary>
		private bool m_LoadFlag;
		/// <summary>
		/// ���o�}���w���Ҧ����ж��X
		/// </summary>
		public move[][] Lines
		{
			get{return m_Lines;}
		}
		/// <summary>
		/// ���o���мƶq
		/// </summary>
		public long Length
		{
			get{return m_Lines.Length;}
		}
		/// <summary>
		/// ���o�O�_�w���J�}���w���P�O�X��
		/// </summary>
		public bool LoadFlag
		{
			get{return m_LoadFlag;}
		}
		/// <summary>
		/// �w�]�غc�l
		/// </summary>
		public book()
		{
			m_Lines = null;
			m_Length = 0;
			m_LoadFlag = false;
		}
		/// <summary>
		/// �D�n�禡, Ū��BOOK.DAT��ƨæs�Jmove[][]��Ƶ��c�餺
		/// �b���B�n�S�O�`�N���O���Ъ��榡�O�ϥ�VSCCP���y�Ю榡
		/// �ҥH�O�ϥ�VSCCP_BoardCodeEnum�ӸѪR�y���I����(Note:�D�`���n)
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
				//���JBOOK.DAT
				BookPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName) + @"\sys\"+"BOOK.DAT";
				oReader = new StreamReader(new FileStream(BookPath,FileMode.Open), Encoding.Default);
				
				while((CurrentLine=oReader.ReadLine()) != null)
				{
					if(CurrentLine.StartsWith(";"))
					{
						//�H�����}�Y�������Ѧ�, ���B�z
					}
					else
					{
						//��ڭn�s�J���}�G������(Line)
						//ex:H2E2 B9C7 H0G2 H7F7 I0H0 H9G7 G3G4 C6C5 B0A2 G9E7 B2C2 A9B9 A0B0 B7B3
						//���H�ťդ��ΥX��, �AParse�imove
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
