using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame.Modding
{
    internal class ModManager
    {
        public Dictionary<ModMetadata, IMod> LoadedMods;
        public ModCollector Collector;

        public ModManager()
        {
            LoadedMods = new Dictionary<ModMetadata, IMod>();
            Collector = new ModCollector(this);
        }

        public void LoadModAssemblies()
        {
            if (!Directory.Exists("mods"))
            {
                Directory.CreateDirectory("mods");
            }
            foreach(var f in Directory.GetFiles("mods"))
            {
                if (f.EndsWith(".dll"))
                {
                    var cpath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    var dir = Path.GetDirectoryName(cpath);

                    var assm = Assembly.LoadFile(Path.Combine(dir, f));
                    foreach(Type typ in assm.GetTypes())
                    {
                        if (typeof(IMod).IsAssignableFrom(typ))
                        {
                            var mod = (IMod)Activator.CreateInstance(typ);
                            mod.InitializeMod(Collector);
                        }
                    }
                }
            }
        }
    }

    // Restrict direct access to Mod Manager
    public class ModCollector
    {
        private ModManager _manager;

        internal ModCollector(ModManager manager)
        {
            this._manager = manager;
        }

        public void LoadMod(IMod mod, ModMetadata metadata)
        {
            this._manager.LoadedMods.Add(metadata, mod);
            Console.WriteLine($"Loaded mod: {metadata.ModName}");
        }
    }

    // Provides entities and events for mods to interact with
    public class ModProvider
    {
        private ModManager _manager;


    }
}
