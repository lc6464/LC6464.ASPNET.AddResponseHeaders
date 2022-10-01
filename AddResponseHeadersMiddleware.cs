namespace LC6464.ASPNET.AddResponseHeaders;
/// <summary>
/// 向响应中添加头的中间件。
/// </summary>
public class AddResponseHeadersMiddleware {
	private readonly RequestDelegate _next;
	private readonly IHeaderDictionary _headers;

	/// <summary>
	/// 中间件的构造函数。
	/// </summary>
	/// <param name="next">下一个中间件</param>
	/// <param name="headers">要添加进入响应的头列表</param>
	public AddResponseHeadersMiddleware(RequestDelegate next, IHeaderDictionary headers) {
		_next = next;
		_headers = headers;
	}

	/// <summary>
	/// 中间件执行主体。
	/// </summary>
	/// <param name="httpContext">当前的 <see cref="HttpContent"/></param>
	public async Task InvokeAsync(HttpContext httpContext) {
		var responseHeaders = httpContext.Response.Headers;
		foreach (var header in _headers) {
			if (!responseHeaders.ContainsKey(header.Key)) { // 若响应头中不存在该头，则添加
				responseHeaders.Add(header);
			} else if (responseHeaders[header.Key] != header.Value) { // 若响应头中已存在该头且值不一致，则合并
				responseHeaders[header.Key] = StringValues.Concat(responseHeaders[header.Key], header.Value);
			}
		}

		await _next(httpContext);
	}
}