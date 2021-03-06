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
        PlayerStatus.playersuffer.Remove(offset);
        usecardskill.ResetSpecificFlag(offset.name);
        offset.transform.parent = null;
        Destroy(offset);
        usecardskill.ReArrange();
    }
    public static void ClearAllEnemyStatus()
    {
        UseCardSkill usecardskill = GameObject.Find("PlayerCardCollector").GetComponent<UseCardSkill>();
        usecardskill.ResetAllFlags();
        foreach (GameObject skill in enemysuffer)
        {
            Destroy(GameObject.Find(skill.name));
        }
        enemysuffer.Clear();
        usecardskill.ReArrange();
    }
    
    //public static void UnAvailSkill(GameObject avail)
    //{
    //    UseCardSkill usecardskill = GameObject.Find("EnemyCardCollector").GetComponent<UseCardSkill>();
    //    usecardskill.LetSkillBeUnAvaliable(avail.name);
    //    usecardskill.ReArrange();
    //}
    public static bool Checkexist(string name)
    {
        foreach(GameObject a in enemysuffer)
        {
            if (a.name == name)
            {
                enemysuffer.Remove(a);
                return true;
            }
        }
        return false;
    }
}
