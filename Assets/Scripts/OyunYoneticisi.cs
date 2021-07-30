using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OyunYoneticisi : MonoBehaviour
{
    public GameObject AtesEtBtn;
    public GameObject dinamikSkorTxtObje;
    public GameObject startBtn;
    public GameObject playerGemi;
    public GameObject dusmanYaratici;
    public GameObject oyunBitti;
    public GameObject joystick;

    public enum OyunYoneticisiDurumu
    {
        Baslangic,
        OyunHali,
        OyunSonu,
    }
    OyunYoneticisiDurumu OyunDurumu;
    // Start is called before the first frame update
    void Start()
    {
        OyunDurumu = OyunYoneticisiDurumu.Baslangic;
        OyunDurumuGuncelle();
    }

    void OyunDurumuGuncelle()
    {
        switch (OyunDurumu)
        {
            case OyunYoneticisiDurumu.Baslangic:
                AtesEtBtn.SetActive(false);
                startBtn.SetActive(true);
                oyunBitti.SetActive(false);
                joystick.SetActive(false);
                break;
            case OyunYoneticisiDurumu.OyunHali:
                joystick.GetComponent<Joystick>().yon = Vector2.zero;
                joystick.GetComponent<Joystick>().joystickInside = joystick.GetComponent<Joystick>().transform.GetChild(0).GetComponent<Image>();
                joystick.GetComponent<Joystick>().joystickInside.rectTransform.anchoredPosition = Vector2.zero;
                joystick.SetActive(true);
                AtesEtBtn.SetActive(true);
                dinamikSkorTxtObje.GetComponent<oyunSkor>().Skor = 0;
                startBtn.SetActive(false);
                playerGemi.GetComponent<PlayerKontrol>().ilkDurum();
                dusmanYaratici.GetComponent<DusmanYaratici>().DusmanYaratmayiBaslat();
                break;
            case OyunYoneticisiDurumu.OyunSonu:
                joystick.SetActive(false);
                AtesEtBtn.SetActive(false);
                dusmanYaratici.GetComponent<DusmanYaratici>().DusmanYaratmayiDurdur();
                oyunBitti.SetActive(true);
                startBtn.SetActive(false);
                Invoke("MevcutDurumuDegistir",8f);
                break;
            default:
                break;
        }
    }
    public void OyundurumunuAyarla(OyunYoneticisiDurumu durum)
    {
        OyunDurumu = durum;
        OyunDurumuGuncelle();
    }
    public void OyunuBaslat()
    {
        OyunDurumu = OyunYoneticisiDurumu.OyunHali;
        OyunDurumuGuncelle();
    }
    public void MevcutDurumuDegistir()
    {
        OyundurumunuAyarla(OyunYoneticisiDurumu.Baslangic);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
