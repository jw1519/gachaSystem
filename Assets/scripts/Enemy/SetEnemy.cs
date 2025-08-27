using UnityEngine;

namespace Enemy
{
    public class SetEnemy : MonoBehaviour
    {
        public BaseEnemy enemy;

        private void Awake()
        {
            enemy.controller = GetComponent<EnemyAnimationController>();     
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
    }
}
