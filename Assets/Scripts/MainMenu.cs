using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToBlackjack()
    {
        // SceneManager.LoadScene(1);
        SceneManager.LoadScene("Blackjack");
        Debug.Log("ToBlackjack");
    }

    public void ToBaccarat()
    {
        SceneManager.LoadScene("Baccarat");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void To3CardPoker()
    {
        SceneManager.LoadScene("3CardPoker");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
}
