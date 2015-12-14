﻿#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.Transaq.Native.Responses.Transaq
File: LeverageControlResponse.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.Transaq.Native.Responses
{
	using System.Collections.Generic;

	internal class LeverageControlResponse : BaseResponse
	{
		public string Client { get; set; }
		public decimal? LeveragePlan { get; set; }
		public decimal? LeverageFact { get; set; }

		public IEnumerable<LeverageControlSecurity> Items { get; internal set; }
	}

	internal class LeverageControlSecurity
	{
		public string Board { get; set; }
		public string SecCode { get; set; }
		public long MaxBuy { get; set; }
		public long MaxSell { get; set; }
	}
}