# 潤沁網路大學
  
## Mirth Connect信道学习示例五：Channel Study For HTTP Listener & Web Service Sender Intercommunicates Response Handler

https://www.cnblogs.com/runqinshiye/p/14321955.html
 
* * *

### 第七課-Channel Study For HTTP Listener & Web Service Sender Intercommunicates Response Handler：  

#### 示例描述：  

系统A发送XML格式患者信息到Mirth的Source端Mirth HTTP Listener，完成患者信息入库逻辑；然后Mirth的Destinations的Web Service Sender调用C#开放的Webservice接口服务完成患者信息的查询并把响应结果返回给最初调用者系统A。

#### 技术要点：  

通过这个示例，我们学习了Mirth Connect的以下知识：  

1.Mirth调用外部C#的Webservice接口并获取返回值

2.响应消息通过responseMap变量返回

3.响应消息Raw格式返回C#Webservice的原始格式返回值


* * *  
中国大陆地区QQ交流群：623213258  
 
