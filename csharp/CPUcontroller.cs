using PathCreation.Examples;

using UnityEngine;

public class CPUcontroller : MonoBehaviour
{
    [SerializeField] private PathFollower pathFollower;
    [SerializeField] private Aimanager aimanager;
    private float timeremaining;
    // for final result
    private int correctanswers;
    private int incorrectanswers;
    //set speed
    private float growspeed;
    private float bonuspeed;
    private float thisbonusspeed;
    private float turningspeed;
    private bool inturn;
    private float timeelapsed;
    private float timevariety;
    private void Start()
    {
        correctanswers = 0;
        incorrectanswers = 0;
        growspeed = 0;
        bonuspeed = 0;
        timeremaining = 0;
        thisbonusspeed = 0;
        turningspeed = 0;
        timeelapsed = 0;
        timevariety = 0;
        inturn = false;
    }
    private void Update()
    {
        // grow ai car speed
        if (aimanager.gamestate == 1 && growspeed < 100)
        {
            growspeed += 0.5f;
        }
        // check if still in answering or not
        if (aimanager.gamestate == 1)
        {
            if (timevariety == 0)
            {
                timevariety = UnityEngine.Random.Range(1, 5) + 5f;
            }
            // check if its time to answer
            if (timevariety > 0)
            {
                timeelapsed += Time.deltaTime;
                if (timeelapsed >= timevariety) { Answer(); timevariety = -1; }
            }
            // set bonus speed
            if (timevariety == -1)
            {
                thisbonusspeed = (timeremaining / 5) * bonuspeed;
                timeremaining -= Time.deltaTime;
                if (timeremaining <= 0) { timeremaining = 0; timevariety = 0; timeelapsed = 0; }
            }
            // set turn speed
            if (inturn)
            {
                if (turningspeed < 50) { turningspeed += 1f; }
                else turningspeed = 50;
            }
            else
            {
                if (turningspeed > 0) { turningspeed -= 0.5f; }
                else turningspeed = 0;
            }
            pathFollower.speed = growspeed + thisbonusspeed - turningspeed;
        }
    }


    private bool randomBoolean()
    {
        return (Random.value > 0.5f); ;
    }

    public void Answer()
    {
        bool iscorrect = randomBoolean();
        if (iscorrect) { bonuspeed = 20; correctanswers += 1; }
        else { bonuspeed = -20; incorrectanswers += 1; }
        timeremaining = 5f;
    }

    public int getcorrects()
    {
        return correctanswers;
    }

    public int getincorrects()
    {
        return incorrectanswers;
    }

    private void OnTriggerEnter(Collider colider)
    {
        if (colider.CompareTag("turn"))
        {
            inturn = true;
        }
    }
    private void OnTriggerExit(Collider colider)
    {
        if (colider.CompareTag("turn"))
        {
            inturn = false;
        }
    }
}
