using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class CubuMapProjectionManager : ProjectionManager
{
    #region Enum

    public enum ProjectionMode
    {
        All,
        Front,
        Left,
        Right,
        Back,
        Top,
        Bottom
    }

    #endregion Enum

    #region Field

    public ProjectionMode projectionMode;

    public RenderTexture textureFront;
    public RenderTexture textureLeft;
    public RenderTexture textureRight;
    public RenderTexture textureBack;
    public RenderTexture textureTop;
    public RenderTexture textureBottom;

    #endregion Field

    #region Method

    protected override void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        switch (this.projectionMode)
        {
            case ProjectionMode.All:
            {
                int quarterWidth = Screen.width / 4;
                int thirdHeight  = Screen.height / 3;

                if (quarterWidth > thirdHeight)
                {
                    quarterWidth = thirdHeight;
                }
                else
                {
                    thirdHeight = quarterWidth;
                }

                Rect viewportRectFront  = new Rect(quarterWidth * 1, thirdHeight * 1, quarterWidth, thirdHeight);
                Rect viewportRectLeft   = new Rect(quarterWidth * 0, thirdHeight * 1, quarterWidth, thirdHeight);
                Rect viewportRectRight  = new Rect(quarterWidth * 2, thirdHeight * 1, quarterWidth, thirdHeight);
                Rect viewportRectBack   = new Rect(quarterWidth * 3, thirdHeight * 1, quarterWidth, thirdHeight);
                Rect viewportRectTop    = new Rect(quarterWidth * 1, thirdHeight * 2, quarterWidth, thirdHeight);
                Rect viewportRectBottom = new Rect(quarterWidth * 1, thirdHeight * 0, quarterWidth, thirdHeight);

                base.Projection(destination,
                (viewportRectFront,  this.textureFront,  ProjectionManager.UvCoordsDefault, ProjectionManager.WarpingQuadDefault),
                (viewportRectLeft,   this.textureLeft,   ProjectionManager.UvCoordsDefault, ProjectionManager.WarpingQuadDefault),
                (viewportRectRight,  this.textureRight,  ProjectionManager.UvCoordsDefault, ProjectionManager.WarpingQuadDefault),
                (viewportRectBack,   this.textureBack,   ProjectionManager.UvCoordsDefault, ProjectionManager.WarpingQuadDefault),
                (viewportRectTop,    this.textureTop,    ProjectionManager.UvCoordsDefault, ProjectionManager.WarpingQuadDefault),
                (viewportRectBottom, this.textureBottom, ProjectionManager.UvCoordsDefault, ProjectionManager.WarpingQuadDefault));

                break;
            }

            case ProjectionMode.Front:  base.Projection(this.textureFront,  destination); break;
            case ProjectionMode.Left:   base.Projection(this.textureLeft,   destination); break;
            case ProjectionMode.Right:  base.Projection(this.textureRight,  destination); break;
            case ProjectionMode.Back:   base.Projection(this.textureBack,   destination); break;
            case ProjectionMode.Top:    base.Projection(this.textureTop,    destination); break;
            case ProjectionMode.Bottom: base.Projection(this.textureBottom, destination); break;
        }
    }

    #endregion Method
}