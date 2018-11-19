using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Engine
{
    public interface IGameScreen
    {
        void InitializeScreen();

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);

        void Unload();
    }
}
