using UnityEngine;

[ExecuteAlways]
public class CubeMapCamera : MonoBehaviour
{
    #region Field

    public Camera frontCamera;
    public Camera leftCamera;
    public Camera rightCamera;
    public Camera backCamera;
    public Camera upCamera;
    public Camera downCamera;

    private Camera[] cameras;

    #endregion Field

    #region Method

    protected virtual void Awake()
    {
        this.cameras = new Camera[]
        {
            frontCamera,
            leftCamera,
            rightCamera,
            backCamera,
            upCamera,
            downCamera,
        };
    }

    protected virtual void Start()
    {
        foreach (Camera camera in this.cameras)
        {
            camera.fieldOfView = 90;
            camera.aspect = 1;
        }
    }

    #endregion Method
}