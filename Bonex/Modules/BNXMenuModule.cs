using MelonLoader;
using Ninject.Modules;

namespace Bonex.Modules;

public class BNXMenuModule : NinjectModule
{
    public override void Load()
    {
        MelonLogger.Msg("Loaded");
    }
}