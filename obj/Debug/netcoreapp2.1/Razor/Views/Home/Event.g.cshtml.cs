#pragma checksum "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c671c708044516588201da36484c799354f9555"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Event), @"mvc.1.0.view", @"/Views/Home/Event.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Event.cshtml", typeof(AspNetCore.Views_Home_Event))]
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
#line 1 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/_ViewImports.cshtml"
using BeltExam;

#line default
#line hidden
#line 1 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
using BeltExam.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c671c708044516588201da36484c799354f9555", @"/Views/Home/Event.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a84119000702c45f5036e3e300b27d647b6aca13", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Event : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Event>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 187, true);
            WriteLiteral("\n\n<h1 class=\"text-center\" style=\"display: inline-block; width: 90%;\">Dojo Activity Center</h1>\n<a style=\"margin-right: 20px;\" href=\"/home\">Home</a>\n<a href=\"/logout\">Logout</a>\n<br>\n<br>\n");
            EndContext();
#line 10 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
 foreach(var x in @Model)
{

#line default
#line hidden
            BeginContext(259, 51, true);
            WriteLiteral("    <h2 style=\"display: inline-block; width: 90%;\">");
            EndContext();
            BeginContext(311, 7, false);
#line 12 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
                                              Write(x.Title);

#line default
#line hidden
            EndContext();
            BeginContext(318, 6, true);
            WriteLiteral("</h2>\n");
            EndContext();
#line 13 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
     if(x.Creator == ViewBag.LoggedIn)
    {

#line default
#line hidden
            BeginContext(369, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 379, "\"", 404, 2);
            WriteAttributeValue("", 386, "/delete/", 386, 8, true);
#line 15 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
WriteAttributeValue("", 394, x.EventId, 394, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(405, 11, true);
            WriteLiteral(">Delete</a>");
            EndContext();
#line 15 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
                                               ;
    }
    else
    {
        bool y = false;
        

#line default
#line hidden
#line 20 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
         foreach(var user in x.GuestList)
        {
            

#line default
#line hidden
#line 22 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
             if(user.UserId == ViewBag.LoggedIn.UserId)
            {
                y = true;
            }

#line default
#line hidden
#line 25 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
             
        }

#line default
#line hidden
#line 27 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
         if(y == true)
            {

#line default
#line hidden
            BeginContext(672, 41, true);
            WriteLiteral("                <a class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 713, "\"", 738, 2);
            WriteAttributeValue("", 720, "/unrsvp/", 720, 8, true);
#line 29 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
WriteAttributeValue("", 728, x.EventId, 728, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(739, 12, true);
            WriteLiteral(">UnJoin</a>\n");
            EndContext();
#line 30 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
            }
        else
        {

#line default
#line hidden
            BeginContext(788, 38, true);
            WriteLiteral("            <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 826, "\"", 849, 2);
            WriteAttributeValue("", 833, "/rsvp/", 833, 6, true);
#line 33 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
WriteAttributeValue("", 839, x.EventId, 839, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(850, 10, true);
            WriteLiteral(">Join</a>\n");
            EndContext();
#line 34 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
        }

#line default
#line hidden
#line 34 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
         
    }

#line default
#line hidden
            BeginContext(876, 167, true);
            WriteLiteral("    <div class=\"container\">\n        <p style=\"display: inline-block; width: 15%; margin-right: 20px;\">Event Coordinater:</p>\n        <p style=\"display: inline-block;\">");
            EndContext();
            BeginContext(1044, 15, false);
#line 38 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
                                     Write(x.Creator.FName);

#line default
#line hidden
            EndContext();
            BeginContext(1059, 43, true);
            WriteLiteral("</p>\n        <p>Description</p>\n        <p>");
            EndContext();
            BeginContext(1103, 13, false);
#line 40 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
      Write(x.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1116, 75, true);
            WriteLiteral("</p>\n        <br>\n        <br>\n        <h3>Participants:</h3>\n        <ul>\n");
            EndContext();
#line 45 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
         foreach(var guest in x.GuestList)
        {

#line default
#line hidden
            BeginContext(1244, 16, true);
            WriteLiteral("            <li>");
            EndContext();
            BeginContext(1261, 17, false);
#line 47 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
           Write(guest.Guest.FName);

#line default
#line hidden
            EndContext();
            BeginContext(1278, 6, true);
            WriteLiteral("</li>\n");
            EndContext();
#line 48 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
        }

#line default
#line hidden
            BeginContext(1294, 26, true);
            WriteLiteral("        </ul>\n\n    </div>\n");
            EndContext();
#line 52 "/Users/ricardorivera/cSharp/ORM/BeltExam/Views/Home/Event.cshtml"
}

#line default
#line hidden
            BeginContext(1322, 2, true);
            WriteLiteral("\n\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Event>> Html { get; private set; }
    }
}
#pragma warning restore 1591
