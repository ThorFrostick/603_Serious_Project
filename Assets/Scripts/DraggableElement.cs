using UnityEngine;
using UnityEngine.EventSystems;

//To create a draggable UI element, we first add the EventSystems namespace, then the necessary Interface .
public class DraggableElement : MonoBehaviour, IDragHandler
{
    //Get the canvas in our scene
    [SerializeField]
    private Canvas canvas;

    //Additionally, we want a reference to our position on the screen.
    public static RectTransform pos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Upon starting, get the current position of our UI element.
        pos = GetComponent<RectTransform>();
    }

    /// <summary>
    /// This method will control dragging this element using the mouse.
    /// This only works when the mouse clicks and holds on the UI element.
    /// </summary>
    /// <param name="eventData">The change in the mouse position</param>
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //Add the change in mouse position, scaled by the size of our screen, to the position of our UI element.
        pos.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
