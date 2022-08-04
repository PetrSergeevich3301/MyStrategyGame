using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingsPanel : MonoBehaviour
{
    public GameObject buildingButton;
    [SerializeField] Transform parentObject;
    private List<BuildingType> buildings;

    private void Start()
    {
        buildings = Resources.LoadAll<BuildingType>("Buildings/").ToList();
        foreach (var building in buildings)
        {
            var button = Instantiate(buildingButton, parentObject);
            button.GetComponent<Presenter>().Present(building);
        }
    }
}
