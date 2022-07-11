namespace LC6464.ASPNET.AddResponseHeaders;
/// <summary>
/// 为 <see cref="IApplicationBuilderExtensions"/> 添加扩展方法。
/// </summary>
public static class IApplicationBuilderExtensions {
	/// <summary>
	/// 为 <paramref name="builder"/> 添加 <see cref="AddResponseHeadersMiddleware"/> 的扩展方法。
	/// </summary>
	/// <param name="builder">要添加扩展方法的 <see cref="IApplicationBuilder"/></param>
	/// <param name="headers">要添加进入响应的头列表</param>
	/// <returns>当前的 <see cref="IApplicationBuilder"/>，用于链式调用。</returns>
	public static IApplicationBuilder UseAddResponseHeaders(this IApplicationBuilder builder, IHeaderDictionary headers) =>
		builder.UseMiddleware<AddResponseHeadersMiddleware>(headers);
}