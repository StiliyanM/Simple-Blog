#pragma checksum "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1d260f633a149d8b5ec1b8f02a86709ebef250e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Categories_Posts), @"mvc.1.0.razor-page", @"/Pages/Categories/Posts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Categories/Posts.cshtml", typeof(AspNetCore.Pages_Categories_Posts), null)]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\_ViewImports.cshtml"
using MyBlog.Web;

#line default
#line hidden
#line 2 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\_ViewImports.cshtml"
using MyBlog.Web.Models;

#line default
#line hidden
#line 3 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\_ViewImports.cshtml"
using MyBlog.Models;

#line default
#line hidden
#line 4 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\_ViewImports.cshtml"
using MyBlog.Common.ViewModels.Posts;

#line default
#line hidden
#line 5 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\_ViewImports.cshtml"
using MyBlog.Common.BindingModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1d260f633a149d8b5ec1b8f02a86709ebef250e", @"/Pages/Categories/Posts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06f42534db8088f417ae626465cdfedd4ded9428", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Categories_Posts : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Posts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(7, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"
  
    ViewData["Title"] = "Categories";

#line default
#line hidden
            BeginContext(91, 29, true);
            WriteLiteral("<h2>Categories</h2>\r\n<hr />\r\n");
            EndContext();
#line 9 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"
 foreach (var category in Model.Categories)
{

#line default
#line hidden
            BeginContext(168, 8, true);
            WriteLiteral("    <h3>");
            EndContext();
            BeginContext(177, 13, false);
#line 11 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"
   Write(category.Name);

#line default
#line hidden
            EndContext();
            BeginContext(190, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 13 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"
     if (category.Posts.Count() == 0)
    {

#line default
#line hidden
            BeginContext(245, 47, true);
            WriteLiteral("        <p>No posts yet in this category!</p>\r\n");
            EndContext();
#line 16 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"
    }

#line default
#line hidden
            BeginContext(299, 10, true);
            WriteLiteral("    <ul>\r\n");
            EndContext();
#line 18 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"
         foreach (var post in category.Posts)
        {

#line default
#line hidden
            BeginContext(367, 34, true);
            WriteLiteral("            <li>\r\n                ");
            EndContext();
            BeginContext(401, 158, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6bf49828c6374600972028e47a91b974", async() => {
                BeginContext(545, 10, false);
#line 24 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"
                                      Write(post.Title);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 24 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"
                     WriteLiteral(post.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(559, 21, true);
            WriteLiteral("\r\n            </li>\r\n");
            EndContext();
#line 26 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"
        }

#line default
#line hidden
            BeginContext(591, 23, true);
            WriteLiteral("    </ul>\r\n    <hr />\r\n");
            EndContext();
#line 29 "D:\MyBlog\Simple-Blog\MyBlog.Web\Pages\Categories\Posts.cshtml"

}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyBlog.Web.Pages.PostsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyBlog.Web.Pages.PostsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyBlog.Web.Pages.PostsModel>)PageContext?.ViewData;
        public MyBlog.Web.Pages.PostsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591