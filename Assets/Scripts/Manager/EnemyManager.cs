using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    private GameManager gameManager;
    private void Awake()
    {
        
    }
    //public void Init(GameManager gameManager)
    //{
    //    this.gameManager = gameManager;
    //}
    private void Start()
    {
        gameManager = GameManager.Instance;
        StartCoroutine(SpawnMonsterCo());
    }
    private IEnumerator SpawnMonsterCo()
    {
        while(GameManager.Instance.isGameOver == false)
        {
            Vector3 nowPos = transform.position;
            nowPos.y = Random.Range(-5, 4.5f);
            nowPos.z = 0;
            GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], nowPos, Quaternion.identity);
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            Debug.Log(gameManager.player.name);
            enemyController.Init(this, gameManager.player.transform);
            yield return new WaitForSeconds(2);
        }
    }


}
