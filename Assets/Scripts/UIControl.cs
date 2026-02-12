using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public RectTransform  docBehind;
    public RectTransform  docFront;
    public Transform table;
    public List<CharacterControl> cc;
    public Transform line;
    public GameObject characterObj;

    private RectTransform _doc;
    private RectTransform _docB;
    private int _docIndex = 0;

    private void Start()
    {
        _doc = docFront;
        _docB = docBehind;
    }

    private RectTransform Swap()
    {
        var d = Instantiate(_doc, table);
        d.anchoredPosition = new Vector2(0, 0); 
        d.SetAsFirstSibling();
        d.gameObject.name = $"Document_{_docIndex.ToString()}";
        var obDoc = _doc;
        _doc = _docB;
        _docB = d;
        _docIndex++;
        return obDoc;
    }
    
    private void MoveOutTop(RectTransform ui, float duration, bool isApprove)
    {
        float screenHeight = Screen.height;

        ui.DOAnchorPosY(isApprove ? screenHeight + ui.rect.height : -screenHeight - ui.rect.height, duration)
            .SetEase(Ease.InOutCubic).OnComplete(() =>
            {
                Destroy(ui.gameObject);
            });
    }

    public void OnBtnApprove()
    {
        RectTransform d = Swap();
        MoveOutTop(d, 1f, true);
        foreach (var c in cc)
        {
            c.MoveForward();
        }
        cc.RemoveAt(0);
        var newChar = Instantiate(characterObj, line);
        var newRect = newChar.GetComponent<RectTransform>();
        newRect.anchoredPosition = new Vector2(-1500, 0);
        var newCC = newChar.GetComponent<CharacterControl>();
        newCC.SetData();
        cc.Add(newCC);
    }

    public void OnBtnDecline()
    {
        RectTransform d = Swap();
        MoveOutTop(d, 1f, false);
        foreach (var c in cc)
        {
            c.MoveForward();
        }
        cc.RemoveAt(0);
        var newChar = Instantiate(characterObj, line);
        var newRect = newChar.GetComponent<RectTransform>();
        newRect.anchoredPosition = new Vector2(-1500, 0);
        var newCC = newChar.GetComponent<CharacterControl>();
        newCC.SetData();
        cc.Add(newCC);
    }

    public void OnTitleClick() 
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
