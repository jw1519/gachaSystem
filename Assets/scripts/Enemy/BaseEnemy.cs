using System;
using UnityEngine;


namespace Enemy
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "enemy")]
    public class BaseEnemy : ScriptableObject, ITakeDamage, IHeal
    {
        public static event Action<int, BaseEnemy> enemyHealthDecrease;
        public static event Action enemyDefenceDeacrease;
        public static event Action enemydied;

        public GameObject EnemyPrefab;
        [HideInInspector] public EnemyAnimationController controller;

        [Header("Stats")]
        public string enemyName;
        public int health;
        public int maxHealth;
        public int damage;
        public int defence;
        public int abilityAmount;
        public bool isAlive => health > 0;

        public void Heal(int healAmount)
        {
            if (health + healAmount <= maxHealth)
            {
                health += healAmount;
            }
            else
            {
                health = maxHealth;
            }
            enemyHealthDecrease?.Invoke(healAmount, this);
        }

        public virtual void TakeDamage(int damageTaken)
        {
            //check for defences
            if (defence > 0)
            {
                if (defence >= damageTaken)
                {
                    defence -= damageTaken;
                    damageTaken = 0;
                }
                else
                {
                    damageTaken = damageTaken - defence;
                    defence = 0;
                }
                enemyDefenceDeacrease?.Invoke();
            }
            if (health - damageTaken > 0)
            {
                health -= damageTaken;
                controller.ChangeAnimation("TakeDamage01");
                controller.performingAction = true;
                enemyHealthDecrease?.Invoke(damageTaken, this);
            }
            else
            {
                health = 0;
                enemydied?.Invoke();
                controller.ChangeAnimation("Dead");
            }

        }
        public virtual void UseAbility(GameObject target)
        {
            Debug.Log("Use Ability here");
        }
    }
}