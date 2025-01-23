using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace assignment01;
    
/// <summary>
/// Controls playback of a CelAnimationSequence.
/// NOTE: It can play one and only one CelAnimationSequence at any given time.
/// </summary>
public class CelAnimationPlayerMultiRow
{
    private CelAnimationSequenceMultiRow celAnimationSequenceMultiRow;
    private int celIndex;
    private float celTimeElapsed;
    private Rectangle celSourceRectangle;

    /// <summary>
    /// Begins or continues playback of a CelAnimationSequence.
    /// </summary>
    public void Play(CelAnimationSequenceMultiRow celAnimationSequenceMultiRow)
    {
        if (celAnimationSequenceMultiRow == null)
        {
            throw new Exception("CelAnimationPlayer.PlayAnimation received null CelAnimationSequence");
        }
        // If this animation is already running, do not restart it...
        if (celAnimationSequenceMultiRow != this.celAnimationSequenceMultiRow)
        {
            this.celAnimationSequenceMultiRow = celAnimationSequenceMultiRow;
            celIndex = 0;
            celTimeElapsed = 0.0f;

            celSourceRectangle.X = 0;
            celSourceRectangle.Y = 0;
            celSourceRectangle.Width = this.celAnimationSequenceMultiRow.CelWidth;
            celSourceRectangle.Height = this.celAnimationSequenceMultiRow.CelHeight;
        }
    }

    /// <summary>
    /// Update the state of the CelAnimationPlayer.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    public void Update(GameTime gameTime)
    {
        if (celAnimationSequenceMultiRow != null)
        {
            celTimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (celTimeElapsed >= celAnimationSequenceMultiRow.CelTime)
            {
                celTimeElapsed -= celAnimationSequenceMultiRow.CelTime;

                // Advance the frame index looping as appropriate...
                celIndex = (celIndex + 1) % celAnimationSequenceMultiRow.CelCount;

                celSourceRectangle.X = celIndex * celSourceRectangle.Width;
            }
        }
    }

    /// <summary>
    /// Draws the current cel of the animation.
    /// </summary>
    public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects spriteEffects)
    {
        if (celAnimationSequenceMultiRow != null)
        {
            spriteBatch.Draw(celAnimationSequenceMultiRow.Texture, position, celSourceRectangle, Color.White, 0.0f, Vector2.Zero, 1.0f, spriteEffects, 0.0f);
        }
    }
}

