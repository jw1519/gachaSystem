using System;
using UnityEditor.Animations;
using UnityEngine;


namespace Enemy
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "enemy")]
    public class BaseEnemy : ScriptableObject, ITakeDamage, IHeal
    {
        public static event Action enemyHealthChange;
        public static event Action enemyDefenceChange;
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
            enemyHealthChange?.Invoke();
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
                enemyDefenceChange?.Invoke();
            }
            if (health - damageTaken > 0)
            {
                health -= damageTaken;
                controller.ChangeAnimation("TakeDamage01", 0.2f, 3f);
                Debug.Log("here");
                enemyHealthChange?.Invoke();
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