Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Data

Public Class DBProcess
    '数据库对象
    Private Shared dbIns As Database = EnterpriseLibraryContainer.Current.GetInstance(Of Database)("MirthTestBusiness")
    '测试连接
    Public Function TestConn() As Boolean
        Dim flag As Boolean = False
        Dim dbconn As System.Data.Common.DbConnection = dbIns.CreateConnection()
        Try
            dbconn.Open()
            FileLog.Info("打开DB连接成功")
            flag = True
        Catch ex As Exception
            FileLog.Error("打开DB连接错误：错误为：" & ex.ToString())
        Finally
            dbconn.Close()
        End Try
        Return flag
    End Function
    '插入数据
    Public Function InsertOneData(ByVal pEntity As PatientEntity) As Integer
        Dim iCount As Integer = -1
        Try
            '首先查询是否已经存在
            Dim sqlStr As String = "select count(1) from b_patient where pid=@pid"
            Dim cmdIns As DbCommand = dbIns.GetSqlStringCommand(sqlStr)
            dbIns.AddInParameter(cmdIns, "@pid", DbType.String, pEntity.pid)
            iCount = Convert.ToInt32(dbIns.ExecuteScalar(cmdIns))
            cmdIns.Parameters.Clear()
            If iCount = 0 Then
                sqlStr = "INSERT INTO  b_patient(pid,name,sex,dob,addr)values(@pid,@name,@sex,@dob,@addr)"
                cmdIns = dbIns.GetSqlStringCommand(sqlStr)
                dbIns.AddInParameter(cmdIns, "@pid", DbType.String, pEntity.pid)
                dbIns.AddInParameter(cmdIns, "@name", DbType.String, pEntity.name)
                dbIns.AddInParameter(cmdIns, "@sex", DbType.String, pEntity.sex)
                dbIns.AddInParameter(cmdIns, "@dob", DbType.String, pEntity.dob)
                dbIns.AddInParameter(cmdIns, "@addr", DbType.String, pEntity.addr)
                iCount = dbIns.ExecuteNonQuery(cmdIns)
                cmdIns.Parameters.Clear()
                If iCount = 1 Then
                    FileLog.Info($"pid:{pEntity.pid}入库成功！")
                Else
                    FileLog.Error($"pid:{pEntity.pid}入库失败！")
                End If
            Else
                FileLog.Info($"pid:{pEntity.pid}已经存在！")
            End If
        Catch ex As Exception
            FileLog.Error($"pid:{pEntity.pid}入库失败:{ex.ToString()}")
            iCount = -1
        End Try
        Return iCount
    End Function

End Class


