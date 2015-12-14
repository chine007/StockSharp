#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.Hydra.Windows.HydraPublic
File: ImportEnumMappingWindow.xaml.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.Hydra.Windows
{
	using System;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Windows;
	using System.Windows.Controls;

	using Ecng.Collections;
	using Ecng.Common;
	using Ecng.Serialization;
	using Ecng.Xaml;
	using StockSharp.Localization;

	public partial class ImportEnumMappingWindow
	{
		public class MappingValue : IPersistable
		{
			public string ValueFile { get; set; }
			public object ValueStockSharp { get; set; }

			void IPersistable.Load(SettingsStorage storage)
			{
				ValueFile = storage.GetValue<string>("ValueFile");
				ValueStockSharp = storage.GetValue<object>("ValueStockSharp");
			}

			void IPersistable.Save(SettingsStorage storage)
			{
				storage.SetValue("ValueFile", ValueFile);
				storage.SetValue("ValueStockSharp", ValueStockSharp);
			}
		}

		public ImportEnumMappingWindow()
		{
			InitializeComponent();

			ValuesGrid.ItemsSource = _values;
			//_values.CollectionChanged += ValuesOnCollectionChanged;
		}

		//private void ValuesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		//{
		//	Ok.IsEnabled = !Values.IsEmpty();
		//}

		public Type EnumType { get; set; }

		private readonly ObservableCollection<MappingValue> _values = new ObservableCollection<MappingValue>();

		public ObservableCollection<MappingValue> Values => _values;

		private MappingValue SelectedValue => (MappingValue)ValuesGrid.SelectedItem;

		private void Ok_Click(object sender, RoutedEventArgs e)
		{
			var mbBuilder = new MessageBoxBuilder()
				.Owner(this)
				.Error();

			if (Values.Any(v => v.ValueFile.IsEmpty()))
			{
				mbBuilder.Text(LocalizedStrings.Str2832).Show();
				return;
			}

			if (Values.Any(v => v.ValueStockSharp == null))
			{
				mbBuilder.Text(LocalizedStrings.Str2833).Show();
				return;
			}

			DialogResult = true;
		}

		private void AddRow_Click(object sender, RoutedEventArgs e)
		{
			Values.Add(new MappingValue());
		}

		private void RemoveRow_Click(object sender, RoutedEventArgs e)
		{
			Values.RemoveRange(ValuesGrid.SelectedItems.Cast<MappingValue>().ToArray());
		}

		private void ValuesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			RemoveRow.IsEnabled = SelectedValue != null;
		}
	}
}