using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Presenter : MonoBehaviour
{
    [SerializeField] private Text buildingName;
    [SerializeField] private Image icon;
    private GameObject prefab;
    private GameObject building;

    private Vector3 screenPosition;
    private Vector3 worldPosition;

    Plane plane = new Plane(Vector3.up, 0f);

    public void Present(BuildingType buildingType)
    {
        icon.sprite = buildingType.icon;
        buildingName.text = buildingType.name;
        prefab = buildingType.buildingView;
    }


    public void StartPlacing()
    {
        if(building != null)
        {
            Destroy(building);
        }
        building = Instantiate(prefab);
    }

    private void Update()
    {
        if(building != null)
        {
            screenPosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            if(plane.Raycast(ray, out float distance))
            {
                worldPosition = ray.GetPoint(distance);

                int x = Mathf.RoundToInt(worldPosition.x);
                int z = Mathf.RoundToInt(worldPosition.z);
                

                BoxCollider box = building.GetComponent<BoxCollider>();
                float height = box.size.y / 2;
                worldPosition = new Vector3(x, worldPosition.y + height,z);

                building.transform.position = worldPosition;

                if (Mouse.current.rightButton.wasPressedThisFrame)
                {
                    Vector3 rotate = new Vector3(0, building.transform.rotation.y + 90, 0);
                    if(rotate.y >= 360)
                    {
                        rotate.y -= 360;
                    }
                    building.transform.Rotate(rotate);
                }
                bool coll = building.GetComponent<Collision>().CheckCollision();
                if (Mouse.current.leftButton.wasPressedThisFrame && coll == false)
                {
                    building = null;
                }
            }
        }
    }
}
