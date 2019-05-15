using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    public Button menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.onClick.AddListener(returnmenu);
        
    }

    // Update is called once per frame
    void returnmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
