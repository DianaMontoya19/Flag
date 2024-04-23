using UnityEngine;

public class TextureToSpriteConverter : MonoBehaviour
{
    public Sprite ConvertRenderTextureToSprite(RenderTexture renderTexture)
    {
        if (renderTexture == null)
        {
            Debug.LogError("RenderTexture is null");
            return null;
        }

        // Activate the RenderTexture
        RenderTexture.active = renderTexture;

        // Create a new Texture2D and read the RenderTexture image into it
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height);
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();

        // Deactivate the RenderTexture
        RenderTexture.active = null;

        // Convert the Texture2D to a Sprite
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        return sprite;
    }
}
