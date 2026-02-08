using UnityEngine;
using UnityEngine.UIElements;

public class CheckPolicyCollision : MonoBehaviour
{
    //Canvas for using the Approve/Decline methods
    [SerializeField]
    private Canvas canvas;
    
    //Get the Approved zone in our UI
    private GameObject approved;

    //Additionally, we need the RectTransform of this zone.
    private RectTransform approvedZone;

    //Next, do the same for the Rejected Zone.
    private GameObject rejected;
    private RectTransform rejectedZone;

    //Additionally, we want a reference to our position on the screen.
    public RectTransform pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Upon starting, get the current position of our UI element.
        pos = GetComponent<RectTransform>();

        //Get the Approved element present in our scene and it's RectTransform.
        approved = GameObject.FindGameObjectWithTag("Approved");
        approvedZone = approved.GetComponent<RectTransform>();

        //Get the Rejected element and RectTransform.
        rejected = GameObject.FindGameObjectWithTag("Rejected");
        rejectedZone = rejected.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the mouse button has been released.
        if (Input.GetMouseButtonUp(0))
        {
            //Check if our own position and the Approved zone are colliding.
            if(ZoneCollision.IsOverlapping(pos, approvedZone))
            {
                //Debug.Log("Approved");
                //DraggableElement.pos.anchoredPosition = Vector3.zero;
                canvas.GetComponent<UIControl>().OnBtnApprove();
            }

            //Check if this UI element is overlapping with the Rejected zone.
            if(ZoneCollision.IsOverlapping(pos, rejectedZone))
            {
                //Debug.Log("Rejected");
                //DraggableElement.pos.anchoredPosition = Vector3.zero;
                canvas.GetComponent<UIControl>().OnBtnDecline();
            }
        }
    }
}
