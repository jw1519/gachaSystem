using UnityEngine;

namespace Enemy
{
    public class SetEnemy : MonoBehaviour
    {
        public BaseEnemy enemy;
        private void Awake()
        {
            enemy.controller = GetComponent<EnemyAnimationController>();    
            if (enemy.controller != null )
            {
                gameObject.AddComponent<EnemyAnimationController>();
            }
            enemy = Instantiate(enemy);
        }
        private void OnEnable()
        {
            BaseEnemy.enemyHealthDecrease += CreateDamagePopUp;
        }

        private void FixedUpdate()
        {
            if (enemy.controller.performingAction == false)
            {
                if (enemy.health > 0)
                {
                    enemy.controller.ChangeAnimation("Idle");
                }
            }
        }
        private void CreateDamagePopUp(int damage, BaseEnemy enemy, bool isCrit)
        {
            if (enemy.name != this.enemy.name)
                return;
            DamagePopUp.Create(transform.position, damage, isCrit);
        }
    }
}
