using UnityEngine;

/// <summary>
/// Wraps the GameObject horizontally around the screen edges.
/// </summary>
public class ScreenWrap : MonoBehaviour
{
    [SerializeField, Tooltip("Extra margin added to screen edges for wrapping.")]
    private float wrapMargin = 0f;

    private float screenHalfWidthWorldUnits;
    private Camera mainCamera;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("[ScreenWrap] Main camera not found. Disabling ScreenWrap.");
            enabled = false;
            return;
        }

        RecalculateScreenBounds();
    }

    /// <summary>
    /// Recalculates the horizontal wrap boundary in world units.
    /// Call this if the camera size or object scale changes at runtime.
    /// </summary>
    private void RecalculateScreenBounds()
    {
        float halfObjectWidth = _transform.localScale.x / 2f;
        screenHalfWidthWorldUnits = mainCamera.aspect * mainCamera.orthographicSize + halfObjectWidth + wrapMargin;
    }

    private void Update()
    {
        Vector3 pos = _transform.position;

        if (pos.x > screenHalfWidthWorldUnits)
        {
            pos.x = -screenHalfWidthWorldUnits;
        }
        else if (pos.x < -screenHalfWidthWorldUnits)
        {
            pos.x = screenHalfWidthWorldUnits;
        }

        _transform.position = pos;
    }
}