# 潤沁網路大學
  
## Mirth Connect信道学习示例四：TCP Listener & HTTP Listener & Web Service Listener About Response Handler

https://www.cnblogs.com/runqinshiye/p/14321041.html 
 
* * *

### 第六課-Channel Study For TCP Listener & HTTP Listener & Web Service Listener About Response Handler：  

#### 示例描述：  

经过前面章节的课程，对Mirth Connect在系统集成与数据交互中的使用有了一个大概的了解；大家一定有个疑惑，Mirth Connect如何组织响应消息并返回给调用者？今天我们就来继续深入讲解Response响应处理机制。

#### 技术要点：  

通过这个示例，我们学习了Mirth Connect的以下知识：  

1.TCP\HTTP\Web Service三种Listener的响应消息处理

2.Response均以目的端作为响应

3.数据库JS查询与插入编程 

请在目的端响应转换中写如下JS脚本responseMap.put('responseAck', ack.toString() );然后在源端Response参数指定此作为响应。

* * *  
中国大陆地区QQ交流群：623213258  
 
