using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.GameData
{
    public class TileManager
    {
        Dictionary<string, IDrawable> Tiles;

        public TileManager()
        {
            Tiles = new Dictionary<string, IDrawable>();
        }

        public void LoadTile(string id, IDrawable drawable)
        {
            Tiles.Add(id, drawable);
        }
    }
}
