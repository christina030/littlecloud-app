using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Like_Lock : MonoBehaviour
{
    public Image B_like, B_lock;
    public Sprite[] like_sprites, lock_sprites;
    private int cur_like_id, cur_lock_id;

    public void ChangeLike()
    {
        if (cur_like_id == 0) {
            cur_like_id = 1;
            B_like.sprite = like_sprites[1];
        }
        else {
            cur_like_id = 0;
            B_like.sprite = like_sprites[0];
        }
    }

    public void ChangeLock()
    {
        if (cur_lock_id == 0) {
            cur_lock_id = 1;
            B_lock.sprite = lock_sprites[1];
        }
        else {
            cur_lock_id = 0;
            B_lock.sprite = lock_sprites[0];
        }
    }
}
