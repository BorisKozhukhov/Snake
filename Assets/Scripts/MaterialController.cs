using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public static MaterialController S;

    public Material peopleMaterial1;
    public Material peopleMaterial2;
    public Material snakeMaterial;
    public Material checkpointMaterial;

    private List<Color> colors = new List<Color>();
    private SnakeController snakeController;
    private float timer = 0;

    private void Awake()
    {
        S = this;
        peopleMaterial1.color = Color.red;
        peopleMaterial2.color = Color.blue;
        snakeMaterial.color = Color.red;
        checkpointMaterial.color = Color.blue;
    }

    private void Start()
    {
        colors.Add(Color.white);
        colors.Add(Color.red);
        colors.Add(Color.blue);
        colors.Add(Color.cyan);
        colors.Add(Color.magenta);
        colors.Add(Color.yellow);
        colors.Add(Color.black);
        snakeController = GameObject.Find("Snake").GetComponent<SnakeController>();
    }

    private void Update()
    {
        ChangeSnakeColor();
    }

    public void ChangeColors(Color color)
    {
        peopleMaterial1.color = color;
        int index = Random.Range(0, colors.Count);
        if (colors[index] != peopleMaterial1.color)
        {
            peopleMaterial2.color = colors[index];
            StartCoroutine(ChangeCheckPointColor());
        }
        else
        {
            Color sameColor = colors[index];
            colors.RemoveAt(index);
            index = Random.Range(0, colors.Count);
            peopleMaterial2.color = colors[index];
            colors.Add(sameColor);
            StartCoroutine(ChangeCheckPointColor());
        }
    }

    private IEnumerator ChangeCheckPointColor()
    {
        yield return new WaitForSeconds(1f);
        int index = Random.Range(0, colors.Count);
        if (colors[index] != checkpointMaterial.color)
            checkpointMaterial.color = colors[index];
        else
        {
            Color color = colors[index];
            colors.RemoveAt(index);
            index = Random.Range(0, colors.Count);
            checkpointMaterial.color = colors[index];
            colors.Add(color);
        }
    }

    private void ChangeSnakeColor()
    {
        if (snakeController.FeverActive)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                int index = Random.Range(0, colors.Count);
                snakeMaterial.color = colors[index];
                timer = 0;
            }
        }
        else if (snakeMaterial.color != peopleMaterial1.color)
            snakeMaterial.color = peopleMaterial1.color;
    }
}
