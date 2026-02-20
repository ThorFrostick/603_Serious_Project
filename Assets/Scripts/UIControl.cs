using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Random = System.Random;


public class UIControl : MonoBehaviour
{
    public RectTransform  docBehind;
    public RectTransform  docFront;
    public Transform table;
    public List<CharacterControl> cc;
    public Transform line;
    public GameObject characterObj;

    public Image OilAImg;
    public Image LandAImg;
    public Image MoneyAImg;
    
    public Image OilBImg;
    public Image LandBImg;
    public Image MoneyBImg;

    public Image HPFrame;

    private List<Image> resourceGauges = new List<Image>();

    public List<GameData.DocumentData> DocPresets;

    private RectTransform _doc;
    private RectTransform _docB;
    private int _docIndex = 0;
    private Random _random = new Random();

    #region NationData

    private float _Oil_A = 80;
    private float _Land_A = 30;
    private float _Money_A = 50;
    
    private float _Oil_B = 30;
    private float _Land_B = 80;
    private float _Money_B = 20;

    #endregion

    private GameData.Nation _curNation;
    private int _peaceDay = 0;
    private int _Approves = 0;
    private int _Declines = 0;

    private void Start()
    {
        StaticGameData.peaceDays = 0;
        
        _doc = docFront;
        _docB = docBehind;

        SetDocData(_doc);
        SetDocData(_docB, _curNation);

        resourceGauges.Add(OilAImg);
        resourceGauges.Add(LandAImg);
        resourceGauges.Add(MoneyAImg);
        resourceGauges.Add(OilBImg);
        resourceGauges.Add(LandBImg);
        resourceGauges.Add(MoneyBImg);

        UpdateResourceUI();
    }

    private void Update()
    {
        HPFrame.color = new Color(HPFrame.color.r, HPFrame.color.g, HPFrame.color.b, Mathf.Sin(Time.time * 3) / 2.0f + 0.5f);
    }

    private void UpdateResourceUI()
    {
        OilAImg.fillAmount = _Oil_A / 100f;
        LandAImg.fillAmount = _Land_A / 100f;
        MoneyAImg.fillAmount = _Money_A / 100f;
        
        OilBImg.fillAmount = _Oil_B / 100f;
        LandBImg.fillAmount = _Land_B / 100f;
        MoneyBImg.fillAmount = _Money_B / 100f;

        foreach (Image resource in resourceGauges)
        {
            if (resource.fillAmount <= 0f)
            {
                StaticGameData.peaceDays = _peaceDay;
                StaticGameData.Approves = _Approves;
                StaticGameData.Declines = _Declines;
                StaticGameData.CollectData();
                SceneManager.LoadScene("GameOverScreen");
            }

            HPFrame.gameObject.SetActive(resource.fillAmount <= 0.1f);
        }
    }

    private void SetDocData(RectTransform rt)
    {
        int index = _random.Next(DocPresets.Count);
        DocControl dc = rt.GetComponent<DocControl>();
        dc.SetData(DocPresets[index]);
        _curNation = DocPresets[index].Nation;
    }
    
    private void SetDocData(RectTransform rt, GameData.Nation nation)
    {
        List<GameData.DocumentData> tempList = new List<GameData.DocumentData>();
        foreach (var dd in DocPresets)
        {
            if (dd.Nation != nation)
            {
                tempList.Add(dd);
            }
        }
        
        int index = _random.Next(tempList.Count);
        DocControl dc = rt.GetComponent<DocControl>();
        dc.SetData(tempList[index]);
        _curNation = tempList[index].Nation;
    }

    private RectTransform Swap(bool isApprove)
    {
        var dc = _doc.GetComponent<DocControl>();
        GameData.DocumentData docData = dc.DocData;
        UpdateResources(docData, isApprove);
        
        var d = Instantiate(_doc, table);
        d.anchoredPosition = new Vector2(0, -347); 
        d.SetAsFirstSibling();
        d.gameObject.name = $"Document_{_docIndex.ToString()}";
        SetDocData(d, _curNation);
        
        var obDoc = _doc;
        _doc = _docB;
        _docB = d;
        _docIndex++;
        return obDoc;
    }

    void UpdateResources(GameData.DocumentData docData, bool isApprove)
    {
        GameData.DecisionEffect ApproveEffectA = docData.ApproveEffectA;
        GameData.DecisionEffect DeclineEffectA = docData.DeclineEffectA;
        GameData.DecisionEffect ApproveEffectB = docData.ApproveEffectB;
        GameData.DecisionEffect DeclineEffectB = docData.DeclineEffectB;

        if (isApprove)
        {
            _Oil_A += ApproveEffectA.Oil;
            _Land_A += ApproveEffectA.Land;
            _Money_A += ApproveEffectA.Money;
            
            _Oil_B += ApproveEffectB.Oil;
            _Land_B += ApproveEffectB.Land;
            _Money_B += ApproveEffectB.Money;
        }
        else
        {
            _Oil_A += DeclineEffectA.Oil;
            _Land_A += DeclineEffectA.Land;
            _Money_A += DeclineEffectA.Money;
            
            _Oil_B += DeclineEffectB.Oil;
            _Land_B += DeclineEffectB.Land;
            _Money_B += DeclineEffectB.Money;
        }

        UpdateResourceUI();
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
        RectTransform d = Swap(true);
        MoveOutTop(d, 1f, true);
        foreach (var c in cc)
        {
            c.MoveForward();
        }
        cc.RemoveAt(0);
        var newChar = Instantiate(characterObj, line);
        var newRect = newChar.GetComponent<RectTransform>();
        newRect.anchoredPosition = new Vector2(-1500, -110);
        var newCC = newChar.GetComponent<CharacterControl>();
        newCC.SetData();
        cc.Add(newCC);
        _peaceDay++;
        _Approves++;
    }

    public void OnBtnDecline()
    {
        RectTransform d = Swap(false);
        MoveOutTop(d, 1f, false);
        foreach (var c in cc)
        {
            c.MoveForward();
        }
        cc.RemoveAt(0);
        var newChar = Instantiate(characterObj, line);
        var newRect = newChar.GetComponent<RectTransform>();
        newRect.anchoredPosition = new Vector2(-1500, -110);
        var newCC = newChar.GetComponent<CharacterControl>();
        newCC.SetData();
        cc.Add(newCC);
        _peaceDay++;
        _Declines++;
    }

    public void OnTitleClick() 
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
