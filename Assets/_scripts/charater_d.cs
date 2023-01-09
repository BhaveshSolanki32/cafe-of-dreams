using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charater_d : MonoBehaviour
{
    public string _name;
    public bool seeded;
    public List<int> seed_type;
    public Sprite dp;

    [Header("METER")]
    [Range(0,1)] public float drink;
    [Range(0, 1)] public float seed;
    [Range(0, 1)] public float fear;
    [Range(0, 1)] public float sanity;

    public string age;
    public string occup;
    public void seed_enabler()
    {

    }
}
