using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 _direction = Vector2.right;

    List<Transform> snakeBodies;

    public Transform bodyPrefab;

    GameCanvasManager canvasManager;

    private void Awake()
    {
        canvasManager = FindAnyObjectByType<GameCanvasManager>();
    }

    private void Start()
    {


        snakeBodies = new List<Transform>();
        snakeBodies.Add(this.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = snakeBodies.Count-1; i > 0; i--)
        {
            snakeBodies[i].position = snakeBodies[i - 1].position;
        }

        transform.position =new Vector3(Mathf.Round( transform.position.x )+ _direction.x, Mathf.Round(transform.position.y) + _direction.y,0);
    }

    void Grow()
    {
        Transform bodyPart=Instantiate(bodyPrefab);
        bodyPart.position=snakeBodies[snakeBodies.Count-1].position;
        snakeBodies.Add(bodyPart);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            Grow();
            canvasManager.UpdateScore(13);
        }
        else if (collision.CompareTag("Wall") || collision.CompareTag("Body"))
        {
            canvasManager.GameOver();
        }
    }
}
