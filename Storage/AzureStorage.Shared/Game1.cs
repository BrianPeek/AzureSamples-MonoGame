using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AzureStorage
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		// Replace with your own key
		const string ConnectionString = "REPLACE WITH YOUR OWN KEY";
		// Replace with your own key


		GraphicsDeviceManager _graphics;
		SpriteBatch _spriteBatch;
		SpriteFont _font;

		BaseStorage _storage;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
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
		protected override void Update(GameTime gameTime)
		{
			KeyboardState state = Keyboard.GetState();

			if(_storage == null || !_storage.Running)
			{
				if(state.IsKeyDown(Keys.D1))
				{
					BlobStorage s = new BlobStorage();
					_storage = s;
					s.Initialize(ConnectionString);
					s.BlobStorageTest();
				}
				else if(state.IsKeyDown(Keys.D2))
				{
					FileStorage s = new FileStorage();
					_storage = s;
					s.Initialize(ConnectionString);
					s.FileStorageTest();
				}
				else if(state.IsKeyDown(Keys.D3))
				{
					QueueStorage s = new QueueStorage();
					_storage = s;
					s.Initialize(ConnectionString);
					s.QueueStorageTest();
				}
				else if(state.IsKeyDown(Keys.D4))
				{
					TableStorage s = new TableStorage();
					_storage = s;
					s.Initialize(ConnectionString);
					s.TableStorageTest();
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
				_spriteBatch.DrawString(_font, "Press 1) Blob, 2) File, 3) Queue, 4) Table", new Vector2(20,20), Color.Red);

				if(_storage != null)
					_spriteBatch.DrawString(_font, _storage.Text, new Vector2(20,60), Color.White);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
