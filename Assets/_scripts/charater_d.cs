using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charater_d : MonoBehaviour
{
    public string _name;
    public bool seeded;
    public List<int> seed_type;
    public Sprite dp;
    int seed_score = 0;

    [Header("METER")]
    [Range(0,1)] public float drink;
    [Range(0, 1)] public float seed;
    [Range(0, 1)] public float fear;
    [Range(0, 1)] public float sanity;
    [Header("TAGS")]
    List<string> _tags;
    public string age;
    public string occup;
    public void seedScore(seeds seed)
    {
        foreach(string x in seed.pos_tags)
        {
            if (_tags.Contains(x))
                seed_score += 1;
        }
        foreach (string x in seed.neg_tags)
        {
            if (_tags.Contains(x))
                seed_score -= 1;
        }
    }
}
