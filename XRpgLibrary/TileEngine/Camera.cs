using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XXRpgLibrary.SpriteClasses;

namespace XXRpgLibrary.TileEngine
{
    public enum CameraMode { Free, Follow, Fixed }

    public class Camera
    {
        #region Properties

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        float speed;
        public float Speed
        {
            get { return speed; }
            set
            {
                speed = (float)MathHelper.Clamp(value, 1f, 16f);
            }
        }

        public float Zoom
        {
            get;
            private set;
        }

        public Rectangle ViewportRectangle
        {
            get;
            private set;
        }

        public Matrix Transformation
        {
            get { return Matrix.CreateScale(Zoom) * Matrix.CreateTranslation(new Vector3(-position, 0f)); }
        }

        public CameraMode CameraMode
        {
            get;
            set;
        }

        #endregion

        public Camera(Rectangle viewportRect)
        {
            speed = 4f;
            Zoom = 1f;
            ViewportRectangle = viewportRect;
            CameraMode = CameraMode.Fixed;
        }

        public Camera(Rectangle viewportRect, Vector2 position)
            : this(viewportRect)
        {
            this.position = position;
        }

        #region Methods

        public void Update(GameTime gameTime)
        {
            if (CameraMode == CameraMode.Fixed)
                return;

            if (InputHandler.KeyReleased(Keys.PageUp) ||
                InputHandler.ButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
            {
                ZoomIn();
            }
            else if (InputHandler.KeyReleased(Keys.PageDown) ||
                InputHandler.ButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
            {
                ZoomOut();
            }
            
            if (CameraMode == CameraMode.Follow)
                return;

            Vector2 diff = Vector2.Zero;

            if (InputHandler.KeyDown(Keys.Left) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickLeft, PlayerIndex.One))
                diff.X -= speed;
            else if (InputHandler.KeyDown(Keys.Right) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickRight, PlayerIndex.One))
                diff.X += speed;

            if (InputHandler.KeyDown(Keys.Up) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickUp, PlayerIndex.One))
                diff.Y -= speed;
            else if (InputHandler.KeyDown(Keys.Down) ||
                InputHandler.ButtonDown(Buttons.RightThumbstickDown, PlayerIndex.One))
                diff.Y += speed;

            if (diff != Vector2.Zero)
            {
                diff.Normalize();
                position += diff * speed;

                LockCamera();
            }
        }

        private void ZoomIn()
        {
            Zoom += 0.25f;

            if (Zoom > 2.5f)
                Zoom = 2.5f;

            SnapToPosition(Position * Zoom);
        }

        private void ZoomOut()
        {
            Zoom -= 0.25f;

            if (Zoom < 0.5f)
                Zoom = 0.5f;

            SnapToPosition(Position * Zoom);
        }

        // This function prevents a camera bug when zooming out after being zoomed in.
        private void SnapToPosition(Vector2 newPosition)
        {
            position.X = newPosition.X - ViewportRectangle.Width * 0.5f;
            position.Y = newPosition.Y - ViewportRectangle.Height * 0.5f;

            LockCamera();
        }

        public void LockCamera()
        {
            position.X = MathHelper.Clamp(Position.X, 0, TileMap.WidthInPixels * Zoom - ViewportRectangle.Width);
            position.Y = MathHelper.Clamp(Position.Y, 0, TileMap.HeightInPixels * Zoom - ViewportRectangle.Height);
        }

        public void LockToSprite(AnimatedSprite sprite)
        {
            position.X = (sprite.Position.X + sprite.Width * 0.5f) * Zoom - ViewportRectangle.Width * 0.5f;
            position.Y = (sprite.Position.Y + sprite.Height * 0.5f) * Zoom - ViewportRectangle.Height * 0.5f;

            LockCamera();
        }

        public void ToggleCameraMode()
        {
            if (CameraMode == CameraMode.Follow)
                CameraMode = CameraMode.Free;
            else if (CameraMode == CameraMode.Free)
                CameraMode = CameraMode.Follow;
        }

        #endregion
    }
}
