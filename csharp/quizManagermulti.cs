using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class quizManagermulti : MonoBehaviour
{
    private List<String> QnAfile;
    public GameObject[] options;
    public int currentQuestionIndex;
    public TMP_Text questionText;


    [SerializeField] private TMP_Text Questioncounter;
    [SerializeField] private float currentcounter, maxquestion;
    [SerializeField] private Mainmulti mainscript;

    // for final result
    private int corrects;
    private int incorrects;
    
    private void Start()
    {
        corrects = 0;
        incorrects = 0;
        //get quiz from file txt in streamming assets

        //string readfromfilepath = Application.streamingAssetsPath + "/test123" + ".txt";
        //QnAfile = File.ReadAllLines(readfromfilepath).ToList();
        // get quiz from txt file in assets/resource
        //string filename = "test123";
        //string readfromfilepath = "Assets/Resources/"+filename+".txt";
        TextAsset readfromfilepath = Resources.Load("test123") as TextAsset;
        QnAfile = (readfromfilepath.ToString()).Split("\n").ToList();
        //QnAfile = File.ReadAllLines(readfromfilepath).ToList();
        //start quiz
        generateQuiz();
    }

    void generateQuiz() 
    {
        /*
        currentQuestionIndex = UnityEngine.Random.Range(0, QnA.Count);
        questionText.text = QnA[currentQuestionIndex].Question;
        setAnswers();
        */
        UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
        currentQuestionIndex = UnityEngine.Random.Range(0, QnAfile.Count);
        string[] currentQuestionString = QnAfile[currentQuestionIndex].Split("{===}");
        questionText.text = currentQuestionString[0];
        Debug.Log("current answer: " + currentQuestionString[5]);
        for (int i = 0; i < 4; i++)
        {
            options[i].GetComponent<Answers>().iscorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = currentQuestionString[i+1];
            string ansOpt = currentQuestionString[i+1].ToString().Trim();
            string ansThs = currentQuestionString[5].ToString().Trim();
            Debug.Log("value of ans : "+ ansOpt);
            Debug.Log("value of cqs[5] : " + currentQuestionString[5].Length);
            if (ansOpt.Equals(ansThs))
            {
                options[i].GetComponent<Answers>().iscorrect = true;
                Debug.Log("option "+ i+" set to correct");
            }
        }
        QnAfile.RemoveAt(currentQuestionIndex);
        mainscript.questionlimitreached = Mathf.Floor(currentcounter / maxquestion);
        Questioncounter.text = (currentcounter += 1).ToString() + "/" + maxquestion;
    }
   
    public void correct() 
    {
        generateQuiz();
    }

    public int getcorrects()
    {
        return corrects;
    }

    public void addcorrects()
    {
        corrects++;
    }

    public void addincorrects()
    {
        incorrects++;
    }

    public int getincorrects()
    {
        return incorrects;
    }
}
