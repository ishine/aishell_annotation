# AIShellAnnotation

#关于AIShell

balabala。。。


## 项目简介

**AIShellAnnotation**是一个基于 ASP.NET Core 2 + Vue.js 的前后端分离的数据标注系统 。后端使用.NET Core 2 + Entity Framework Core 构建，前端则是目前流行的基于 Vue.js 的 iView框架。

**AIShellAnnotation**是一个完整的业务系统，包含了长语音,短语音标注,基本的图像标注(矩形、多边形）。该系统以任务为基础，由任务管理员或项目经理上传标注任务数据，然后分配给各个团队去完成，每个团队各自管理成员。标注完成后由团队管理员或项目经理创建质检任务，最后验收通过后产出标注结果集。 系统包含了源数据从“进”系统到标注结果数据集“出”系统的整个流程，同时方便管理标注人员，还包含统计各团队、用户的相关数据。

## 为什么开源

为什么,balabala...

## 文档(Document)

* [开发环境和工具](https://codedefault.com/p/environment-and-developement-tools)
* [下载项目&安装依赖](https://codedefault.com/p/download-and-restore-dnczeus)
* [前后端分离项目打包/发布/部署及注意事项](https://codedefault.com/p/dnczeus-build-and-deploy)

## 在线体验(Demo)

超级管理员：administrator 
管理员：admin

密码：111111

地址：

试试以不同用户名登录系统，可以体验不同角色的权限。


## 面向群体

AIShellAnnotation已经包含语音标注以及基础的图像标注功能，适合没有自己标注平台的标注团队自行部署使用，或者有其它标注类型需求的组织或团队，可以自行扩展代码，添加更丰富的标注功能。但扩展开发您需要了解：

- ASP.NET Core 2.2(C#)
- Vue.js (JavaScript)
- iView  (基于iView的组件框架)
- 数据库 (postgresql)

以上用到的开发技术都有非常丰富的文档，该系统没有什么技术难点，如果您是JAVA或者其它语言的开发者，亦可用它们重写后端部分。

如果您对这些方面的知识还不熟悉，建议你可以先学习一些理论再来扩展这个系统。关于 ASP.NET Core 和 Vue.js 的入门请参考：

- [ASP.NET Core 官方文档][2]
- [Vue.js 官方文档][3]
- [iView 官方文档][3]

## 环境和工具

1. Node.js(同时安装 npm 前端包管理工具)
2. Visual Studio 2017(15.8.8 或者以上版本)
3. VS Code 或者其他前端开发工具
4. git 管理工具
5. Postgresql 9.6+

## 技术实现

- ASP.NET Core 2(.NET Core 2.1.502)
- ASP.NET WebApi Core
- JWT 令牌认证
- AutoMapper
- Entity Framework Core 2.0
- .NET Core 依赖注入
- Swagger UI
- Vue.js(ES6 语法)
- iView(基于 Vue.js 的 UI 框架)


## 安装依赖

### 前端项目

在将该项目的源代码下载到本地之后，打开VSCode

进入到前端项目目录[AIShellAn.Webapp]。在命令行中输入如下命令进行前端依赖包的还原操作：

```
npm install (建议使用yarn替代npm,使用yarn需要额外安装)
```



### 后端项目

在Visual Studio 2017中打开解决方案[DncZeus.sln]。首先根据自己的开发环境(SQL Server数据库类型，本示例默认是SQL Server Localdb)修改配置文件`appsettings.json`中的数据库连接字符串，示例默认连接字符串为：

```
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DncZeus;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

再打开包管理控制台(Package Manager Console)，执行如下命令生成数据库表结构：

```
Update-Database -verbose
```

最后，打开项目根目录中的脚本文件夹[Scripts]，执行脚本文件[Init_data.sql]以初始化系统数据。

恭喜你，到这里所有的准备工作就完成了。

开始体验AIShellAnnotation吧！


## 运行

1. 使用Visual Studio开发工具打开DncZeus根目录中的VS解决方案文件[DncZeus.sln](或者你喜欢的话，使用VS Code来进行ASP.NET Core的开发也是可以的)，设置DncZeus.Api项目为默认启动项并运行此项目。

> 这时在浏览器中打开地址：http://localhost:54321/swagger ，便可以查看到DncZeus已经实现的后端API接口服务了。

2. 在命令行中进入到DncZeus的前端项目目录[DncZeus.App]，运行如下命令以启动前端项目服务：

```
npm run dev
```

成功运行后会自动在浏览器中打开地址: http://localhost:9000

## 使用和授权

AIShellAnnotation项目是一个开源项目，你可以直接基于本项目进行扩展或者二次开发，也可以修改其中的代码。

**项目中用到的其它开源项目的组件或者**。




## 问题与反馈

遇到问题怎么办？

* 直接提交issue
* 发送Email：316697683@qq.com


##	维护日志



### v1.0.0

* 重构前后端代码,更新前端各组件


[1]: https://github.com/iview/iview-admin
[2]: https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2
[3]: https://vuejs.org/
[4]: https://github.com/lampo1024/DncZeus
[5]: https://statics.codedefault.com/uploads/2018/12/1.png
[6]: https://statics.codedefault.com/uploads/2018/12/2.png
[7]: https://dnczeus.codedefault.com
[8]: https://codedefault.com
[9]: https://gitee.com/rector/DncZeus
