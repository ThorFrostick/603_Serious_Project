using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    //Get the two nations and their resources.
    private NationalResources nationA;
    private NationalResources nationB;

    private void Start()
    {
        //Get the two nations using the tags in Unity Inspector.
        nationA = GameObject.FindGameObjectWithTag("Nation_A").GetComponent<NationalResources>();
        nationB = GameObject.FindGameObjectWithTag("Nation_B").GetComponent<NationalResources>();
    }

    // Update is called once per frame
    void Update()
    {
        //If any of the two nations' resources drop to 0 or below, give the player a Game Over.
        if (nationA.Oil <= 0 || nationA.Land <= 0 || nationA.Currency <= 0 ||
            nationB.Oil <= 0 || nationB.Land <= 0 || nationB.Currency <= 0)
        {
            SceneManager.LoadScene("GameOver_Test");
        }
    }
}
