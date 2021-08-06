using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    private MaterialController materialController;
    private SnakeController snakeController;

    private void Start()
    {
        materialController = MaterialController.S;
        snakeController = GetComponentInParent<SnakeController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("People"))
        {
            CollisionWithPeople(other.gameObject);
        }
        if (other.gameObject.CompareTag("Apple"))
        {
            CollisionWithApple(other.gameObject);
        }
        if (other.gameObject.CompareTag("Hurdle"))
            CollisionWithHurdle(other.gameObject);
        if (other.gameObject.CompareTag("Сheckpoint"))
        {
            CollisionWithCheckpoint();
        }
        if (other.gameObject.CompareTag("EndGame"))
        {
            CollisionWithEndGame();
        }
    }

    private void CollisionWithPeople(GameObject peopleGO)
    {
        if (!snakeController.FeverActive)
        {
            if (materialController.snakeMaterial.color == peopleGO.GetComponentInChildren<MeshRenderer>().material.color)
            {
                snakeController.AddPeople();
                Destroy(peopleGO);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            snakeController.AddPeople();
            Destroy(peopleGO);
        }
    }

    private void CollisionWithApple(GameObject appleGO)
    {
        snakeController.AddApple();
        Destroy(appleGO);
    }

    private void CollisionWithHurdle(GameObject hurdleGO)
    {
        if (!snakeController.FeverActive)
            SceneManager.LoadScene(1);
        else
            Destroy(hurdleGO);
    }

    private void CollisionWithCheckpoint()
    {
        materialController.ChangeColors(materialController.checkpointMaterial.color);
    }

    private void CollisionWithEndGame()
    {
        SceneManager.LoadScene(2);
    }
}
