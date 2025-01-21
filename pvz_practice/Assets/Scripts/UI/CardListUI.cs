using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardListUI : MonoBehaviour
{
    public List<Card> cardList;

    private void Start()
    {
        DisableCardList();
        ShowCardList();
    }

    public void ShowCardList()
    {
        GetComponent<RectTransform>().DOAnchorPosY(465, 1f);
    }

    void DisableCardList()
    {
        foreach (var card in cardList)
        {
            card.DisableCard();
        }
    }

    void EnableCardList()
    {
        foreach (var card in cardList)
        {
            card.EnableCard();
        }
    }
}
