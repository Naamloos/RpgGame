using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Engine
{
    public class Sprite : IDrawable
    {
        internal Texture2D _texture;
        internal int _width;
        internal int _height;
        Drawer _drawer;
        internal int _tileWidth = 0;
        internal int _tileHeight = 0;
        int _tileindex = 0;
        internal Rectangle _src;
        DrawLayer _layer;

        public Sprite(Texture2D texture, int width, int height, Drawer drawer, DrawLayer layer, int tilewidth = 0, int tileheight = 0, int tileindex = 0)
        {
            this._texture = texture;
            this._width = width;
            this._height = height;
            this._drawer = drawer;
            this._tileHeight = tileheight;
            this._tileWidth = tilewidth;
            this._tileindex = tileindex;

            var xtiles = Math.Floor((double)_texture.Width / _tileWidth);
            var ytiles = Math.Round((double)_texture.Height / _tileHeight);

            var xtile = _tileindex % xtiles;
            var ytile = Math.Floor((_tileindex - xtile) / xtiles);

            Console.WriteLine($"xtiles: {xtiles} ytiles: {ytiles} xtile: {xtile} vertindex: {ytile} " +
                $"srcx: {xtile * _tileWidth} srcy: {ytile * _tileHeight}");

            this._src = new Rectangle((int)xtile * _tileWidth, (int)ytile * _tileHeight, _tileWidth, _tileHeight);
            this._layer = layer;
        }

        public void Draw(int x, int y)
        {
            _drawer.QueueDrawable(this, x, y);
        }

        public void Update()
        {
            // Sprites generally do not need update methods, but
            // Update was added to IDrawable to make sure
            // Sprites and animations exist in the same scope,
            // If anything new gets added it'll be easily applicable to
            // The existing IDrawable.
        }

        public DrawLayer GetDrawLayer()
        {
            return this._layer;
        }
    }
}
