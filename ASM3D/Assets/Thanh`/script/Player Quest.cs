using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public List<QuestItem> questItems = new List<QuestItem>();

    public void TakeQuest(QuestItem questItem)
    {
        var check = questItems.FirstOrDefault(x => x.questItemName  == questItem.questItemName);
        if (check != null)
        {
            questItems.Add(questItem);
        }
    }
}
