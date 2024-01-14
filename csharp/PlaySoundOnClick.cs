using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    public void playsound()
    {
            SoundManager.Instance.Playsound(_clip);
    }
}
