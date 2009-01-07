﻿using System;
using N2.Engine;

namespace N2.Collections
{
	/// <summary>
	/// Helps passing a delegate function used to determine wheter the item should be filtered.
	/// </summary>
	public class DelegateFilter : ItemFilter
	{
		readonly Function<ContentItem, bool> isPositiveMatch;

		public DelegateFilter(Function<ContentItem, bool> isPositiveMatch)
		{
			if (isPositiveMatch == null) throw new ArgumentNullException("isPositiveMatch");

			this.isPositiveMatch = isPositiveMatch;
		}

		public override bool Match(ContentItem item)
		{
			return isPositiveMatch(item);
		}
	}
}
