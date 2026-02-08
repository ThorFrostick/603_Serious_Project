using UnityEngine;

public class ZoneCollision : MonoBehaviour
{
    /// <summary>
    /// Check if two UI elements are overlapping.
    /// </summary>
    /// <param name="dragger">The item we are able to drag on the UI.</param>
    /// <param name="target">The target zone we are moving "dragger" onto.</param>
    /// <returns>True if these two are overlapping, False otherwise.</returns>
    public static bool IsOverlapping(RectTransform dragger, RectTransform target)
    {
        //First, check that both of our parameters exist in the scene.
        if(dragger == null || target == null)
        {
            return false;
        }

        //We want to get the 4 corners of both our RectTransform parameters.
        Vector3[] draggerCorners = new Vector3[4];
        Vector3[] targetCorners = new Vector3[4];

        //Convert the UI positions into Global positions so we can properly compare values.
        dragger.GetWorldCorners(draggerCorners);
        target.GetWorldCorners(targetCorners);

        //Calculate the width and height of two 2D rectangles based on our Dragger and Target.
        Rect draggerRect = new Rect(draggerCorners[0], draggerCorners[2] - draggerCorners[0]);
        Rect targetRect = new Rect(targetCorners[0], targetCorners[2] - targetCorners[0]);

        //Finally, check if the two 2D rectangles are overlapping.
        return draggerRect.Overlaps(targetRect);
    }
}
