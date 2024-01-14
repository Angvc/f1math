using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool iscorrect = false;
    public quizManager quizManager;
    public Main mainscript; // for answers's effects

    // sfx correct incorrect
    [SerializeField] private AudioClip correct;
    [SerializeField] private AudioClip incorrect;
    public void Answer() 
    {
        
        if (iscorrect)
        {
            Debug.Log("correct answer");
            quizManager.correct();
            quizManager.addcorrects();
            mainscript.Estatus = true;
            mainscript.Astatus = true;
            mainscript.timeRemaining = 5; // forr 5 sec cooldown
            SoundManager.Instance.Playsound(correct);
        }
        else
        {
            Debug.Log("incorrect answer");
            quizManager.correct();
            quizManager.addincorrects();
            mainscript.Estatus = true;
            mainscript.Astatus = false;
            mainscript.timeRemaining = 5; // forr 5 sec cooldown
            SoundManager.Instance.Playsound(incorrect);
        }
    }


}
