Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' 有关程序集的常规信息通过下列特性集
' 控制。更改这些特性值可修改
' 与程序集关联的信息。

' 检查程序集特性的值
<Assembly: AssemblyTitle("WebserviceVbDemo")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("HP Inc.")>
<Assembly: AssemblyProduct("WebserviceVbDemo")>
<Assembly: AssemblyCopyright("Copyright © HP Inc. 2021")>
<Assembly: AssemblyTrademark("")>

<Assembly: ComVisible(False)>

'如果此项目向 COM 公开，则下列 GUID 用于 typelib 的 ID
<Assembly: Guid("9f754ffb-4575-4ef2-8eea-4dca811c90ad")>

' 程序集的版本信息由下列四个值组成:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' 可以指定所有值，也可以使用“内部版本号”和“修订号”的默认值，
' 方法是按如下所示使用 "*":
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.0.0.0")>
<Assembly: AssemblyFileVersion("1.0.0.0")>
'指定log4net的配置文件的名字为：“Log4net.config”
<Assembly: log4net.Config.XmlConfiguratorAttribute(ConfigFile:="Log4net.config", Watch:=True)>

