using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour
{
    public static SFXCtrl Instance;
    public SFX sfx;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    public void CoinSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_coin_sparkle, pos, Quaternion.identity);
    }
    public void Powerup(Vector3 pos)
    {
        Instantiate(sfx.sfx_powerup, pos, Quaternion.identity);
    }
    public void PlayerLands(Vector3 pos)
    {
        Instantiate(sfx.sfx_player_lands, pos, Quaternion.identity);
    }


    public void HandleCrate(Vector3 pos) 
    {
        Vector3 pos1 = pos;
        pos1.x += 0.3f;

        Vector3 pos2 = pos;
        pos2.x -= 0.3f;

        Vector3 pos3 = pos;
        pos3.y -= 0.3f;
        pos3.x += 0.3f;

        Vector3 pos4 = pos;
        pos3.y -= 0.3f;
        pos4.x -= 0.3f;

        Instantiate(sfx.fragment1, pos1, Quaternion.identity);
        Instantiate(sfx.fragment2, pos2, Quaternion.identity);
        Instantiate(sfx.fragment2, pos3, Quaternion.identity);
        Instantiate(sfx.fragment1, pos4, Quaternion.identity);
    }
}
