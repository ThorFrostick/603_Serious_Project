using UnityEngine;
using UnityEngine.UIElements;

public class CheckPolicyCollision : MonoBehaviour
{
    //Get the Approved zone in our UI
    private GameObject approved;

    //Additionally, we need the RectTransform of this zone.
    private RectTransform approvedZone;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the Approved element present in our scene.
        approved = GameObject.FindGameObjectWithTag("Approved");

        approvedZone = approved.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the mouse button has been released.
        if (Input.GetMouseButtonUp(0))
        {
            //Check if our own position and the Approved zone are colliding.
            if(ZoneCollision.IsOverlapping(DraggableElement.pos, approvedZone))
            {
                Debug.Log("Approved");
                DraggableElement.pos.anchoredPosition = Vector3.zero;
            }
        }
    }
}
