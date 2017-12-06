using EventHubs.Shared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Common;

namespace MobileApps
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		// Replace with your own key
		const string ConnectionString = "USE YOUR CONNECTIONSTRING HERE";
		const string EntityName = "USE YOUR ENTITYNAME HERE";
		// Replace with your own key


		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private SpriteFont _font;
		private TextBox _textBox;

		private EventHubSender _eventHubSender;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
#if WINDOWS
			_graphics.PreferredBackBufferWidth = 1280;
			_graphics.PreferredBackBufferHeight = 1024;
#endif
			Window.AllowUserResizing = true;
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			_font = Content.Load<SpriteFont>("Font");

			_textBox = new TextBox(new Vector2(20,60), _spriteBatch, _font);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override async void Update(GameTime gameTime)
		{
			KeyboardState state = Keyboard.GetState();

			if(_eventHubSender == null || !_eventHubSender.Running)
			{
				if(state.IsKeyDown(Keys.D1))
				{
					_eventHubSender = new EventHubSender(_textBox, ConnectionString, EntityName);
					await _eventHubSender.TestEventHubsSender();
				}
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();
				_spriteBatch.DrawString(_font, "Press 1) Event Hubs", new Vector2(20,20), Color.Red);

				if(_eventHubSender != null)
					_textBox.Draw(gameTime);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
