using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SumManager : MonoBehaviour
{
    public static SumManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateSunPointText();
    }

    [SerializeField]
    private int sunPoint;

    public int SunPoint
    {
        get { return sunPoint; }
    }

    public void AddSunPoint(int point)
    {
        sunPoint += point;
        UpdateSunPointText();
    }

    public void SubSunPoint(int point)
    {
        sunPoint -= point;
        UpdateSunPointText();
    }

    public TextMeshProUGUI sunPointText;

    private void UpdateSunPointText()
    {
        sunPointText.text = SunPoint.ToString();
    }

}
