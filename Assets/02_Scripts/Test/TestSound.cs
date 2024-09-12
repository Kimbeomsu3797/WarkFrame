using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioClip audioClip2;
    // Start is called before the first frame update
    void Start()
    {
        Managers.Sound.Play(audioClip, Define.Sound.Bgm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Managers.Sound.Play(audioClip2);
    }
}
