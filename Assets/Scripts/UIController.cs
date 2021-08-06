using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text applesText;
    public Text peopleText;
    public SnakeController snakeController;

    private void Update()
    {
        if (applesText != null && peopleText != null)
            DisplayText();
    }

    private void DisplayText()
    {
        applesText.text = $"Яблоки: {snakeController.EatenApples}";
        peopleText.text = $"Люди: {snakeController.EatenPeople}";
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
