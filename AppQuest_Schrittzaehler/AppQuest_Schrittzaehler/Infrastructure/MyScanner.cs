﻿using System;
using Xamarin.Forms;

namespace AppQuest_Schrittzaehler
{
	public class MyScanner
	{
		public ContentPage ScanQrCode()
		{
			var scanPage = new ZXingScannerPage();

			scanPage.OnScanResult += async (result) =>
			{
				// Stop scanning
				scanPage.IsScanning = false;

				if (!string.IsNullOrEmpty(result.Text))
				{
					memoryItem.Title = result.Text;
					await SaveFile();
				}
				else
					await DisplayAlert("Warnung", "QR-Code konnte nicht gescannt werden.", "OK");

				// Pop the page and show the result
				Device.BeginInvokeOnMainThread(() => { Navigation.PopModalAsync(); });
			};

			// Navigate to our scanner page
			return scanPage;
		}
	}
}