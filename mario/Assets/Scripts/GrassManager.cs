using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour
{
    [SerializeField] private GameObject grassPrefab;
    [SerializeField] private GameObject area;
    [SerializeField] private int quantity;

    private Collider areaCollider;
    private float offset = 0.8f;

    void Start()
    {
        areaCollider = area.GetComponent<Collider>();
        DistributeGrass();

        Debug.Log($"The extend is {AreaBorder()}");
    }

    private Vector2 AreaBorder()
    {
        float areaExtentX = areaCollider.bounds.extents.x;
        float areaExtentZ = areaCollider.bounds.extents.z;
        Vector2 areaExtent = new Vector2(areaExtentX, areaExtentZ);

        return areaExtent * offset;
    }

    private Vector3 RandomPos()
    {
        float areaMaxX = AreaBorder().x;
        float areaMaxZ = AreaBorder().y;

        float xPos = Random.Range(-areaMaxX, areaMaxX);
        float zPos = Random.Range(-areaMaxZ, areaMaxZ);
        
        Vector3 pos = new Vector3(xPos, 0, zPos);
        return pos;
    }

    private void DistributeGrass()
    {
        for (int i=0; i<quantity; i++)
        {
            Instantiate(grassPrefab, RandomPos(), Quaternion.identity);
        }
    }
}
