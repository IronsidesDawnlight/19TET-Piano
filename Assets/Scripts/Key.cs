using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    AudioSource aud;
    SpriteRenderer sr;
    Color normalColor, highlightColor;

    // Public
    public int step;
    public string keyboardInput;
    public AudioClip pianoSource;
    public AudioClip choirSource;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        aud.pitch = Mathf.Pow(2, (step)/19.0f );
        aud.clip = pianoSource;

        switch ( step % 19 )
        {
            case 0:
            case 3:
            case 6:
            case 8:
            case 11:
            case 14:
            case 17:
                normalColor = new Color( 1.0f, 1.0f, 1.0f, 1.0f );
                break;
            case 1:
            case 4:
            case 9:
            case 12:
            case 15:
                normalColor = new Color( 0.5f, 0.5f, 0.5f, 1.0f );
                break;
            case 2:
            case 5:
            case 7:
            case 10:
            case 13:
            case 16:
            case 18:
                normalColor = new Color( 0f, 0f, 0f, 1f );
                break;
            default:
                normalColor = new Color( 1.0f, 1.0f, 1.0f, 1.0f );
                break;
        }
        highlightColor = new Color( 0.5f, 0.7f, 0.5f, 1.0f );

        sr.color = normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( keyboardInput ) ){
            aud.Play();
            sr.color = highlightColor;
        }
        else if (Input.GetKeyUp( keyboardInput )){
            aud.Stop();
            sr.color = normalColor;
        }
    }
}
