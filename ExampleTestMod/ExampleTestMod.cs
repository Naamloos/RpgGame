using RpgGame.Modding;

namespace ExampleTestMod
{
    public class ExampleTestMod : IMod
    {
        public void InitializeMod(ModCollector collector)
        {
            collector.LoadMod(this, new ModMetadata()
            {
                ModName = "Example mod",
                ModAuthor = "Naamloos",
                ModDescription = "This is an example mod",
                ModLink = "https://github.com/NaamloosDT/RpgGame",
                ModVersion = "0.1 test"
            });
        }
    }

    public class ExampleTestMod2 : IMod
    {
        public void InitializeMod(ModCollector collector)
        {
            collector.LoadMod(this, new ModMetadata()
            {
                ModName = "Example mod2",
                ModAuthor = "Naamloos",
                ModDescription = "This is an example mod2",
                ModLink = "https://github.com/NaamloosDT/RpgGame",
                ModVersion = "0.2 test"
            });
        }
    }
}
