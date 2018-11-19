using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Modding
{
    public interface IMod
    {
        void InitializeMod(ModCollector collector);
    }

    public class ModMetadata
    {
        public string ModName;
        public string ModVersion;
        public string ModAuthor;
        public string ModDescription;
        public string ModLink;
    }
}
