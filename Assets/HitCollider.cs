using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public GameObject finishLine;
    public GameObject environment;
    public GameObject canvas;
    public TextMeshProUGUI endText;
    public TextMeshProUGUI playAgainText;
    public TextMeshProUGUI menuText;

    public Color loseColor;
    public Color winColor;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT COLLIDER");
        if (other.gameObject == finishLine)
            Win();
        else
            Lose();
    }

    private void Win()
    {
        Debug.Log("WIN");
        environment.SetActive(false);
        canvas.SetActive(true);
        endText.text = "You Won!!!";
        endText.color = winColor;
        playAgainText.color = winColor;
        menuText.color = winColor;
        Time.timeScale = 0f;
    }

    private void Lose()
    {
        Debug.Log("LOSE");
        environment.SetActive(false);
        canvas.SetActive(true);
        endText.text = "You Hit a Tree!!!";
        endText.color = loseColor;
        playAgainText.color = loseColor;
        menuText.color = loseColor;
        Time.timeScale = 0f;
    }
}
