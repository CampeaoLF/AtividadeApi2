using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchScene : MonoBehaviour
{
    public GameObject menu; 
    private bool isShowing;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
    }
    void PausarJogo()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
           menu.SetActive(true);
        }
    }


}
