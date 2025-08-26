using UnityEngine;

namespace Enemy
{
    public class SetEnemy : MonoBehaviour
    {
        public BaseEnemy enemy;
        EnemyAnimationController controller;

        private void Awake()
        {
            controller = GetComponent<EnemyAnimationController>();
        }

        private void Start()
        {
            
        }
        private void FixedUpdate()
        {
            controller.ChangeAnimation("Idle");
        }
    }
}
