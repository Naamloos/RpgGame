using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Engine
{
    public class Sprite
    {
        Texture2D _texture;
        int _width;
        int _height;
        SpriteBatch _spritebatch;

        public Sprite(Texture2D texture, int width, int height, SpriteBatch spritebatch)
        {
            this._texture = texture;
            this._width = width;
            this._height = height;
            this._spritebatch = spritebatch;
        }

        public void Draw(int x, int y)
        {
            _spritebatch.Draw(_texture, new Rectangle(x, y, _width, _height), Color.White);
        }
    }
}
