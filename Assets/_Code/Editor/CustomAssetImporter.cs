using UnityEngine;
using UnityEditor;

public class CustomAssetImporter : AssetPostprocessor {
    void OnPreprocessModel() {
        var modelImporter = assetImporter as ModelImporter;
        modelImporter.importMaterials = false;
        //modelImporter.animationType = ModelImporterAnimationType.None;
    }
}
