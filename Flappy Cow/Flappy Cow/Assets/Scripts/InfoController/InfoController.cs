using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoController : MonoBehaviour
{
    public void _BackButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
