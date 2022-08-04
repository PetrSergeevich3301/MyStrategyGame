using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Buildings/BuildingType")]
public class BuildingType : ScriptableObject
{
    public GameObject buildingView;
    public string name;
    public Sprite icon;
    public float price;
}
