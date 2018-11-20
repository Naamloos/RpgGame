using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Engine
{
    public interface IDrawableItem
    {
        void Draw(int x, int y);
        void Update();
        DrawLayer GetDrawLayer();
    }
}
