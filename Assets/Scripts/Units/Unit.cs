using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class Unit :ScriptableObject
{
    public Sprite sprite;
    public Sprite imageInBattle;
    public string unitName;
    public string town;
    public float lvl;
    public float damage;
    public int defence;
    public int minDamage;
    public int maxDamage;
    public float health;
    public int speed;
    public int growth;
    public int aIvalue;
    public int cost;
    public Movementtype movetype;
    public attackType ATKT;
    public int Shots;
    public bool stackable;
    public Unit(string unitName, string town, float lvl, float damage, int Defence,
                int minDamage, int maxDamage, float health, int speed, int growth,
                int aIvalue,int cost, Movementtype movetype, attackType ATKT)
    {
        this.unitName = unitName;
        this.town = town;
        this.lvl = lvl;
        this.damage = damage;
        this.defence = Defence;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.health = health;
        this.speed = speed;
        this.growth = growth;
        this.aIvalue = aIvalue;
        this.cost = cost;
        this.movetype = movetype;
        this.ATKT = ATKT;
    }
   /* public Unit(string unitName, string town, float lvl, float damage, int Defence,
             int minDamage, int maxDamage, float health, float speed, int growth,
             int aIvalue, int cost, Movementtype movetype, attackType ATKT,int Shots)
    {
        this.unitName = unitName;
        this.town = town;
        this.lvl = lvl;
        this.damage = damage;
        this.defence = Defence;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.health = health;
        this.speed = speed;
        this.growth = growth;
        this.aIvalue = aIvalue;
        this.cost = cost;
        this.movetype = movetype;
        this.ATKT = ATKT;
        this.Shots = Shots;
    }
   */
    public enum Movementtype
    {
        ground,
        air
    }
    public enum attackType
    {
        ranger,
        melee
    }
    public void Attack(float health)
    {
        health -= this.damage;
    }
    public void damaged(float damage)
    {
        this.health -= damage;
    }
    public void move(int distance)
    {
        this.speed -= distance;
    }

    public float CalculateReducedDamage(int attack)
    {
        float reducedDamage = attack;
        return Mathf.Max(0, reducedDamage);
    }
}
