using Boneject.MelonLoader;
using Boneject.MelonLoader.Attributes;
using Boneject.Ninject;
using Bonex.Modules;

namespace Bonex;

public class Mod : InjectableMelonMod
{
    [OnInitialize]
    // ReSharper disable once UnusedMember.Global
    public void OnModInitialize(Bonejector bonejector)
    {
        bonejector.Load<BNXMenuModule>(Context.Menu);
    }
}