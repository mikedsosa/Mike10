﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mike10.Models;

namespace Mike10.Infrastructure
{
	[HtmlTargetElement("div", Attributes = "page-model")]
	public class PaginationTagHelper : TagHelper
	{
		private IUrlHelperFactory urlHelperFactory;

		public PaginationTagHelper(IUrlHelperFactory hp)
		{
			urlHelperFactory = hp;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext ViewContext { get; set; }
		public Mike10.Models.ViewModels.PagingInfo PageModel { get; set; }
		public string PageAction { get; set; }

		//whenever someone enters page-url-______ it will be stored in the dictionary 
		[HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
		public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

		// As long as this is set to "true" in the index page or wherever the tag helpers are use...
		// it will automatically apply Css and stuff to the nav bar
		public bool PageClassesEnabled { get; set; }
		public string PageClass { get; set; }
		public string PageClassNormal { get; set; }
		public string PageClassSelected { get; set; }

		// Overriding
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

			TagBuilder result = new TagBuilder("div");

			for (int i = 1; i <= PageModel.TotalPages; i++)
			{
				//Building tag
				TagBuilder tag = new TagBuilder("a");

				PageUrlValues["pageNum"] = i;
				tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

				//if there is an attribute called PageClassesEnabled set to "true", do the following
				if (PageClassesEnabled)
				{
					tag.AddCssClass(PageClass);
					tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
				}
				tag.InnerHtml.Append(i.ToString());

				//append tag to html
				result.InnerHtml.AppendHtml(tag);
			}

			output.Content.AppendHtml(result.InnerHtml);
		}
	}
}
