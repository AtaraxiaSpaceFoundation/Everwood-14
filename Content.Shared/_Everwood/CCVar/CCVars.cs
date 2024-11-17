using Robust.Shared;
using Robust.Shared.Configuration;

namespace Content.Shared.Everwood.CCVar
{
    [CVarDefs]
    public sealed class EverwoodCCVars : CVars
    {

    /*
     * Immersive
     */

    public static readonly CVarDef<bool> ImmersiveEnabled =
        CVarDef.Create("immersive.enabled", true, CVar.SERVERONLY);

    }
}
