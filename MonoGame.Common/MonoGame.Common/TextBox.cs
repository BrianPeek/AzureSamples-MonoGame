using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Common
{
	public class TextBox
	{
		public string Text { get; set; }
		public SpriteFont Font { get; set; }
		public SpriteBatch SpriteBatch { get; set; }
		public Vector2 Position { get; set; }

		public TextBox(Vector2 pos, SpriteBatch sb, SpriteFont sf)
		{
			Position = pos;
			SpriteBatch = sb;
			Font = sf;
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

		public void Draw(GameTime gameTime)
		{
			if(SpriteBatch != null && Font != null && !string.IsNullOrEmpty(Text))
				SpriteBatch.DrawString(Font, Text, Position, Color.White);

		}
	}
}
