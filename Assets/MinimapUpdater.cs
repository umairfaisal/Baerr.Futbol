using UnityEngine;

public class MinimapUpdater : MonoBehaviour
{
    // Ground edges in world space
    public Vector2 groundTopLeft = new Vector2(-33, 11);
    public Vector2 groundTopRight = new Vector2(33, 11);
    public Vector2 groundBottomLeft = new Vector2(-51, -23);
    public Vector2 groundBottomRight = new Vector2(51, -23);

    // Minimap edges in canvas space
    public Vector2 mapTopLeft = new Vector2(-75, 190);
    public Vector2 mapTopRight = new Vector2(73, 190);
    public Vector2 mapBottomLeft = new Vector2(-75, 95);
    public Vector2 mapBottomRight = new Vector2(73, 95);

    // Ball on the ground (assign this in the inspector)
    public Transform ballTransform;

    // Object representing the ball on the minimap (assign this in the inspector)
    public RectTransform minimapBall;

    void Update()
    {
        if (ballTransform != null && minimapBall != null)
        {
            // Get the ball's position on the ground
            Vector2 ballPosition = new Vector2(ballTransform.position.x, ballTransform.position.y);

            // Map the ball's position to the minimap
            Vector2 mappedPosition = MapPositionToMinimap(ballPosition);

            // Update the minimap ball's position
            minimapBall.anchoredPosition = mappedPosition;
        }
    }

    Vector2 MapPositionToMinimap(Vector2 groundPosition)
    {
        // Normalize the ball's position within the ground
        float normalizedX = Mathf.InverseLerp(groundBottomLeft.x, groundBottomRight.x, groundPosition.x);
        
        // Find the interpolated top and bottom Y values for the given X
        float groundTopY = Mathf.Lerp(groundTopLeft.y , groundTopRight.y, normalizedX);
        float groundBottomY = Mathf.Lerp(groundBottomLeft.y, groundBottomRight.y, normalizedX);
        
        // Normalize the Y position
        float normalizedY = Mathf.InverseLerp(groundBottomY, groundTopY, groundPosition.y);

        // Map normalized coordinates to minimap space
        float minimapX = Mathf.Lerp(mapBottomLeft.x, mapBottomRight.x, normalizedX);
        float minimapY = Mathf.Lerp(mapBottomLeft.y, mapTopLeft.y, normalizedY);

        return new Vector2(minimapX, minimapY);
    }
}


