using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningSampleApp.Controllers
{
    //Deprecated = true 表示这个api已经弃用
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/values")]
    [ApiController]
    public class ValuesV1Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Value1 from Version 1", "value2 from Version 1" };
        }
    }

    [ApiVersion("2.0")]
    //[Route("api/{v:apiVersion}/values")] //使用路由约束中指定请求Api的版本
    [Route("api/values")]
    [ApiController]
    public class ValuesV2Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 from Version 2", "value2 from Version 2" };
        }
    }

    //使用ApiVersionNeutral指定不需要版本控制的Api
    [ApiVersionNeutral]
    [Route("api/values2")]
    [ApiController]
    public class ValuesV3Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 from Version 3", "value2 from Version 3" };
        }
    }
}
