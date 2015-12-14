﻿#region S# License
/******************************************************************************************
NOTICE!!!  This program and source code is owned and licensed by
StockSharp, LLC, www.stocksharp.com
Viewing or use of this code requires your acceptance of the license
agreement found at https://github.com/StockSharp/StockSharp/blob/master/LICENSE
Removal of this comment is a violation of the license agreement.

Project: StockSharp.Studio.Controls.ControlsPublic
File: BaseStudioControl.cs
Created: 2015, 11, 11, 2:32 PM

Copyright 2010 by StockSharp, LLC
*******************************************************************************************/
#endregion S# License
namespace StockSharp.Studio.Controls
{
	using System;
	using System.ComponentModel;
	using System.Windows;
	using System.Windows.Controls;

	using Ecng.Common;
	using Ecng.ComponentModel;
	using Ecng.Serialization;
	using Ecng.Xaml;

	using StockSharp.Studio.Core;

	public abstract class BaseStudioControl : UserControl, IStudioControl, INotifyPropertyChanged
	{
		private Action _loadedAction;

		protected BaseStudioControl()
		{
			var type = GetType();

			Title = type.GetDisplayName();
			Icon = type.GetIconUrl();
		}

		#region OnLoaded

		protected void WhenLoaded(Action action)
		{
			_loadedAction = action;
			Loaded += OnLoaded;
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			Loaded -= OnLoaded;
			_loadedAction.SafeInvoke();
		}

		#endregion

		public virtual void Load(SettingsStorage storage)
		{
		}

		public virtual void Save(SettingsStorage storage)
		{
		}

		public virtual void Dispose()
		{
		}

		private string _title;

		public string Title
		{
			get { return _title; }
			protected set
			{
				_title = value;
				_propertyChanged.SafeInvoke(this, "Title");
			}
		}

		public Uri Icon { get; protected set; }

		private PropertyChangedEventHandler _propertyChanged;

		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add { _propertyChanged += value; }
			remove { _propertyChanged -= value; }
		}
	}
}