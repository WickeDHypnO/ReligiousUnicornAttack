using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Slider bossHealth;
    public GameObject lifeBar;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public GameObject gameLoseUI;
    public GameObject startGameUI;

    //Show main game UI like boss healthbar and player lives
    public void ShowGameUI()
    {
        lifeBar.SetActive(true);
        bossHealth.gameObject.SetActive(true);
    }

    //Show game over screen, bool decides if the game is won or not
    public void ShowGameOverUI(bool won)
    {
        gameOverUI.SetActive(true);
        if(won)
        {
            gameWinUI.SetActive(true);
        }
        else
        {
            gameLoseUI.SetActive(true);
        }
    }

    //Update boss healthbar
    public void SetBossHealthUI(float value)
    {
        bossHealth.value = value;
    }

    //Hide starting button
    public void HideGameStartUI()
    {
        startGameUI.SetActive(false);
    }
}
