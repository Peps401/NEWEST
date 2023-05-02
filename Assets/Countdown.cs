using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timeStart;
    public float tracker;
    public Text textBox;

    public LevelController levelController;

    int x;

    public void InitializeController(LevelController levelController, int maxTime){
        this.levelController = levelController;
        timeStart = maxTime;
        tracker = timeStart - 5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
        x = levelController.roomsDiscovered;
        if(x == 6){
            Every5SecLoseHealth(timeStart);
        }
    }

    void Every5SecLoseHealth(float time){
        if(timeStart == tracker){
            tracker -= 5f;
            gameObject.SendMessage("LoseHealth", 10); 
        }
    }
}
