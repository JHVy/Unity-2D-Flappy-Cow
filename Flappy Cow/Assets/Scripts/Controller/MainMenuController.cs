using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void _PlayButton()
    {
        //Application.LoadLevel("SampleScene");
        SceneManager.LoadScene("SampleScene");
    }
}
