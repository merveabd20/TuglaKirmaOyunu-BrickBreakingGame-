using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class birinciLevel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI skor_txt;
    public TMPro.TextMeshProUGUI can_txt;
    public TMPro.TextMeshProUGUI tugla_txt;

    public Rigidbody top_rigi;

    Vector3 baslangıc_koordinati;
    GameObject[] tuglalar;

    float hiz = 7.5f;
    int skor;
    int kirilan_tugla = 0;
    int toplam_tugla;
    int toplam_can = 3;

    void Start()
    {
        tuglalar = GameObject.FindGameObjectsWithTag("tugla");//ekrandaki tuğla sayısını bulduk.
        toplam_tugla = tuglalar.Length;//toplam tuğla sayısını değişkene atadık
        tugla_txt.text = kirilan_tugla.ToString() + " / " + toplam_tugla.ToString();
        baslangıc_koordinati = transform.position;
        baslangıc_vurusu();
    }

    void baslangıc_vurusu()
    {
        top_rigi.velocity = Vector3.zero;//ilk başta tüm gücü sıfırladık
        transform.position = baslangıc_koordinati;
        top_rigi.velocity = new Vector3(hiz, 0, hiz);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tugla")
        {
            Destroy(collision.gameObject);//kırılan tuğla ekrandan siliniyor
            skor += 10;
            kirilan_tugla++;
            skor_txt.text = "SKOR: " + skor;
            tugla_txt.text = kirilan_tugla + " / " + toplam_tugla;
            if (kirilan_tugla == toplam_tugla)
            {
                PlayerPrefs.SetInt("toplamSkor", skor);
                PlayerPrefs.SetInt("totalCan", toplam_can);
                SceneManager.LoadScene("Scenes/ikinciBolum");
            }
        }
        if (collision.gameObject.tag == "player")
        {
            int rastsayi = Random.Range(0, 100);
            //random bir sayı üretildi ve her oyun tahtasına çarptığında bir güç uygluandı ve farklı iki yönden birinden gitmesi sağlandı
            if (rastsayi >= 0 && rastsayi <= 50)
            {

                top_rigi.velocity = new Vector3(hiz, 0, top_rigi.velocity.z);
            }
            if (rastsayi >= 51 && rastsayi <= 100)
            {

                top_rigi.velocity = new Vector3(-hiz, 0, top_rigi.velocity.z);
            }


        }

        if (collision.gameObject.name == "sag_duvar")
        {
            top_rigi.velocity = new Vector3(-hiz, 0, top_rigi.velocity.z);
        }

        if (collision.gameObject.name == "sol_duvar")
        {
            top_rigi.velocity = new Vector3(hiz, 0, top_rigi.velocity.z);
        }

        if (collision.gameObject.name == "cikis")
        {
            toplam_can--;
            can_txt.text = toplam_can.ToString();
            if (toplam_can == 0)
            {
                PlayerPrefs.SetInt("totalCan", toplam_can);
                PlayerPrefs.SetInt("toplamSkor", skor);
                SceneManager.LoadScene("Scenes/FINISH");
            }

            baslangıc_vurusu();
        }
    }
}
