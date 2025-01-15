using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager instance { get; private set; }

    public List<Plant> plantPrefabList;

    private Plant currentPlant;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        FollowCursor();
    }

    void FollowCursor()
    {
        if (currentPlant == null) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        currentPlant.transform.position = mousePos;
    }

    public bool AddPlant(PlantType plantType)
    {
        if (currentPlant != null) return false;

        Plant plantPrefab = GetPlantPrefab(plantType);
        if (plantPrefab == null) 
        {
            print("要种植的植物不存在");
            return false;
        }
        currentPlant = GameObject.Instantiate(plantPrefab);
        return true;
    }

    private Plant GetPlantPrefab(PlantType plantType)
    {
        foreach (Plant plant in plantPrefabList)
        {
            if (plant.plantType == plantType)
            {
                return plant;
            }
        }
        return null;
    }

    public void OnCellClick(Cell cell)
    {
        if (currentPlant == null) return;
        if (!cell.AddPlant(currentPlant)) return;
        currentPlant = null;
    }
}
