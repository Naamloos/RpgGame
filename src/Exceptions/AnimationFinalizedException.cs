using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Exceptions
{
    public class AnimationFinalizedException : Exception
    {
        public AnimationFinalizedException() : base()
        {

        }

        public AnimationFinalizedException(string message) : base(message)
        {

        }
    }
}
