using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    AudioSource aud;
    SpriteRenderer sr;
    KeyManager km;
    
    Color normalColor, highlightColor;
    bool fading = false;
    float fadeTime = 0.1f; // WARNING: fadeTime cannot be 0

    // Public
    public int step; // The step of this note in 19-TET
    public string keyboardInput;
    public AudioClip[] sources = new AudioClip[(int)Instruments.__CNT];
    public int sourceOffset; // The step of audiosource in 12-TET

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        km = GameObject.Find("KeyManager").GetComponent<KeyManager>();

        aud.pitch = Mathf.Pow(2, (step)/19.0f - (sourceOffset)/12.0f );
        SetSource( Instruments.PIANO );

        km.Attach( this );
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( keyboardInput ) ){
            Play();
        }
        else if (Input.GetKeyUp( keyboardInput )){
            Stop();
        }

        if ( fading ) {
            aud.volume -= Time.deltaTime / fadeTime;
            if ( aud.volume <= 0 ){
                aud.volume = 0;
                fading = false;
                aud.Stop();
            }
        }
    }

    void Play(){
        fading = false;
        aud.volume = 1f;
        aud.Play();
        sr.color = highlightColor;
    }

    void Stop(){
        fading = true;
        sr.color = normalColor;
    }

    public void SetColor(){
        switch ( step % 19 )
        {
            case 0:
            case 3:
            case 6:
            case 8:
            case 11:
            case 14:
            case 17:
                normalColor = km.white;
                break;
            case 1:
            case 4:
            case 9:
            case 12:
            case 15:
                normalColor = km.grey;
                break;
            case 2:
            case 5:
            case 7:
            case 10:
            case 13:
            case 16:
            case 18:
                normalColor = km.black;
                break;
            default:
                normalColor = km.white;
                break;
        }
        highlightColor = km.highlight;

        sr.color = normalColor;
    }

    public void SetSource( Instruments instrument ){
        aud.clip = sources[(int)instrument];
        switch ( instrument ){
            case Instruments.PIANO:
                fadeTime = 0.1f;
                break;
            case Instruments.CHOIR:
                fadeTime = 0.3f;
                break;
            default:
                fadeTime = 0.1f;
                break;
        }
    }
}
