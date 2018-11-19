using RpgGame.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.GameData
{
    public class MapManager
    {
    }

    public class Map
    {

    }

    public class MapLayer
    {

    }

    public class MapTile
    {
        public bool Passable = true;
        public IDrawable Sprite;

        public MapTile(IDrawable sprite, bool passable = true)
        {
            this.Sprite = sprite;
            this.Passable = passable;
        }
    }
}
