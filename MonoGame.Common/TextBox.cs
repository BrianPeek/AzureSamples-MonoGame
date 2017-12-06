using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.Common
{
	public class TextBox
	{
		public Vector2 Position { get; set; }

		private string _text = string.Empty;
		private SpriteFont _font { get; set; }
		private SpriteBatch _spriteBatch { get; set; }


		public TextBox(Vector2 pos, SpriteBatch sb, SpriteFont sf)
		{
			Position = pos;
			_spriteBatch = sb;
			_font = sf;
		}

		public void ClearOutput()
		{
			_text = string.Empty;
		}

		public void WriteLine(string s)
		{
			if(_text.Length > 20000)
				_text = string.Empty + "-- TEXT OVERFLOW --";

			_text += s + "\r\n";
		}

		public void Draw(GameTime gameTime)
		{
			if(_spriteBatch != null && _font != null && !string.IsNullOrEmpty(_text))
				_spriteBatch.DrawString(_font, _text, Position, Color.White);

		}
	}
}
