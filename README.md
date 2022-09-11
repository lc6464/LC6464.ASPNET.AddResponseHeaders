# LC6464.ASPNET.AddResponseHeaders

[NuGet 包](https://www.nuget.org/packages/LC6464.ASPNET.AddResponseHeaders "NuGet.Org")
[GitHub 项目](https://github.com/lc6464/LC6464.ASPNET.AddResponseHeaders "GitHub.Com")

在 ASP.NET 中快速为所有响应添加头。

## 使用方法
`ExampleWebAPI.csproj`:
``` xml
<Project Sdk="Microsoft.NET.Sdk.Web">
	<PropertyGroup>
		<TargetFramework>net6.0</TargetFramework>
		<Nullable>enable</Nullable>
		<ImplicitUsings>enable</ImplicitUsings>
		<!-- 一些东西 -->
	</PropertyGroup>
	<ItemGroup>
		<PackageReference Include="LC6464.ASPNET.AddResponseHeaders" Version="1.1.1" />
		<!-- PackageReference，请使用 Visual Studio 或 dotnet cli 等工具添加 -->
	</ItemGroup>
	<ItemGroup>
		<Using Include="LC6464.ASPNET.AddResponseHeaders" />
		<!-- 一些别的东西 -->
	</ItemGroup>
</Project>
```

`Program.cs`:
``` csharp
var builder = WebApplication.CreateBuilder(args); // 创建 builder


// -------- 添加一些服务 --------


var app = builder.Build();


// -------- 添加一些服务、中间件 --------


app.UseAddResponseHeaders(new HeaderDictionary { // 为每个响应添加头
	{ "Expect-CT", "max-age=31536000; enforce" },
	{ "X-Content-Type-Options", "nosniff" }
});


// -------- 添加一些中间件、运行 WebApplication --------
```