using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using Bonex;
using MelonLoader;

[assembly: AssemblyTitle(nameof(Bonex))]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(null!)]
[assembly: AssemblyProduct(nameof(Bonex))]
[assembly: AssemblyCopyright("Copyright (c) 2023 Frederick (Millzy) Mills")]
[assembly: AssemblyTrademark(null)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyFileVersion("0.1.0")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: MelonInfo(typeof(Mod), nameof(Bonex), "0.1.0", "Millzy",
    "https://github.com/MillzyDev/Bonex/releases/latest/download/Bonex.zip")]

[assembly: MelonPriority(-1000000)]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]
[assembly: MelonID("dev.millzy.Bonex")]

[assembly: VerifyLoaderVersion("0.5.7")]

[assembly: HarmonyDontPatchAll]