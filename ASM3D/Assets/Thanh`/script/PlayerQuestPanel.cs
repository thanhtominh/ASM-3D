using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerQuestPanel : MonoBehaviour
{
    private bool isShown = false;
    private Vector3 initialPosition;
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHideQuestsPanel()
    {
        isShown = !isShown;
        if (isShown )
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(MovingPanel(true)); 
        }
        else
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(MovingPanel(false));
        }
    }

    IEnumerator MovingPanel(bool show)
    {
        while (true)
        {
            var currentX = transform.localPosition.x;
            var targetX = show ? initialPosition.x + -162 : initialPosition.x;
            var newX = Mathf.Lerp(currentX, targetX, Time.deltaTime * 2);
            transform.localPosition = new Vector3(newX, 0, 0);
            if (Mathf.Abs(newX - targetX) < 1)
            {
                break;
            }
            yield return null;
        }
    }
}