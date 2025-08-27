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
        private void Start()
        {
            enemy.controller.ChangeAnimation("Idle");
            Debug.Log("start");
        }
        private void FixedUpdate()
        {
            //if (!enemy.controller.isAttacking)
            //{
            //    if (enemy.health > 0)
            //    {
            //        enemy.controller.ChangeAnimation("Idle");
            //    }
            //}
        }
    }
}
