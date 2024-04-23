using UnityEngine;
using UnityEditor;

public class SpriteToPrefab : MonoBehaviour
{
    public void CreatePrefabFromSprite(Sprite sprite)
    {
        if (sprite == null)
        {
            Debug.LogError("Sprite is null");
            return;
        }

        // Create a new GameObject
        GameObject go = new GameObject(sprite.name);

        // Add a SpriteRenderer component to the GameObject
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();

        // Assign the sprite to the SpriteRenderer component
        renderer.sprite = sprite;

        // Create a prefab from the GameObject
        string localPath = "Assets/Prefabs/" + go.name + ".prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(go, localPath, InteractionMode.UserAction);
    }
}
