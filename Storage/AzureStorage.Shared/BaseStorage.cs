using System.IO;
using Microsoft.WindowsAzure.Storage;
using MonoGame.Common;

public class BaseStorage
{
	protected CloudStorageAccount StorageAccount;
	public bool Running;
	public Stream OutputStream;
	private TextBox _textBox;

	public BaseStorage(TextBox tb)
	{
		_textBox = tb;
	}

	// Use this for initialization
	public void Initialize(string connectionString)
	{
		StorageAccount = CloudStorageAccount.Parse(connectionString);
	}

	public void ClearOutput()
	{
		_textBox?.ClearOutput();
	}

	public void WriteLine(string s)
	{
		_textBox?.WriteLine(s);
	}
}
