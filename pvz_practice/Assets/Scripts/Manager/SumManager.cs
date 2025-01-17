using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SumManager : MonoBehaviour
{
    public static SumManager instance { get; private set; }

    [SerializeField]
    private int sunPoint;

    public TextMeshProUGUI sunPointText;
    private Vector3 sunPointTextPosition;

    public float produceTime = 5;
    private float produceTimer;
    public GameObject sunPrefab;
    private bool isStartProducing = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateSunPointText();
        StartProducing();
    }

    private void Update()
    {
        if (isStartProducing)
        {
            ProduceSun();
        }
    }

    public void StartProducing()
    {
        isStartProducing = true;
    }

    void ProduceSun()
    {
        produceTimer += Time.deltaTime;

        if (produceTimer >= produceTime)
        {
            produceTimer = 0;
            Vector3 position = new Vector3(Random.Range(-4, 6.5f), 6.2f, -1);
            GameObject sun = Instantiate(sunPrefab, position, Quaternion.identity);
            position.y = Random.Range(-4, 3);
            sun.GetComponent<Sun>().LinearMoveTo(position);
        }
    }

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

    private void UpdateSunPointText()
    {
        sunPointText.text = SunPoint.ToString();
    }

    public Vector3 GetSunPointTextPosition()
    {
        CalculateSunPointTextPosition();
        return sunPointTextPosition;
    }

    private void CalculateSunPointTextPosition()
    {
        sunPointTextPosition = Camera.main.ScreenToWorldPoint(sunPointText.transform.position);
        sunPointTextPosition.z = 0;
    }

}
