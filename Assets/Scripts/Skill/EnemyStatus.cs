using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public static List<GameObject> enemysuffer = new List<GameObject>();

    public static void addEnemySkill(GameObject reference)
    {
        enemysuffer.Add(reference);
    }
    public static void offsetEnemySkill(GameObject offset)
    {
        UseCardSkill usecardskill = GameObject.Find("EnemyCardCollector").GetComponent<UseCardSkill>();
        enemysuffer.Remove(offset);
        usecardskill.ResetSpecificFlag(offset.name);
        Destroy(offset);
        usecardskill.ReArrange();
    }
    public static void ClearAllEnemyStatus()
    {
        UseCardSkill usecardskill = GameObject.Find("EnemyCardCollector").GetComponent<UseCardSkill>();
        usecardskill.ResetAllFlags();
        
        foreach (GameObject skill in enemysuffer)
            Destroy(GameObject.Find(skill.name + "(Clone)"));
        
        enemysuffer.Clear();
        usecardskill.ReArrange();

    }
}
