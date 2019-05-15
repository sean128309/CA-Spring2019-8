using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button guard, terrorist, victim;
    // Start is called before the first frame update
    void Start()
    {
        guard.onClick.AddListener(loadguard);
        terrorist.onClick.AddListener(loadterrorist);
        victim.onClick.AddListener(loadvictim);
    }

    // Update is called once per frame
    void loadguard()
    {
        SceneManager.LoadScene("Guard");
    }
    void loadterrorist()
    {
        SceneManager.LoadScene("Killer");
    }
    void loadvictim()
    {
        SceneManager.LoadScene("Victim");
    }
}
