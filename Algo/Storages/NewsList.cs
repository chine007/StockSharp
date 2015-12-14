#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.Algo.Storages.Algo
File: NewsList.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.Algo.Storages
{
	using Ecng.Serialization;

	using StockSharp.BusinessEntities;

	/// <summary>
	/// The class for representation in the form of list of news, stored in the external storage.
	/// </summary>
	public class NewsList : BaseStorageEntityList<News>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NewsList"/>.
		/// </summary>
		/// <param name="storage">The special interface for direct access to the storage.</param>
		public NewsList(IStorage storage)
			: base(storage)
		{
		}
	}
}