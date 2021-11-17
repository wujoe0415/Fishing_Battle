using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static List<GameObject> playersuffer = new List<GameObject>();
    
    public static void addPlayerSkill(GameObject reference)
    {
        playersuffer.Add(reference);
    }
    public static void offsetPlayerSkill(GameObject offset)
    {
        UseCardSkill usecardskill = GameObject.Find("PlayerCardCollector").GetComponent<UseCardSkill>();
        playersuffer.Remove(offset);
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
}
