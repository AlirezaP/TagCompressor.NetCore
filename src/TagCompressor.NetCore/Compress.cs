using Microsoft.AspNet.Mvc.Filters;
using System.IO;
using System.Text;


namespace TagCompressor.NetCore
{
    public class Compress : ActionFilterAttribute
    {
        Stream stream;
        MemoryStream ms = new MemoryStream();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stream = context.HttpContext.Response.Body;

            ms = new MemoryStream();
            context.HttpContext.Response.Body = ms;

            base.OnActionExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {

            // ms.Position = 0;

            byte[] buf = ms.ToArray();

            string html = HtmlCompressor.Compress(Encoding.ASCII.GetString(buf));
            byte[] res = Encoding.ASCII.GetBytes(html);

            stream.Position = 0;
            stream.Write(res, 0, res.Length);

        }
    }
}
