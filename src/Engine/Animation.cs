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

        GameTime _previous;

        public Animation(int width, int height, TimeSpan duration)
        {
            this._width = width;
            this._height = height;
            this._frames = new List<Sprite>();
            this._duration = duration;
            this._timer = new TimeSpan(0);
        }

        public void Draw(int x, int y)
        {
            var frameduration = (float)this._duration.Milliseconds / this._frames.Count;
            var frameid = 0;

            for(int i = 0; i < _frames.Count; i++)
            {
                if (_timer.Milliseconds > (frameduration * i))
                    frameid = i;
            }
            _frames[frameid].Draw(x, y);
        }

        public void Update(GameTime gametime)
        {
            this._timer = gametime.TotalGameTime.Subtract(this._previous.TotalGameTime);
            if (this._timer > this._duration)
                this._previous = gametime;
        }

        public void AddFrame(Texture2D texture)
        {
            if (!this._finalized)
                this._frames.Add(new Sprite(texture, this._width, this._height));
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
