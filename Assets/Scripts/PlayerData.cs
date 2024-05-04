using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int level;

    public PlayerData(int level)
    {
        this.level = level;
    }

    public override string ToString()
    {
        return base.ToString();

    }
}
