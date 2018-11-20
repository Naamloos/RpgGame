using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Engine
{
    public class InputManager
    {
        KeyboardState prevks;
        GamePadState prevgs;
        KeyboardState currks;
        GamePadState currgs;
        public InputManager()
        {
            prevks = Keyboard.GetState();
            prevgs = GamePad.GetState(PlayerIndex.One);
            currgs = prevgs;
            currks = prevks;
        }

        public bool IsKeyPress(PlayerKeys key)
        {
            switch (key)
            {
                case PlayerKeys.Up:
                    return _keyPress(Keys.Up) || _btnPress(Buttons.DPadUp);

                case PlayerKeys.Down:
                    return _keyPress(Keys.Down) || _btnPress(Buttons.DPadDown);

                case PlayerKeys.Left:
                    return _keyPress(Keys.Left) || _btnPress(Buttons.DPadLeft);

                case PlayerKeys.Right:
                    return _keyPress(Keys.Right) || _btnPress(Buttons.DPadRight);

                case PlayerKeys.Interact:
                    return _keyPress(Keys.Z) || _btnPress(Buttons.A);

                case PlayerKeys.Back:
                    return _keyPress(Keys.X) || _btnPress(Buttons.B);

                case PlayerKeys.Pause:
                    return _keyPress(Keys.C) || _btnPress(Buttons.Start);

                default:
                    return false;
            }
        }

        public bool IsKeyHold(PlayerKeys key)
        {
            switch (key)
            {
                case PlayerKeys.Up:
                    return currks.IsKeyDown(Keys.Up) || currgs.IsButtonDown(Buttons.DPadUp);

                case PlayerKeys.Down:
                    return currks.IsKeyDown(Keys.Down) || currgs.IsButtonDown(Buttons.DPadDown);

                case PlayerKeys.Left:
                    return currks.IsKeyDown(Keys.Left) || currgs.IsButtonDown(Buttons.DPadLeft);

                case PlayerKeys.Right:
                    return currks.IsKeyDown(Keys.Right) || currgs.IsButtonDown(Buttons.DPadRight);

                case PlayerKeys.Interact:
                    return currks.IsKeyDown(Keys.Z) || currgs.IsButtonDown(Buttons.A);

                case PlayerKeys.Back:
                    return currks.IsKeyDown(Keys.X) || currgs.IsButtonDown(Buttons.B);

                case PlayerKeys.Pause:
                    return currks.IsKeyDown(Keys.C) || currgs.IsButtonDown(Buttons.Start);

                default:
                    return false;
            }
        }

        private bool _keyPress(Keys key)
        {
            return currks.IsKeyDown(key) || prevks.IsKeyUp(key);
        }

        private bool _btnPress(Buttons button)
        {
            return currgs.IsButtonDown(button) || prevgs.IsButtonUp(button);
        }

        /// <summary>
        /// Update is to be called last in every update methodS
        /// </summary>
        /// <param name="ks"></param>
        /// <param name="gs"></param>
        public void Update(KeyboardState ks, GamePadState gs)
        {
            prevks = currks;
            prevgs = currgs;
            currgs = gs;
            currks = ks;
        }
    }

    public enum PlayerKeys
    {
        Up,
        Down,
        Left,
        Right,
        Interact,
        Back,
        Pause
    }
}
