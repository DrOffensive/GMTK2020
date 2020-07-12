using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public GameObject popup_show;
    public GameObject jingle;

    public AudioClip main2;
    public AudioClip main3;

    public int current_note = 0;
    public int max_note = 6;

    public List<AudioClip> sounds_severity1;
    public List<AudioClip> sounds_severity2;
    public List<AudioClip> sounds_severity3;

    public List<AudioClip> jingles;

    public void Awake()
    {
        StartPlayingMusic();


    }

    public void StartPlayingMusic()
    {
        AudioSource component = GetComponent<AudioSource>();
        component.Play();
        StartCoroutine(PlayTransition());
    }

    public void Update() {
        if (Input.GetButtonDown("Jump"))
            CreateShowSound();

    }


    public void CreateShowSound() {
        AudioSource created = Instantiate(popup_show).GetComponent<AudioSource>();
        switch (Random.Range(0, 3)) { 
            case 0:
                created.clip = sounds_severity1[current_note];
                break;
            case 1:
                created.clip = sounds_severity2[current_note];
                break;
            case 2:
                created.clip = sounds_severity3[current_note];
                break;
        }
        created.Play();
        current_note++;
        if (current_note > max_note)
            current_note = 0;
    }


    public void CreateJingle(BasePopup popup) {
        GameObject created = Instantiate(jingle);
        AudioSource source = created.GetComponent<AudioSource>();

        source.clip = jingles[Random.Range(0, jingles.Count)];
        source.Play();
        created.transform.parent = popup.transform;
    }

    public IEnumerator PlayTransition() {
        yield return new WaitForSeconds(266);
        AudioSource component = GetComponent<AudioSource>();
        component.clip = main2;
        component.Play();
        StartCoroutine(PlayDistortion());
    }
    public IEnumerator PlayDistortion()
    {
        yield return new WaitForSeconds(266);
        AudioSource component = GetComponent<AudioSource>();
        component.clip = main3;
        component.Play();        
    }

}
