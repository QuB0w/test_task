using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressablesPrefabInstantiator : MonoBehaviour
{
    [SerializeField] AssetReference loadablePrefab;

    private void Start()
    {
        loadablePrefab.InstantiateAsync();
    }
}
