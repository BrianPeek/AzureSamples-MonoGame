using System.IO;
using Microsoft.WindowsAzure.Storage;

public class BaseStorage
{
	protected CloudStorageAccount StorageAccount;
	public string Text;
	public bool Running;
	public Stream OutputStream;

	// Use this for initialization
	public void Initialize(string connectionString)
	{
		StorageAccount = CloudStorageAccount.Parse(connectionString);
	}

	public void ClearOutput()
	{
		Text = string.Empty;
	}

	public void WriteLine(string s)
	{
		if(Text.Length > 20000)
			Text = string.Empty + "-- TEXT OVERFLOW --";

		Text += s + "\r\n";
	}
}
