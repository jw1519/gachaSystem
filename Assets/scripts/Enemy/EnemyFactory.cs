using UnityEngine;

namespace Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        public static EnemyFactory instance;
        GameObject enemyPrefab;

        public Transform enemyParent;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        public GameObject CreateEnemy(BaseEnemy enemy)
        {
            enemyPrefab.GetComponent<SetEnemy>().enemy = Instantiate(enemy);
            GameObject instance = Instantiate(enemyPrefab);
            return instance;
        }
    }
}