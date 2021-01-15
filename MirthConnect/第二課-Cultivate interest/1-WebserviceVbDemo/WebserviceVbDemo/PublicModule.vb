Imports log4net

Module PublicModule
    '创建日志记录组件实例
    Public FileLog As ILog = log4net.LogManager.GetLogger("FileLog.Logging")
    '验证字段值，进行处理
    Public Function CheckColumnValue(ByVal ColValue As Object) As String
        If IsDBNull(ColValue) = True OrElse IsNothing(ColValue) = True OrElse ColValue.Equals("") Then
            Return ""
        End If
        Return ColValue
    End Function
End Module
