using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonKontrol : MonoBehaviour
{
    public void basla()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Scenes/ilkBolum");
    }

    public void bitir()
    {
        Application.Quit();
    }

}
