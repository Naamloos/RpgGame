using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgGame.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Engine
{
    public class Animation
    {
        List<Sprite> _frames;
        TimeSpan _duration;
        TimeSpan _timer;
        int _width;
        int _height;
        bool _finalized = false;
        SpriteBatch _spritebatch;
        DateTimeOffset _previous;

        public Animation(int width, int height, TimeSpan duration, SpriteBatch spritebatch)
        {
            this._width = width;
            this._height = height;
            this._frames = new List<Sprite>();
            this._duration = duration;
            this._timer = new TimeSpan(0);
            this._spritebatch = spritebatch;
            this._previous = DateTimeOffset.Now;
        }

        public void Draw(int x, int y)
        {
            var frameduration = (float)this._duration.TotalMilliseconds / this._frames.Count;
            var frameid = 0;

            for(int i = 0; i < _frames.Count; i++)
            {
                if (_timer.TotalMilliseconds > (frameduration * i))
                    frameid = i;
            }
            Console.WriteLine($"{_timer.TotalMilliseconds} : {frameduration}");
            _frames[frameid].Draw(x, y);
        }

        public void Update()
        {
            this._timer = DateTimeOffset.Now.Subtract(this._previous);
            if (this._timer > this._duration)
            {
                this._previous = DateTimeOffset.Now;
            }
        }

        public void AddFrame(Texture2D texture)
        {
            if (!this._finalized)
                this._frames.Add(new Sprite(texture, this._width, this._height, this._spritebatch));
            else
                throw new AnimationFinalizedException("This animation has already been finalized. You can not modify it.");
        }

        public void AddFrame(Sprite sprite)
        {
            if (!this._finalized)
                this._frames.Add(sprite);
            else
                throw new AnimationFinalizedException("This animation has already been finalized. You can not modify it.");
        }

        public void FinalizeAnimation()
        {
            this._finalized = true;
        }
    }
}
