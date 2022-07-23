using Unity.Netcode;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
///     This will run once before any other scene script
/// </summary>
public static class Bootstrapper {
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize() {
        MatchmakingService.ResetStatics();
        Addressables.InstantiateAsync("CanvasUtilities");
    }
}