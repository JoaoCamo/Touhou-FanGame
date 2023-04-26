using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] protected GameObject[] enemyPrefabs;
    protected float xMaxValue = 1.25f;
    protected float xMinValue = -2.875f;
    protected float yMaxValue = 2.25f;

    protected IEnumerator LTRRow(float initialDelay, float enemySpawnDelay, int ammountOfEnemies, int enemyType, float yPosition, string danmakuName, int bulletType, bool repeats=false, float shotDelay=0)
    {
        yield return new WaitForSeconds(initialDelay);
        GameObject enemyPreConfiguration;
        enemyPreConfiguration = enemyPrefabs[enemyType];
        enemyPreConfiguration.GetComponent<EnemyBehaviour>().setBehaviour(danmakuName, bulletType, 1.5f, shotDelay, repeats);
        enemyPreConfiguration.GetComponent<EnemyMovement>().setMovement(true);
        for(int i = 0; i<ammountOfEnemies; i++)
        {
            Instantiate(enemyPreConfiguration, new Vector2(xMinValue, yPosition), Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }

    protected IEnumerator RTLRow(float initialDelay, float enemySpawnDelay, int ammountOfEnemies, int enemyType, float yPosition, string danmakuName, int bulletType, bool repeats=false, float shotDelay=0)
    {
        yield return new WaitForSeconds(initialDelay);
        GameObject enemyPreConfiguration;
        enemyPreConfiguration = enemyPrefabs[enemyType];
        enemyPreConfiguration.GetComponent<EnemyBehaviour>().setBehaviour(danmakuName, bulletType, 1.5f, shotDelay, repeats);
        enemyPreConfiguration.GetComponent<EnemyMovement>().setMovement(false,true);
        for(int i = 0; i<ammountOfEnemies; i++)
        {
            Instantiate(enemyPreConfiguration, new Vector2(xMaxValue, yPosition), Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }

    protected IEnumerator TLRow(float initialDelay, float enemySpawnDelay, int ammountOfEnemies, int enemyType, float xPosition, string danmakuName, int bulletType, bool repeats=false, float shotDelay=0)
    {
        yield return new WaitForSeconds(initialDelay);
        GameObject enemyPreConfiguration;
        enemyPreConfiguration = enemyPrefabs[enemyType];
        enemyPreConfiguration.GetComponent<EnemyBehaviour>().setBehaviour(danmakuName, bulletType, 1.5f, shotDelay, repeats);
        enemyPreConfiguration.GetComponent<EnemyMovement>().setMovement(false,false,true);
        for(int i = 0; i<ammountOfEnemies; i++)
        {
            Instantiate(enemyPreConfiguration, new Vector2(xPosition, yMaxValue), Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }

    protected IEnumerator TRRow(float initialDelay, float enemySpawnDelay, int ammountOfEnemies, int enemyType, float xPosition, string danmakuName, int bulletType, bool repeats=false, float shotDelay=0)
    {
        yield return new WaitForSeconds(initialDelay);
        GameObject enemyPreConfiguration;
        enemyPreConfiguration = enemyPrefabs[enemyType];
        enemyPreConfiguration.GetComponent<EnemyBehaviour>().setBehaviour(danmakuName, bulletType, 1.5f, shotDelay, repeats);
        enemyPreConfiguration.GetComponent<EnemyMovement>().setMovement(false,false,false,true);
        for(int i = 0; i<ammountOfEnemies; i++)
        {
            Instantiate(enemyPreConfiguration, new Vector2(xPosition, yMaxValue), Quaternion.identity);
            yield return new WaitForSeconds(enemySpawnDelay);
        }
    }
}
