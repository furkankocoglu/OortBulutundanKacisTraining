using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanYaratici : MonoBehaviour
{
    public GameObject dusmanObje;
    float dusmanOlusmaSuresi = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DusmanYarat()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject dusman = (GameObject)Instantiate(dusmanObje);
        dusman.transform.position = new Vector2(Random.Range(min.x,max.x),max.y);
        SonrakiDusmanOlusturmaSuresi();
    }
    void SonrakiDusmanOlusturmaSuresi()
    {
        float olusturmaSuresi;
        if (dusmanOlusmaSuresi>1f)
        {
            olusturmaSuresi = Random.Range(1f,dusmanOlusmaSuresi);
        }
        else
        {
            olusturmaSuresi = 1f;
        }
        Invoke("DusmanYarat",olusturmaSuresi);
    }
    void DusmanSayisindaArtis()
    {
        if (dusmanOlusmaSuresi>1f)
        {
            dusmanOlusmaSuresi--;
        }
        if (dusmanOlusmaSuresi==1f)
        {
            CancelInvoke("DusmanSayisindaArtis");
        }
    }
    public void DusmanYaratmayiBaslat()
    {
        dusmanOlusmaSuresi = 5f;
        Invoke("DusmanYarat",dusmanOlusmaSuresi);
        InvokeRepeating("DusmanSayisindaArtis",0f,30f);
    }
    public void DusmanYaratmayiDurdur()
    {
        CancelInvoke("DusmanYarat");
        CancelInvoke("DusmanSayisindaArtis");
    }
}
