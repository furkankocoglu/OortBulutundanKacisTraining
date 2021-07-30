using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMermi : MonoBehaviour
{
    float hiz;
    // Start is called before the first frame update
    void Start()
    {
        hiz = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 konum = transform.position;
        konum = new Vector2(konum.x,konum.y+hiz*Time.deltaTime);
        transform.position = konum;
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y>max.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D obje)
    {
        if (obje.tag=="DusmanGemi")
        {
            Destroy(gameObject);
        }
    }
}
