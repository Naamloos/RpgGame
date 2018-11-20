using Microsoft.Xna.Framework;
using RpgGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.GameData
{
    public class BaseEntity
    {
        public InputManager _input;
        public Point _location;
        public List<IDrawableItem> _textures;
        public int _textureindex;

        public BaseEntity(List<IDrawableItem> textures, int x, int y)
        {
            _location = new Point(x, y);
            _textures = textures;
        }

        public virtual void Draw()
        {
            _textures[_textureindex].Draw(_location.X, _location.Y);
        }

        public virtual void Update(InputManager input)
        {
            _textures[_textureindex].Update();
            this._input = input;
        }
    }
}
