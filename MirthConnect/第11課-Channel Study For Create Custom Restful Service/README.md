# 潤沁網路大學
  
## Mirth Connect信道学习示例七：Channel Study For Create Custom Restful Service

https://www.cnblogs.com/runqinshiye/p/14346793.html
 
* * *

### 第11課-Channel Study For Create Custom Restful Service：  

#### 示例描述：  

这节课我们一起学习利用Mirth Connect的HTTP Listener源通道与JavaScript Writer目的通道搭建自定义Restful风格webapi服务。

#### 技术要点：  

通过这个示例，我们学习了Mirth Connect的以下知识：  

1.获取输入请求的原始消息并自动格式化为XML格式： var xml = new XML(connectorMessage.getRawData())  

2.设置响应类型，如：channelMap.put('responseContentType', 'application/json')  

3.设置响应码，如：channelMap.put('responseStatusCode', '200')  

4.设置响应内容并通过JS脚本返回XML实体或者Json实体的字符串格式值  

5.异常处理通过JS脚本调用Mirth的API函数Packages.com.mirth.connect.server.userutil.ResponseFactory.getErrorResponse(string)返回字符串格式错误消息  

* * *  
中国大陆地区QQ交流群：623213258  
 
