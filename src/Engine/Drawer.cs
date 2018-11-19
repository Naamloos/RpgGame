using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Shitty naming, cool-ish functionality
namespace RpgGame.Engine
{
    public class Drawer
    {
        List<Tuple<Sprite, DrawerCoords>> _drawables;
        SpriteBatch _spritebatch;

        public Drawer(SpriteBatch spritebatch)
        {
            this._spritebatch = spritebatch;
            this._drawables = new List<Tuple<Sprite, DrawerCoords>>();
        }

        public void QueueDrawable(Sprite drawable, int x, int y)
        {
            _drawables.Add(new Tuple<Sprite, DrawerCoords>(drawable, new DrawerCoords() { x = x, y = y }));
        }

        public void DrawAll(SpriteBatch sb)
        {
            var draw = _drawables.OrderBy(x => x.Item1.GetDrawLayer());
            foreach(var item in draw)
            {
                if (item.Item1._tileWidth == 0 && item.Item1._tileHeight == 0)
                {
                    _spritebatch.Draw(item.Item1._texture, new Rectangle(item.Item2.x, item.Item2.y, 
                        item.Item1._width, item.Item1._height), Color.White);
                }
                else
                {
                    _spritebatch.Draw(item.Item1._texture, new Rectangle(item.Item2.x, item.Item2.y, 
                        item.Item1._width, item.Item1._height), item.Item1._src, Color.White);
                }
            }
            _drawables.Clear();
        }
    }

    internal struct DrawerCoords
    {
        public int x;
        public int y;
    }
}
