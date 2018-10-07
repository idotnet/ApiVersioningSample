# ApiVersioningSample
按照原博例子写了个 基于ASP.Net Core 2.1 的Api版本控制Demo。

原博：https://www.cnblogs.com/lwqlun/p/9747180.html

按照原博例子写了个ASP.Net Core 2.1 中的Api版本控制的Demo。

注意：
1、在查询字符串(Query String)中使用版本控制
例：https://localhost:44328/api/values?api-version=2.0

2、使用路由约束中指定请求Api的版本 [Route("api/{v:apiVersion}/values")]
例：https://localhost:44328/api/2.0/values

3、在请求头(HTTP Header)中使用版本控制（在查询字符串中指定版本号的方式将不再可用）
Startup.cs：
services.AddApiVersioning(o =>
    {
        o.ReportApiVersions = true;
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new ApiVersion(1, 0);
        o.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
    });

4.要1和3同时支持
Startup.cs：
services.AddApiVersioning(o =>
    {
         o.ReportApiVersions = true;
         o.AssumeDefaultVersionWhenUnspecified = true;
         o.DefaultApiVersion = new ApiVersion(1, 0);
         o.ApiVersionReader = ApiVersionReader.Combine(
              new QueryStringApiVersionReader(),
              new HeaderApiVersionReader()
              {
                   HeaderNames = { "x-api-version" }
              });
         });