using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 20f;
    Slider timeSlider;
    bool triggeredLevelFinished = false;

    // Start is called before the first frame update
    void Start()
    {        
        timeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }

         timeSlider.value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().FinishTimer();
            triggeredLevelFinished = true;
        }
    }
}
