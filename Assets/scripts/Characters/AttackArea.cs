using Enemy;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public List<ITakeDamage> damagables { get; } = new();
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SetEnemy>().enemy != null)
        {
            damagables.Add(other.GetComponent<SetEnemy>().enemy);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SetEnemy>().enemy != null && damagables.Contains(other.GetComponent<SetEnemy>().enemy))
        {
            damagables.Remove(other.GetComponent<SetEnemy>().enemy);
        }
    }
}
