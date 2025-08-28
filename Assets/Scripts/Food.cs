using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }


    void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x =Random.Range(bounds.min.x,bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        x=Mathf.Round(x);
        y=Mathf.Round(y);

        this.transform.position=new Vector3(x,y,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snake"))
        {
            RandomizePosition();
        }
    }
}
