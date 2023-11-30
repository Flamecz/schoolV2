using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    private int _defense;
    public string unitName;
    public string town;
    public int lvl;
    public float damage;
    public int Defence
    {
        get { return _defense; }
        set { _defense = Mathf.Clamp(value, 0, 70); }
    }
    public int minDamage;
    public int maxDamage;
    public float health;
    public float speed;
    public int growth;
    public int aIvalue;
    public int cost;
    public Movementtype movetype;
    public attackType ATKT;
    

    public enum Movementtype
    {
        ground,
        air
    }
    public enum attackType
    {
        ranger,
        melee,
        hybrid
    }
    public void Attack(float health)
    {
        health -= this.damage;
    }
    public void damaged(float damage)
    {
        this.health -= damage;
    }
    public void move(float distance)
    {
        this.speed -= distance;
    }

    public float CalculateReducedDamage(int attack)
    {
        float reducedDamage = attack;
        return Mathf.Max(0, reducedDamage);
    }
}
