using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum CardState
{
    Cooling, // 冷却
    WaitingSun, // 等待阳光
    Ready // 可用
}

public enum PlantType
{
    SunFlower,
    PeaShooter
}

public class Card : MonoBehaviour
{
    // 冷却 等待阳光 可用
    private CardState cardState = CardState.Cooling;
    public PlantType plantType = PlantType.SunFlower;

    public GameObject cardLight; // 可用
    public GameObject cardGray; // 等待阳光
    public Image cardMask; // 冷却

    [SerializeField]
    private float cdTime = 2;
    private float cdTimer = 0;

    [SerializeField]
    private int needSunPoint = 50;

    private void Update()
    {
        switch (cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
            default:
                break;
        }
    }

    void CoolingUpdate()
    {
        cdTimer += Time.deltaTime;
        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;
        if (cdTimer >= cdTime)
        {
            cardState = CardState.WaitingSun;
        }
    }

    void WaitingSunUpdate()
    {
        if (SumManager.instance.SunPoint >= needSunPoint)
        {
            TransitionToReady();
        }
    }

    void ReadyUpdate()
    {
        if (SumManager.instance.SunPoint < needSunPoint)
        {
            TransitionToWaitingSun();
        }
    }

    void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;

        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(false);
    }

    void TransitionToReady()
    {
        cardState = CardState.Ready;

        cardLight.SetActive(true);
        cardGray.SetActive(false);
        cardMask.gameObject.SetActive(false);
    }

    void TransitionToCooling()
    {
        cardState = CardState.Cooling;

        cdTimer = 0;
        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(true);
    }

    public void OnClick()
    {
        if (SumManager.instance.SunPoint < needSunPoint) return;

        if (!HandManager.instance.AddPlant(plantType)) return;

        SumManager.instance.SubSunPoint(needSunPoint);
        TransitionToCooling();
    }
}
