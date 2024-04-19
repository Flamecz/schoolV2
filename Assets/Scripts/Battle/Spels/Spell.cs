using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class Spell : ScriptableObject
{
    public Sprite image;
    public string callout;
    public SpellType type;
    public int Damage;
    public int Boost;
    public int Resurection;
    public Unit unitToResurect;

    public enum SpellType
    {
        Resurection,
        Damage,
        Boost
    }
}
