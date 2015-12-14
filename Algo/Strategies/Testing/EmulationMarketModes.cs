#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.Algo.Strategies.Testing.Algo
File: EmulationMarketModes.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.Algo.Strategies.Testing
{
	using StockSharp.Localization;

	/// <summary>
	/// The data type for paper trading.
	/// </summary>
	public enum EmulationMarketDataModes
	{
		/// <summary>
		/// Storage.
		/// </summary>
		[EnumDisplayNameLoc(LocalizedStrings.Str1405Key)]
		Storage,

		/// <summary>
		/// Generated.
		/// </summary>
		[EnumDisplayNameLoc(LocalizedStrings.Str1406Key)]
		Generate,

		/// <summary>
		/// None.
		/// </summary>
		[EnumDisplayNameLoc(LocalizedStrings.Str1407Key)]
		No
	}
}