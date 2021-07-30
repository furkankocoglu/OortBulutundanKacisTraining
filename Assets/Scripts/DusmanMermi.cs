using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanMermi : MonoBehaviour
{
    float hiz;
    Vector2 yon;
    bool ateseHazir;
     void Awake()
    {
        hiz = 5f;
        ateseHazir = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void YonAyarla(Vector2 yonp)
    {
        yon = yonp.normalized;
        ateseHazir = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (ateseHazir)
        {
            Vector2 konum = transform.position;
            konum += yon * hiz * Time.deltaTime;
            transform.position = konum;
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            if ((transform.position.x < min.x)||(transform.position.x>max.x)||(transform.position.y<min.y)||(transform.position.y>max.y))
            {
                Destroy(gameObject);
            }
        }        
    }
    void OnTriggerEnter2D(Collider2D obje)
    {
        if (obje.tag=="PlayerGemi")
        {
            Destroy(gameObject);
        }
    }
}
