using System;
using UnityEngine;

namespace Character
{
    public abstract class BaseCharacter : MonoBehaviour, ITakeDamage, IHeal
    {
        public static event Action playerHealthChanged;
        public static event Action playerDefenceChanged;

        [Header("Character Sprite")]
        public Sprite characterSprite;
        public Sprite characterProfileSprite;

        [Header("Stats")]
        public string characterName;
        public int health;
        public int maxHealth;
        public int damage;
        public int defence;
        public int critRate;
        public int critDamage;

        [Header("Energy")]
        public int energy;
        public int maxEnergy;
        public bool isAlive => health > 0;

        public virtual void Start()
        {
            CombatManager.instance.AddToCombat(gameObject);
        }
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
            playerHealthChanged?.Invoke();
        }

        public void TakeDamage(int damageTaken, bool isCritHit)
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
                    damageTaken -= defence;
                    defence = 0;
                }
                playerDefenceChanged?.Invoke();
            }
            if (health - damageTaken > 0)
            {
                health -= damageTaken;
            }
            else
            {
                health = 0;
            }
            playerHealthChanged?.Invoke();
        }

        public void UseEnergy(int amount)
        {
            if (energy - amount >= 0)
            {
                energy -= amount;
            }
        }
        public bool IsCriticalHit()
        {
            return UnityEngine.Random.Range(0, 100) < critRate;
        }
        public int CalculateDamage()
        {
            int crit = Mathf.RoundToInt(damage * (1 + (critDamage/10)));
            return crit;
        }
    }
}
