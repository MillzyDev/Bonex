using MelonLoader;

namespace Bonex;

public class Mod : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg("Initialised Bonex");
    }
}