using UnityEngine;

namespace Fluo {

static class ShaderID
{
    public static readonly int Alternate = Shader.PropertyToID("_Alternate");
    public static readonly int BodyPixTex = Shader.PropertyToID("_BodyPixTex");
    public static readonly int EffectColor = Shader.PropertyToID("_EffectColor");
    public static readonly int FluoAudioLevel = Shader.PropertyToID("_Fluo_AudioLevel");
    public static readonly int FluoCanvasAlphaDecay = Shader.PropertyToID("_Fluo_CanvasAlphaDecay");
    public static readonly int FluoThemeColor = Shader.PropertyToID("_Fluo_ThemeColor");
    public static readonly int LutBlend = Shader.PropertyToID("_LutBlend");
    public static readonly int LutTex = Shader.PropertyToID("_LutTex");
}

} // namespace Fluo
