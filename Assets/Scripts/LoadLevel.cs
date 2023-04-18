using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LoadLevel : MonoBehaviour {
    [SerializeField] private List<DefaultAsset> levelTextAssets;
    private void Start() {
        
        foreach (DefaultAsset textAsset in levelTextAssets) Debug.Log(textAsset.name);
    }
    private TextAsset ConvertToTextAsset(DefaultAsset defaultAsset) {
        return (TextAsset)defaultAsset.ConvertTo(typeof(TextAsset));
    }
}
