using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapInputManager : MonoBehaviour
{

    [SerializeField] public Tilemap baseTiles;
    [SerializeField] public GameObject cursor;

    // Update is called once per frame
    void Update()
    {
        UpdateCursorPosition();
    }

    void UpdateCursorPosition() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = baseTiles.WorldToCell(mouseWorldPos);
        Vector3 worldCoordinate = baseTiles.CellToWorld(coordinate);
        worldCoordinate.z = 0;
        Debug.Log("hovering tile " + coordinate.ToString() + " " + worldCoordinate.ToString());
        cursor.transform.position = worldCoordinate;
    }
}
