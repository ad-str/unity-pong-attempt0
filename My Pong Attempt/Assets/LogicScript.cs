using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{

    public GameObject winScreen;
    public GameObject loseScreen;

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void win() {
        winScreen.SetActive(true);
    }
    public void lose() {
        loseScreen.SetActive(true);
    }
}
