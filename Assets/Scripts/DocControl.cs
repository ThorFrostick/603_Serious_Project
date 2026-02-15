using TMPro;
using UnityEngine;

public class DocControl : MonoBehaviour
{
    public TextMeshProUGUI docTextMesh;

    public GameData.DocumentData DocData;
    
    public void SetData(GameData.DocumentData docData)
    {
        DocData = docData;
        string docTxt = "";
        string doc = docData.DocText;
        GameData.Nation nation = docData.Nation;
        string reqNation = "";
        if (nation == GameData.Nation.OTHER)
        {
            reqNation = "Event!";
        }
        else
        {
            reqNation = $"Request From {nation}";
        }

        docTxt = $"{reqNation}\n{doc}";

        docTextMesh.text = docTxt;
    }
}
