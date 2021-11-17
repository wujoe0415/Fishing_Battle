using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FaceWhere
{
    public static bool isFaceRight(GameObject target)
    {
        string name = target.name;
        if (target.GetComponent<SpriteRenderer>().flipX)
        {
            if (name == "RedLeaf" || name == "Fish" || name == "Teacher" ||  name == "NormalDoggie")
                return true;
            else
                return false;
        }
        else
        {
            if (name == "RedLeaf" || name == "Fish" || name == "Teacher" || name == "NormalDoggie")
                return false;
            else
                return true;
        }
    }
}
