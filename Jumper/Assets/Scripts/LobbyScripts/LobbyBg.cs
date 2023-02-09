using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBg : MonoBehaviour
{    
    [SerializeField] private float speed;
    private float length, startPos;
    private SpriteRenderer sprite;
    void Start()
    {
        startPos = transform.position.x;
        sprite = GetComponent<SpriteRenderer>();
        length = sprite.bounds.size.x;
    }

    // Loop the backgroud and the tiles
    void Update()
    {
       // currentPos = transform.position;
       if (sprite.drawMode == SpriteDrawMode.Tiled)
        {
            length = sprite.size.x / 2;
            
        }

        if (startPos - length > transform.position.x)
        {
            transform.position = new Vector2 (transform.position.x + length, transform.position.y) ;
        }

        transform.Translate(speed * Time.deltaTime,0, 0);
    }
}
