using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] protected GameObject[] enemyPrefabs;
    protected float xMaxValue = 1.25f;
    protected float xMinValue = -2.875f;
    protected float yMaxValue = 2.25f;

    protected IEnumerator LTRRow(float initialDelay, int ammountOfEnemies, int enemyType, Vector2 position, string danmakuName, int bulletType, bool repeats=false, float shotDelay=0)
    {
        yield return new WaitForSeconds(initialDelay);
        GameObject enemyPreConfiguration;
        enemyPreConfiguration = enemyPrefabs[enemyType];
        enemyPreConfiguration.GetComponent<EnemyBehaviour>().setBehaviour(danmakuName, bulletType, 1.5f, shotDelay, repeats);
        enemyPreConfiguration.GetComponent<EnemyMovement>().setMovement(true);
        for(int i = 0; i<ammountOfEnemies; i++)
        {
            Instantiate(enemyPreConfiguration, position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    protected IEnumerator RTLRow(float initialDelay,  int ammountOfEnemies, int enemyType, Vector2 position, string danmakuName, int bulletType, bool repeats=false, float shotDelay=0)
    {
        yield return new WaitForSeconds(initialDelay);
        GameObject enemyPreConfiguration;
        enemyPreConfiguration = enemyPrefabs[enemyType];
        enemyPreConfiguration.GetComponent<EnemyBehaviour>().setBehaviour(danmakuName, bulletType, 1.5f, shotDelay, repeats);
        enemyPreConfiguration.GetComponent<EnemyMovement>().setMovement(false, true);
        for(int i = 0; i<ammountOfEnemies; i++)
        {
            Instantiate(enemyPreConfiguration, position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
