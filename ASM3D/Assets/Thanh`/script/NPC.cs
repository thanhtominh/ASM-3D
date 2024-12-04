using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject NPCPanel;
    public TextMeshProUGUI NPCTextContent;
    public string[] content;

    public QuestItem questItem;

    Coroutine coroutine;
    private void Start()
    {
        NPCPanel.SetActive(false);
        NPCTextContent.text = "";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NPCPanel.SetActive(true);
            NPCTextContent.text = content[0];
            coroutine = StartCoroutine(ReadContent());
        }
    }
    IEnumerator ReadContent()
    {
        foreach (var line in content)
        {
            NPCTextContent.text = "";
            for (int i = 0; i < line.Length; i++)
            {
                NPCTextContent.text += line[i];
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void SkipContent()
    {
        StopCoroutine(coroutine);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NPCPanel.SetActive(false);
            StopCoroutine(coroutine);
        }
    }
}
