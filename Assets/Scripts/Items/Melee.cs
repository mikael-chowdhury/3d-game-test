using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Item
{
    public Transform player;

    public int attackRange;

    public LivingEntity[] getEnemiesInAttackRange()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.SetParent(player.transform);
        return new LivingEntity[] { };
    }
}