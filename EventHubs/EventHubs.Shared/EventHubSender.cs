using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using MonoGame.Common;

namespace EventHubs.Shared
{
	public class EventHubSender
	{
		public bool Running { get; set; }
		private readonly TextBox _textbox;
		private readonly string _connectionString;
		private readonly string _entityPath;
		private static EventHubClient _eventHubClient;

		public EventHubSender(TextBox tb, string connectionString, string entityPath)
		{
			_textbox = tb;
			_connectionString = connectionString;
			_entityPath = entityPath;
		}

		public async Task TestEventHubsSender()
		{
			Running = true;

			_textbox.ClearOutput();
			_textbox.WriteLine("-- Testing Event Hub Sender --");

			try
			{
				EventHubsConnectionStringBuilder connectionStringBuilder = new EventHubsConnectionStringBuilder(_connectionString)
				{
					EntityPath = _entityPath
				};

				_eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
				await SendMessagesToEventHub(10);

			}
			catch (Exception ex)
			{
				_textbox.WriteLine(ex.Message);
			}
			finally
			{
				await _eventHubClient.CloseAsync();
				Running = false;
				_textbox.WriteLine("-- Test Complete --");
			}
		}

		private async Task SendMessagesToEventHub(int numMessagesToSend)
		{
			for (int i = 0; i < numMessagesToSend; i++)
			{
				try
				{
					string message = $"Custom message from MonoGame {i} at {DateTime.Now}";
					_textbox.WriteLine($"Sending message: {message}");
					await _eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
				}
				catch (Exception exception)
				{
					_textbox.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
					//something happened so exit the loop
					break;
				}

				await Task.Delay(10);
			}

			_textbox.WriteLine($"{numMessagesToSend} messages sent.");
		}
	}
}
