using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgGame.Engine;

namespace RpgGame.GameData.Entities
{
    public class Player : BaseEntity
    {
        public Player(List<IDrawableItem> textures, int x, int y) :base(textures, x, y)
        {

        }

        public override void Update(InputManager input)
        {
            if (input.IsKeyHold(PlayerKeys.Left))
                _location.X -= 2;
            if (input.IsKeyHold(PlayerKeys.Right))
                _location.X += 2;
            if (input.IsKeyHold(PlayerKeys.Up))
                _location.Y -= 2;
            if (input.IsKeyHold(PlayerKeys.Down))
                _location.Y += 2;

            base.Update(input);
        }
    }
}
