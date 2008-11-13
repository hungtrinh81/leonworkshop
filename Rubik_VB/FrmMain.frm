VERSION 5.00
Begin VB.Form FrmMain 
   BackColor       =   &H8000000A&
   Caption         =   "魔術方塊"
   ClientHeight    =   9195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11880
   LinkTopic       =   "Form1"
   ScaleHeight     =   9195
   ScaleWidth      =   11880
   StartUpPosition =   2  '螢幕中央
   Begin VB.CommandButton CmdOpenGL 
      Caption         =   "OpenGL 3D視圖"
      Height          =   495
      Left            =   9960
      TabIndex        =   40
      Top             =   6240
      Width           =   1455
   End
   Begin VB.CommandButton cmdView 
      Caption         =   "3D簡易視圖"
      Height          =   495
      Left            =   9960
      TabIndex        =   39
      Top             =   6960
      Width           =   1455
   End
   Begin VB.CommandButton cmdReset 
      Caption         =   "撥亂反正"
      Height          =   375
      Left            =   9720
      TabIndex        =   38
      Top             =   7920
      Width           =   1335
   End
   Begin VB.TextBox txtBatchRotate 
      Height          =   375
      Left            =   2880
      TabIndex        =   37
      Top             =   7920
      Width           =   5895
   End
   Begin VB.CommandButton cmdBatchRotate 
      Caption         =   "亂旋"
      Height          =   375
      Left            =   8880
      TabIndex        =   36
      Top             =   7920
      Width           =   735
   End
   Begin VB.CommandButton cmdRotateMiddle 
      Caption         =   "心旋"
      Height          =   375
      Left            =   1920
      TabIndex        =   35
      Top             =   8400
      Width           =   735
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   29
      Left            =   9240
      TabIndex        =   34
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   28
      Left            =   8640
      TabIndex        =   33
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   27
      Left            =   8040
      TabIndex        =   32
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   26
      Left            =   7440
      TabIndex        =   31
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   25
      Left            =   6840
      TabIndex        =   30
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   24
      Left            =   6240
      TabIndex        =   29
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   23
      Left            =   5640
      TabIndex        =   28
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   22
      Left            =   5040
      TabIndex        =   27
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   21
      Left            =   4440
      TabIndex        =   26
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   20
      Left            =   3840
      TabIndex        =   25
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   19
      Left            =   3240
      TabIndex        =   24
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "^"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   480
      Index           =   18
      Left            =   2640
      TabIndex        =   23
      Top             =   120
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   17
      Left            =   9240
      TabIndex        =   22
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   16
      Left            =   8640
      TabIndex        =   21
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   15
      Left            =   8040
      TabIndex        =   20
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   14
      Left            =   7440
      TabIndex        =   19
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   13
      Left            =   6840
      TabIndex        =   18
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   12
      Left            =   6240
      TabIndex        =   17
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   11
      Left            =   5640
      TabIndex        =   16
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   10
      Left            =   5040
      TabIndex        =   15
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   9
      Left            =   4440
      TabIndex        =   14
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   8
      Left            =   3840
      TabIndex        =   13
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   7
      Left            =   3240
      TabIndex        =   12
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "VVV"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1200
      Index           =   6
      Left            =   2640
      TabIndex        =   11
      Top             =   6240
      Width           =   300
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   ">>>>>"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Index           =   5
      Left            =   9960
      TabIndex        =   10
      Top             =   3840
      Width           =   1200
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   ">>>>>"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Index           =   4
      Left            =   9960
      TabIndex        =   9
      Top             =   3240
      Width           =   1200
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   ">>>>>"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Index           =   3
      Left            =   9960
      TabIndex        =   8
      Top             =   2640
      Width           =   1200
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "<<<<<"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Index           =   2
      Left            =   1080
      TabIndex        =   7
      Top             =   3840
      Width           =   1200
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "<<<<<"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Index           =   1
      Left            =   1080
      TabIndex        =   6
      Top             =   3240
      Width           =   1200
   End
   Begin VB.CommandButton cmdMove 
      Caption         =   "<<<<<"
      BeginProperty Font 
         Name            =   "新細明體"
         Size            =   12
         Charset         =   136
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   300
      Index           =   0
      Left            =   1080
      TabIndex        =   5
      Top             =   2640
      Width           =   1200
   End
   Begin VB.ComboBox cboDirection 
      Height          =   300
      ItemData        =   "FrmMain.frx":0000
      Left            =   1080
      List            =   "FrmMain.frx":000A
      TabIndex        =   4
      Top             =   7980
      Width           =   1575
   End
   Begin VB.ComboBox cboFlat 
      Height          =   300
      ItemData        =   "FrmMain.frx":0015
      Left            =   1080
      List            =   "FrmMain.frx":002B
      TabIndex        =   1
      Top             =   7620
      Width           =   1575
   End
   Begin VB.CommandButton cmdRotate 
      Caption         =   "邊旋"
      Height          =   375
      Left            =   1080
      TabIndex        =   0
      Top             =   8400
      Width           =   735
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "旋轉方向："
      Height          =   180
      Left            =   180
      TabIndex        =   3
      Top             =   8040
      Width           =   900
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "旋轉面："
      Height          =   180
      Left            =   360
      TabIndex        =   2
      Top             =   7680
      Width           =   720
   End
End
Attribute VB_Name = "FrmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'陣列批次旋轉動作
Private Sub cmdBatchRotate_Click()
    Dim z As Integer
    TmpNum = txtBatchRotate.Text
    CBN = Split(TmpNum, ",")
    For z = 0 To UBound(CBN)
        Action CInt(CBN(z))
    Next
End Sub

'個別按鈕動作
Private Sub cmdMove_Click(Index As Integer)
    CBNum = Split(Totalnum, ",")
    Action CInt(CBNum(Index))
End Sub

'撥亂反正動作
Private Sub cmdReset_Click()
    ResetBlock
End Sub

'邊旋動作
Private Sub cmdRotate_Click()
    Rotate cboFlat.Text, cboDirection.Text
End Sub
'心旋動作
Private Sub cmdRotateMiddle_Click()
    RotateMiddle cboFlat.Text, cboDirection.Text
End Sub

'VB計算3D圖形顯示
Private Sub cmdView_Click()
    Frm3DView.Show 1
End Sub

'OpenGL 3D模型顯示
Private Sub CmdOpenGL_Click()
    FrmOpenGL.Show 1
End Sub

'表單載入
Private Sub Form_Load()
    Me.Height = 9600
    Me.Width = 12000
    cboFlat.ListIndex = 0
    cboDirection.ListIndex = 0
    Total = 1
    
    '方塊載入
    InitialBlock
End Sub

'9,4,3,10,6,10,12   <==一號攻擊法

