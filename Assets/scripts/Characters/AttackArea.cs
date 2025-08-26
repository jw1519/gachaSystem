using Enemy;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public List<ITakeDamage> damagables { get; } = new();
    private void OnTriggerEnter(Collider other)
    {
        var damage = other.GetComponent<SetEnemy>().enemy;
        if (damage != null)
        {
            Debug.Log("here");
            damagables.Add(damage);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var damage = other.GetComponent<SetEnemy>().enemy;
        if ( damage != null && damagables.Contains(damage))
        {
            damagables.Remove(damage);
        }
    }
}
