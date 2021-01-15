# 潤沁網路大學
  
## Mirth Connect培養興趣之旅——由定時刷庫接口編程講起 
https://www.cnblogs.com/runqinshiye/p/14283559.html
* * *

### 让我们通过完成一个接口任务的示例，开始Mirth Connect的使用，并在此过程中培养起学习兴趣：  

##示例描述：  

同步两个数据库的表数据。首先我们通过定时刷库提取mirthtestdb数据库中patient表中字段 status的值为0的行;其次按照第三方webservice接口要求组织入参并发送到此webservice服务，
由此webservice服务内部完成对mirth_business_testdb数据库中b_patient表的插入逻辑；
最后根据webservice响应值更新mirthtestdb数据库中patient表字段 status的值为1，表明已经提取成功。

## 技术要点：  

定时刷库提取用Mirth的Database Reader信道实现；第三方webservice接口在vs2019中用C#编程实现。 

* * *  
中国大陆地区QQ交流群：623213258  
 
