using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Background : MonoBehaviour
{
    public Image bg;
    public Sprite[] sprites;
    private int cur_id;

    public void ChangeBackground()
    {
        int id = Random.Range(0, sprites.Length);
        while (id == cur_id)
        {
            id = Random.Range(0, sprites.Length);
        }
        bg.sprite = sprites[id];
        cur_id = id;
    }
}
