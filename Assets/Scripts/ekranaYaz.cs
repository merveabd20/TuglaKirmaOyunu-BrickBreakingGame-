using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ekranaYaz : MonoBehaviour
{
    public TMPro.TextMeshProUGUI yaz_txt;
    public TMPro.TextMeshProUGUI baslık_txt;
    public TMPro.TextMeshProUGUI skor_txt;

    int skor;
    int toplam_can;
    void Awake()
    {
        skor = PlayerPrefs.GetInt("toplamSkor");
        toplam_can = PlayerPrefs.GetInt("totalCan");
        skor_txt.text = "Toplam Skor: " + skor;
        if (toplam_can == 0)
        {
            baslık_txt.text = "Haklarınız Bitti :(";
            yaz_txt.text = "Canlarınız Bitti. Yeniden Başlamak İster Misiniz?";
        }
        else
        {
            baslık_txt.text = "Tebrikler :)";
            yaz_txt.text = "Oyunu Bitirdiniz. Yeniden Oynamak İster Misiniz?";

        }
    }
}
