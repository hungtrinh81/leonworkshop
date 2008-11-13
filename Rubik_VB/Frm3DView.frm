VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Begin VB.Form Frm3DView 
   AutoRedraw      =   -1  'True
   Caption         =   "立體方塊圖 [使用VB計算引擎]"
   ClientHeight    =   6000
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5535
   LinkTopic       =   "Form1"
   ScaleHeight     =   6000
   ScaleWidth      =   5535
   StartUpPosition =   2  '螢幕中央
   Begin VB.PictureBox PicBlock 
      Height          =   3855
      Left            =   0
      ScaleHeight     =   3795
      ScaleWidth      =   5475
      TabIndex        =   11
      Top             =   0
      Width           =   5535
   End
   Begin VB.Frame fraSlider 
      Height          =   2055
      Left            =   0
      TabIndex        =   0
      Top             =   3840
      Width           =   5535
      Begin VB.TextBox txtZv 
         Height          =   270
         Left            =   1560
         MaxLength       =   8
         TabIndex        =   9
         Text            =   "8100"
         Top             =   1672
         Width           =   1215
      End
      Begin VB.OptionButton optAxisOff 
         Caption         =   "不鎖定軸向"
         Height          =   255
         Left            =   3960
         TabIndex        =   8
         Top             =   1680
         Width           =   1215
      End
      Begin VB.OptionButton optAxisOn 
         Caption         =   "鎖定軸向"
         Height          =   255
         Left            =   2880
         TabIndex        =   7
         Top             =   1680
         Value           =   -1  'True
         Width           =   1095
      End
      Begin MSComctlLib.Slider SliderX 
         Height          =   435
         Left            =   480
         TabIndex        =   1
         Top             =   240
         Width           =   4935
         _ExtentX        =   8705
         _ExtentY        =   767
         _Version        =   393216
         Max             =   360
         TickFrequency   =   10
      End
      Begin MSComctlLib.Slider SliderY 
         Height          =   435
         Left            =   480
         TabIndex        =   3
         Top             =   675
         Width           =   4935
         _ExtentX        =   8705
         _ExtentY        =   767
         _Version        =   393216
         Max             =   360
         TickFrequency   =   10
      End
      Begin MSComctlLib.Slider SliderZ 
         Height          =   435
         Left            =   480
         TabIndex        =   5
         Top             =   1110
         Width           =   4935
         _ExtentX        =   8705
         _ExtentY        =   767
         _Version        =   393216
         Max             =   360
         TickFrequency   =   10
      End
      Begin VB.Label lblZv 
         AutoSize        =   -1  'True
         Caption         =   "視點距離："
         Height          =   180
         Left            =   600
         TabIndex        =   10
         Top             =   1710
         Width           =   900
      End
      Begin VB.Label lblZ 
         AutoSize        =   -1  'True
         Caption         =   "Z："
         BeginProperty Font 
            Name            =   "新細明體"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   6
         Top             =   1207
         Width           =   405
      End
      Begin VB.Label lblY 
         AutoSize        =   -1  'True
         Caption         =   "Y："
         BeginProperty Font 
            Name            =   "新細明體"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   4
         Top             =   772
         Width           =   435
      End
      Begin VB.Label lblX 
         AutoSize        =   -1  'True
         Caption         =   "X："
         BeginProperty Font 
            Name            =   "新細明體"
            Size            =   12
            Charset         =   136
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   2
         Top             =   337
         Width           =   435
      End
   End
End
Attribute VB_Name = "Frm3DView"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim R As Single
Dim sx, sy As Single
Dim Jin As Single
Dim Zv As Single
Dim Unit As Single
Dim dPos As Single

Private Sub Form_Load()
    Me.Width = 5650
    Me.Height = 6400
    sx = 2000
    sy = 2000
    Jin = 0.017453299251
    Zv = 8100
    Unit = 900
    dPos = 0
End Sub

Private Sub DrawBlockByAxis(Axis As String)
    PicBlock.Cls
    Zv = CSng(txtZv.Text)
    Dim a(1 To 8) As Single
    Dim b(1 To 8) As Single
    Dim c(1 To 8) As Single
    
    Dim pa(1 To 8)
    Dim pb(1 To 8)
    Dim pc(1 To 8)
    
    Dim S_X(1 To 8)
    Dim S_Y(1 To 8)
    
    a(1) = 1 * Unit + dPos
    b(1) = 1 * Unit + dPos
    c(1) = 1 * Unit + dPos
    
    a(2) = 1 * Unit + dPos
    b(2) = 1 * Unit + dPos
    c(2) = -1 * Unit + dPos
    
    a(3) = 1 * Unit + dPos
    b(3) = -1 * Unit + dPos
    c(3) = -1 * Unit + dPos
    
    a(4) = 1 * Unit + dPos
    b(4) = -1 * Unit + dPos
    c(4) = 1 * Unit + dPos
    
    a(5) = -1 * Unit + dPos
    b(5) = 1 * Unit + dPos
    c(5) = 1 * Unit + dPos
    
    a(6) = -1 * Unit + dPos
    b(6) = 1 * Unit + dPos
    c(6) = -1 * Unit + dPos
    
    a(7) = -1 * Unit + dPos
    b(7) = -1 * Unit + dPos
    c(7) = -1 * Unit + dPos
    
    a(8) = -1 * Unit + dPos
    b(8) = -1 * Unit + dPos
    c(8) = 1 * Unit + dPos
    
    Dim i As Integer
    For i = 1 To 8
    
        Select Case (Axis)

            Case "X":
                CoordinateTransferByAxis a(i), b(i), c(i), pa(i), pb(i), pc(i), "X", SliderX.Value * Jin
            Case "Y":
                CoordinateTransferByAxis a(i), b(i), c(i), pa(i), pb(i), pc(i), "Y", SliderY.Value * Jin
            Case "Z":
                CoordinateTransferByAxis a(i), b(i), c(i), pa(i), pb(i), pc(i), "Z", SliderZ.Value * Jin
                
        End Select
        
        Get2DCoord pa(i), pb(i), pc(i), Zv, S_X(i), S_Y(i)
    Next
    
    For i = 1 To 4
        If i < 4 Then
            PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(i + 1)), sy + CSng(S_Y(i + 1)))
        Else
            PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(1)), sy + CSng(S_Y(1)))
        End If
        
        PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(i + 4)), sy + CSng(S_Y(i + 4)))
    Next
    
    For i = 5 To 8
        If i < 8 Then
            PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(i + 1)), sy + CSng(S_Y(i + 1)))
        Else
            PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(5)), sy + CSng(S_Y(5)))
        End If
    Next
End Sub

Private Sub DrawBlock()
    PicBlock.Cls
    Zv = CSng(txtZv.Text)
    Dim a(1 To 8) As Single
    Dim b(1 To 8) As Single
    Dim c(1 To 8) As Single
    
    Dim pa(1 To 8)
    Dim pb(1 To 8)
    Dim pc(1 To 8)
    
    Dim S_X(1 To 8)
    Dim S_Y(1 To 8)
    
    a(1) = 1 * Unit + dPos
    b(1) = 1 * Unit + dPos
    c(1) = 1 * Unit + dPos
    
    a(2) = 1 * Unit + dPos
    b(2) = 1 * Unit + dPos
    c(2) = -1 * Unit + dPos
    
    a(3) = 1 * Unit + dPos
    b(3) = -1 * Unit + dPos
    c(3) = -1 * Unit + dPos
    
    a(4) = 1 * Unit + dPos
    b(4) = -1 * Unit + dPos
    c(4) = 1 * Unit + dPos
    
    a(5) = -1 * Unit + dPos
    b(5) = 1 * Unit + dPos
    c(5) = 1 * Unit + dPos
    
    a(6) = -1 * Unit + dPos
    b(6) = 1 * Unit + dPos
    c(6) = -1 * Unit + dPos
    
    a(7) = -1 * Unit + dPos
    b(7) = -1 * Unit + dPos
    c(7) = -1 * Unit + dPos
    
    a(8) = -1 * Unit + dPos
    b(8) = -1 * Unit + dPos
    c(8) = 1 * Unit + dPos
    
    Dim i As Integer
    For i = 1 To 8
        CoordinateTransfer a(i), b(i), c(i), pa(i), pb(i), pc(i), SliderX.Value * Jin, SliderY.Value * Jin, SliderZ.Value * Jin
        Get2DCoord pa(i), pb(i), pc(i), Zv, S_X(i), S_Y(i)
    Next
    
    For i = 1 To 4
        If i < 4 Then
            PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(i + 1)), sy + CSng(S_Y(i + 1)))
        Else
            PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(1)), sy + CSng(S_Y(1)))
        End If
        
        PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(i + 4)), sy + CSng(S_Y(i + 4)))
    Next
    
    For i = 5 To 8
        If i < 8 Then
            PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(i + 1)), sy + CSng(S_Y(i + 1)))
        Else
            PicBlock.Line (sx + CSng(S_X(i)), sy + CSng(S_Y(i)))-(sx + CSng(S_X(5)), sy + CSng(S_Y(5)))
        End If
    Next
    
    
    
End Sub

'針對某一軸旋轉某個角度的空間座標轉換
Private Sub CoordinateTransferByAxis(ByVal X As Single, ByVal Y As Single, ByVal z As Single, px, py, pz, ByVal Axis As String, ByVal Angle As Single)

    Select Case (Axis)
        
        Case "X":
        
            px = X
            py = (Cos(Angle) * Y) - (Sin(Angle) * z)
            pz = (Sin(Angle) * Y) + (Cos(Angle) * z)
        
        Case "Y":
        
            px = (Cos(Angle) * X) + (Sin(Angle) * z)
            py = Y
            pz = (Sin(Angle) * X * -1) + (Cos(Angle) * z)
        
        Case "Z":
        
            px = (Cos(Angle) * X) - (Sin(Angle) * Y)
            py = (Sin(Angle) * X) + (Cos(Angle) * Y)
            pz = z
        
    End Select

End Sub

'空間座標轉換(組合式計算)
Private Sub CoordinateTransfer(ByVal X As Single, ByVal Y As Single, ByVal z As Single, px, py, pz, ByVal AngleX As Single, ByVal AngleY As Single, ByVal AngleZ As Single)

    Dim C_X, C_Y, C_Z, S_X, S_Y, S_Z As Single
    C_X = Cos(AngleX)
    C_Y = Cos(AngleY)
    C_Z = Cos(AngleZ)
    S_X = Sin(AngleX)
    S_Y = Sin(AngleY)
    S_Z = Sin(AngleZ)

    px = (C_Y * C_Z) * X + _
         (S_X * S_Y * C_Z - C_X * S_Z) * Y + _
         (C_X * S_Y * C_Z + S_X * S_Z) * z
         
    py = (C_Y * S_Z) * X + _
         (S_X * S_Y * S_Z + C_X * C_Z) * Y + _
         (C_X * S_Y * S_Z - S_X * C_Z) * z

    pz = (S_Z) * (-1) * X + _
         (S_X * C_Y) * Y + _
         (C_X * C_Y) * z
         
End Sub

'用投影法求出3D對應之2D座標
Private Sub Get2DCoord(ByVal X As Single, ByVal Y As Single, ByVal z As Single, ByVal ViewPoint_Height As Single, TargetX, TargetY)
    TargetX = X * (1 - z / ViewPoint_Height)
    TargetY = Y * (1 - z / ViewPoint_Height)
End Sub

Private Sub optAxisOff_Click()
    txtZv.Text = 9600000000#
End Sub

Private Sub optAxisOn_Click()
    txtZv.Text = 8100
End Sub

Private Sub SliderX_Click()
    If (optAxisOn.Value = True) Then
        DrawBlockByAxis "X"
    Else
        DrawBlock
    End If
End Sub

Private Sub SliderX_Scroll()
    SliderX_Click
End Sub

Private Sub SliderY_Click()
    If (optAxisOn.Value = True) Then
        DrawBlockByAxis "Y"
    Else
        DrawBlock
    End If
End Sub

Private Sub SliderY_Scroll()
    SliderY_Click
End Sub

Private Sub SliderZ_Click()
    If (optAxisOn.Value = True) Then
        DrawBlockByAxis "Z"
    Else
        DrawBlock
    End If
End Sub

Private Sub SliderZ_Scroll()
    SliderZ_Click
End Sub
