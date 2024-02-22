'Bobby Massey - Assignment P2, 02/22/24, Graphical User Interface Dev.: CPSC 3118
Public Class Form1
    'Constants
    Const cdecFica As Decimal = 0.0765
    Const cdecFed As Decimal = 0.22
    Const cdecState As Decimal = 0.04
    'Variables
    Dim strIncome As String
    Dim decIncome, decFica, decFederal, decState, decNet As Decimal
    Dim txtGrossPay As TextBox
    Public Property lblFica As Object
    Public Property lblFederal As Object
    Public Property lblState As Object
    Public Property lblNetIncome As Object
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set form title
        Me.Text = "Payroll every two weeks"

        'Load in the payroll image
        Dim picPayroll As New PictureBox()
        picPayroll.Size = New Size(200, 200)
        picPayroll.SizeMode = PictureBoxSizeMode.StretchImage
        picPayroll.Location = New Point(10, 10)
        Try
            picPayroll.Image = Image.FromFile("C:\Users\Bobby\payroll.jpg")
        Catch ex As Exception
            MessageBox.Show("Error loading payroll image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Controls.Add(picPayroll)

        'Label for "Payroll Calculator"
        Dim lbltitle As New Label
        lbltitle.Text = "Payroll Calculator"
        lbltitle.Font = New Font(lbltitle.Font, FontStyle.Bold)
        lbltitle.AutoSize = True
        lbltitle.Location = New Point(Me.Width - lbltitle.Width - 10, 10)
        Me.Controls.Add(lbltitle)

        'Label for "Paycheck Calculation
        Dim lblSubTitle As New Label
        lblSubTitle.Text = "Paycheck" & Environment.NewLine & "Calculation"
        lblSubTitle.Font = New Font(lblSubTitle.Font, FontStyle.Bold)
        lblSubTitle.TextAlign = ContentAlignment.MiddleRight
        lblSubTitle.AutoSize = True
        lblSubTitle.Location = New Point(Me.Width - lblSubTitle.Width - 10, 40)
        Me.Controls.Add(lblSubTitle)

        'Label and text box for gross pay input
        Dim lblGrossPay As New Label
        lblGrossPay.Text = "Enter gross pay: "
        lblGrossPay.Font = New Font(lblGrossPay.Font, FontStyle.Bold)
        lblGrossPay.AutoSize = True
        lblGrossPay.Location = New Point((Me.Width - lblGrossPay.Width) / 2, 150)
        Me.Controls.Add(lblGrossPay)

        txtGrossPay = New TextBox
        txtGrossPay.Size = New Size(100, 20)
        txtGrossPay.Location = New Point((Me.Width - txtGrossPay.Width) / 2, 180)
        txtGrossPay.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(txtGrossPay)

        'Buttons
        Dim btnComputeTaxes As New Button
        btnComputeTaxes.Text = "Compute Taxes"
        btnComputeTaxes.Size = New Size(100, 30)
        btnComputeTaxes.Location = New Point(50, 230)
        btnComputeTaxes.BackColor = Color.LightBlue
        AddHandler btnComputeTaxes.Click, AddressOf btnComputeTaxes_Click
        Me.Controls.Add(btnComputeTaxes)

        Dim btnClear As New Button
        btnClear.Text = "Clear"
        btnClear.Size = New Size(100, 30)
        btnClear.Location = New Point((Me.Width - btnClear.Width) / 2, 230)
        btnClear.BackColor = Color.LightBlue
        AddHandler btnClear.Click, AddressOf btnClear_Click
        Me.Controls.Add(btnClear)

        Dim btnExit As New Button
        btnExit.Text = "Exit"
        btnExit.Size = New Size(100, 30)
        btnExit.Location = New Point(Me.Width - btnExit.Width - 50, 230)
        btnExit.BackColor = Color.LightBlue
        AddHandler btnExit.Click, AddressOf btnExit_Click
        Me.Controls.Add(btnExit)

        'Labels for tax amounts
        lblFica = New Label
        lblFica.Text = "FICA: $0.00"
        lblFica.AutoSize = True
        lblFica.Location = New Point(50, 280)
        Me.Controls.Add(lblFica)

        lblFederal = New Label
        lblFederal.Text = "Federal Tax: $0.00"
        lblFederal.AutoSize = True
        lblFederal.Location = New Point(50, 310)
        Me.Controls.Add(lblFederal)

        lblState = New Label
        lblState.Text = "State Tax: $0.00"
        lblState.AutoSize = True
        lblState.Location = New Point(50, 340)
        Me.Controls.Add(lblState)

        ' Label for net income
        lblNetIncome = New Label
        lblNetIncome.Text = "Net Paycheck Income: $0.00"
        lblNetIncome.AutoSize = True
        lblNetIncome.Location = New Point(50, 370)
        Me.Controls.Add(lblNetIncome)
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        ' Exit the program
        Me.Close()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        ' Clear all fields
        lblFica.Text = "FICA: 0.00"
        lblFederal.Text = "Federal Tax: 0.00"
        lblState.Text = "State Tax: 0.00"
        lblNetIncome.Text = "Net Paycheck Income: 0.00"
    End Sub
    Private Sub btnComputeTaxes_Click(sender As Object, e As EventArgs)
        ' Convert income from TextBox to Decimal
        strIncome = txtGrossPay.Text
        Decimal.TryParse(strIncome, decIncome)

        ' Calculate tax amounts
        decFica = decIncome * cdecFica
        decFederal = decIncome * cdecFed
        decState = decIncome * cdecState
        decNet = decIncome - decFica - decFederal - decState

        ' Display tax amounts and net income
        lblFica.Text = "FICA: " & decFica.ToString("C")
        lblFederal.Text = "Federal Tax: " & decFederal.ToString("C")
        lblState.Text = "State Tax: " & decState.ToString("C")
        lblNetIncome.Text = "Net Paycheck Income: " & decNet.ToString("C")
    End Sub
End Class
