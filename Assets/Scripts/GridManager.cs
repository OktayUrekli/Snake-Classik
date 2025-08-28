using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] GameObject gridTilePrefab;

    public int xDim;
    public int yDim;


    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int x = 0; x < xDim; x++)
        {
            for (int y = 0; y < yDim; y++)
            {
                GameObject gridTile = (GameObject)Instantiate(gridTilePrefab, GetWordPosition(x, y), Quaternion.identity);
                gridTile.gameObject.name="("+x+","+y+")";
                gridTile.transform.parent = transform;
            }
        }
    }


    Vector3 GetWordPosition(int x, int y)
    {
        float newX = Mathf.Round(-xDim / 2f + x) ;
        float newY = Mathf.Round(-yDim / 2f + y) ;

        return new Vector3(newX, newY, 0);
    }
    
}
