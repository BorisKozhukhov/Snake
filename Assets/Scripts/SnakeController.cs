using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public List<GameObject> bodiesParts;
    
    private int _eatenApples = 0;
    private int _eatenPeople = 0;
    private bool activatePart = false;
    private bool _feverActive = false;
    private float timer = 0;

    public int EatenApples
    {
        get => _eatenApples;
    }

    public bool FeverActive
    {
        get => _feverActive;
    }

    public int EatenPeople
    {
        get => _eatenPeople;
    }

    private void Update()
    {
        if (activatePart && bodiesParts.Count > 0)
            ActivatePartOfTail();
        if (_eatenApples >= 3)
            ActivateFever();
    }

    private void ActivatePartOfTail()
    {
        bodiesParts[0].gameObject.SetActive(true);
        bodiesParts.RemoveAt(0);
        activatePart = false;
    }

    public void AddPeople()
    {
        _eatenPeople++;
        if (_eatenPeople % 5 == 0)
            activatePart = true;
    }

    public void AddApple()
    {
        _eatenApples++;
    }

    private void ActivateFever()
    {
        _feverActive = true;
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            _eatenApples = 0;
            _feverActive = false;
            timer = 0;
        }
    }
}
