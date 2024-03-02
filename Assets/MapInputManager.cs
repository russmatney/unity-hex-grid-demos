using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapInputManager : MonoBehaviour
{

    [SerializeField] public Tilemap baseTiles;
    [SerializeField] public Tilemap fogOfWar;
    [SerializeField] public GameObject cursor;

    public int vision = 1;

    // Update is called once per frame
    void Update()
    {
        UpdateCursorPosition();
        if (Input.GetMouseButtonDown(0)) {
            UpdateFogOfWar();
        }
    }

    void UpdateCursorPosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = baseTiles.WorldToCell(mouseWorldPos);
        Vector3 worldCoordinate = baseTiles.CellToWorld(coordinate);
        worldCoordinate.z = 0;
        cursor.transform.position = worldCoordinate;
    }

    void UpdateFogOfWar()
    {
        Vector3Int cursorTileCoord = fogOfWar.WorldToCell(cursor.transform.position);

        for (int x = -vision; x <= vision; x++)
        {
            for (int y = -vision; y <= vision; y++)
            {
                Vector3Int coord = cursorTileCoord + new Vector3Int(x, y, 0);
                // clear tiles!
                fogOfWar.SetTile(coord, null);
                Debug.Log("cleared tile " + coord.ToString());
            }
        }

    }
}
