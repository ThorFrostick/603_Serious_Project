using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Random = System.Random;

public class CharacterControl : MonoBehaviour
{
    public int index = 3;
    public List<Sprite> characterImgs;
    public Image characterSprite;

    private Random _random;
    private void Start()
    {
        // index = 2;
    }

    public void SetData()
    {
        _random = new Random();
        var i = _random.Next(0, characterImgs.Count);
        Sprite sprite = characterImgs[i];
        characterSprite.sprite = sprite;
    }
    
    public void MoveForward()
    {
        float screenHeight = Screen.height;
        float screenWidth = Screen.height;
        var rect = gameObject.GetComponent<RectTransform>();
        if (index <= 0)
        {
            // GO AWAY
            rect.DOAnchorPosY(screenHeight + rect.rect.height, 0.5f)
                .SetEase(Ease.InOutCubic).OnComplete(() =>
                {
                    Destroy(gameObject);
                });
        }
        else
        {
            Debug.Log(screenWidth);
            rect.DOAnchorPosX(screenWidth / 3, 0.5f).SetRelative();
            index--;
        }
    }
}
