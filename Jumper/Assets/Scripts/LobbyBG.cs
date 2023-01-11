using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBG : MonoBehaviour
{
    //private Vector2 currentPos, startPos;
    [SerializeField] private float speed;//, offset;
    private float length, currentPos, startPos;
    SpriteRenderer sprite;
    void Start()
    {
        startPos = transform.position.x;
        //sprite = GetComponentInChildren<SpriteRenderer>();
        sprite = GetComponent<SpriteRenderer>();
        length = sprite.bounds.size.x;
    }

    // Update is called once per frame
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
