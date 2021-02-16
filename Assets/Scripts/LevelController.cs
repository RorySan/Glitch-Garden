using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    int attackersAlive = 0;
    [SerializeField] bool isTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int waitToLoad = 2;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    public void attackerSpawned()
    {
        attackersAlive++;
    }

    public void attackerKilled()
    {
        attackersAlive--;
        if (attackersAlive <= 0 && isTimerFinished == true)
        {
           StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        Time.timeScale = 0;
        loseLabel.SetActive(true);
    }



    public void FinishTimer()
    {
        isTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        Debug.Log("stopping spawners");
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    


    

}
