using UnityEngine;

public class FullscreenSprite : MonoBehaviour
{

    void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        Camera camera = Camera.main;
        // camera.nearClipPlane + camera.transform.position.z ;
        float distanceFromCamera = camera.transform.position.z - transform.position.z; // Change this value if you want
        Vector3 topLeft = camera.ViewportToWorldPoint(new Vector3(0, 1, distanceFromCamera));
        Vector3 bottomRight = camera.ViewportToWorldPoint(new Vector3(1, 0, distanceFromCamera));

        Vector2 cameraSize = new Vector2(Mathf.Abs(topLeft.x - bottomRight.x), Mathf.Abs(topLeft.y - bottomRight.y));
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        float spriteAspect = spriteSize.x / spriteSize.y;
        float cameraAspect = cameraSize.x / cameraSize.y;

        float dx = cameraSize.x / spriteSize.x;
        float dy = cameraSize.y / spriteSize.y;

        float newScale = dx > dy ? dx : dy;

        float width = Screen.width;
        float height = Screen.height;

        

        float scaleX = newScale;
        float scaleY = newScale;

        Vector2 scale = transform.localScale;
        scale.x = scaleX;
        scale.y = scaleY;
        transform.localScale = scale;

        //transform.position = new Vector2(width * 0.5f, height * 0.5f);
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, transform.position.z);
        /*

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        transform.position = Vector2.zero; // Optional
        transform.localScale = scale;*/
    }
}