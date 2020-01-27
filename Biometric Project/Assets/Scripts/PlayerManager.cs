using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int m_key_count { get; private set; } = 0;
    public int m_key_total { get; private set; } = 5;

    public void AddKeyCount(int value)
    {
        m_key_count += value; 
    }
}
