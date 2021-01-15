Imports System.ComponentModel
Imports System.IO
Imports System.Web.Services

' 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。
'<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WebServiceVbDemo
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function
    <WebMethod()>
    Public Function ShowInfo(ByVal str As String) As String
        Return str
    End Function
    <WebMethod()>
    Public Function TestDBTestConn() As Boolean
        Dim ins As New DBProcess()
        Return ins.TestConn()
    End Function
    <WebMethod()>
    Public Function ReceiveMessage(ByVal XmlMsg As String) As Integer
        FileLog.Info($"ReceiveMessage:\n{XmlMsg}")
        Dim pid As Integer = -1
        If XmlMsg.Length > 0 Then
            Using StrStream As StringReader = New StringReader(XmlMsg)
                Dim xml = XDocument.Load(StrStream)
                Dim pEntity As New PatientEntity
                pEntity.pid = xml.<result>.<pid>.Value
                pEntity.name = xml.<result>.<name>.Value
                pEntity.sex = xml.<result>.<sex>.Value
                pEntity.dob = xml.<result>.<dob>.Value
                pEntity.addr = xml.<result>.<addr>.Value
                pEntity.ssn = xml.<result>.<ssn>.Value
                pEntity.status = xml.<result>.<status>.Value
                Dim ins As New DBProcess()
                Dim iFlag As Integer = ins.InsertOneData(pEntity)
                If iFlag = 1 Then
                    FileLog.Info("ReceiveMessage处理接收到的xml数据成功.")
                    pid = pEntity.pid
                ElseIf iFlag = 0 Then
                    FileLog.Error("ReceiveMessage處理接收到的xml數據失敗了！")
                ElseIf iFlag = -1 Then
                    FileLog.Error("ReceiveMessage出现Exception！")
                End If
            End Using
        End If
        Return pid
    End Function
End Class