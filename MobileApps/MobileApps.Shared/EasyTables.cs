using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using MonoGame.Common;

namespace MobileApps.Shared
{
	public class EasyTables
	{
		private TextBox _textbox;
		private MobileServiceClient _client;
		public bool Running;

		public EasyTables(TextBox tb, string uri)
		{
			_textbox = tb;

			_client = new MobileServiceClient(uri);
		}


		public async void EasyTablesTest()
		{
			Running = true;

			_textbox.ClearOutput();
			_textbox.WriteLine("-- Testing Easy Tables --");

			_textbox.WriteLine("Getting table");
			IMobileServiceTable<TodoItem> tbl = _client.GetTable<TodoItem>();

			_textbox.WriteLine("Inserting new item");
			try
			{
				await tbl.InsertAsync(new TodoItem { Text = "New item" });

				_textbox.WriteLine("Getting unfinished items");
				List<TodoItem> list = await tbl.Where(i => i.Complete == false).ToListAsync();
				foreach(TodoItem item in list)
					_textbox.WriteLine($"{item.Id} - {item.Text} - {item.Complete}");

				_textbox.WriteLine("Updating first item");
				list[0].Complete = true;
				await tbl.UpdateAsync(list[0]);

				_textbox.WriteLine("Deleting first item");
				await tbl.DeleteAsync(list[0]);
			}
			catch(Exception e)
			{
				_textbox.WriteLine(e.ToString());
			}

			_textbox.WriteLine("-- Test Complete --");
			Running = false;
		}
	}
}
