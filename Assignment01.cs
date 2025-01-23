using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace assignment01;

public class Assignment01 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _background, _tree;
    
    private CelAnimationSequence _sequence01, _sequence02;
    private CelAnimationPlayer _animation01, _animation02;

    private CelAnimationSequenceMultiRow _multiRowAnimationSequence;
    private CelAnimationPlayerMultiRow _multiRowAnimationPlayer;

    private KeyboardState _kbPreviousState;
    public Assignment01()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        //a multi-row sprite sheet with one animation
        
        
        Texture2D spriteSheet = Content.Load<Texture2D>("WalkingMultiRow");
        #region SITUATION: ONE ANIMATION, MULTIPLE ROWS
        //step 01, alter the constructor below to that it accepts a height     
        _multiRowAnimationSequence = new CelAnimationSequenceMultiRow(spriteSheet, 120, 120, 1 / 8.0f);
        _multiRowAnimationPlayer = new CelAnimationPlayerMultiRow();
        //step 02, alter the Play method so that it loops over columns AND rows
        _multiRowAnimationPlayer.Play(_multiRowAnimationSequence);
        #endregion
        
        #region SITUATION: MULTIPLE ROWS, ONE ANIMATION PER ROW
        _multiRowAnimationSequence = new CelAnimationSequenceMultiRow(spriteSheet, 120, 120, 1 / 8.0f, 1);
        _multiRowAnimationPlayer = new CelAnimationPlayerMultiRow();
        _multiRowAnimationPlayer.Play(_multiRowAnimationSequence);
        #endregion

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
