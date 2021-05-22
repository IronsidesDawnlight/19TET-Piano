using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Instruments {
    PIANO,
    CHOIR,
    __CNT
}

public class KeyManager : MonoBehaviour
{
    List<Key> keys = new List<Key>();

    public Color white;
    public Color grey;
    public Color black;
    public Color highlight;

    void Update(){
        if ( Input.GetKeyDown("1") ){
            SetSource( Instruments.PIANO );
        }
        else if ( Input.GetKeyDown("2") ){
            SetSource( Instruments.CHOIR );
        }
    }

    public void Attach( Key key ){
        keys.Add( key );
    }

    public void SetSource( string instrument ){
        if ( instrument == "piano" ){
            SetSource( Instruments.PIANO );
        }
        else if ( instrument == "choir" ){
            SetSource( Instruments.CHOIR );
        }
    }

    public void SetSource( Instruments instrument ){
        foreach ( Key key in keys )
        {
            key.SetSource( instrument );
        }
    }
}
