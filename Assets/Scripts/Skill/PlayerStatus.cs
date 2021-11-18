using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static List<GameObject> playersuffer = new List<GameObject>();
    
    public static void addPlayerSkill(GameObject reference)
    {
        playersuffer.Add(reference);
        foreach (GameObject status in playersuffer)
        {
            Debug.Log("playersuffer have :" + status.name);
        }
    }
    public static void offsetPlayerSkill(GameObject offset)
    {
        UseCardSkill usecardskill = GameObject.Find("PlayerCardCollector").GetComponent<UseCardSkill>();
        EnemyStatus.enemysuffer.Remove(offset);
        usecardskill.ResetSpecificFlag(offset.name);
        Destroy(offset);
        usecardskill.ReArrange();
    }
    public static void ClearAllPlayerStatus()
    {
        UseCardSkill usecardskill = GameObject.Find("PlayerCardCollector").GetComponent<UseCardSkill>();
        usecardskill.ResetAllFlags();
        
        foreach (GameObject skill in playersuffer)
            Destroy(GameObject.Find(skill.name + "(Clone)"));
        
        playersuffer.Clear();
        usecardskill.ReArrange();
    }
    public static void UnAvailSkill(GameObject avail)
    {
        UseCardSkill usecardskill = GameObject.Find("PlayerCardCollector").GetComponent<UseCardSkill>();
        usecardskill.LetSkillBeUnAvaliable(avail.name);
        usecardskill.ReArrange();
    }
    public static bool Checkexist(string name)
    {
        foreach (GameObject a in playersuffer)
        {
            if (a.name == name)
            {
                playersuffer.Remove(a);
                return true;
            }
        }
        return false;
    }
}
