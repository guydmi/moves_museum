using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartBtn()
    {
        SceneManager.LoadScene("MuseumScene");
    }
}
