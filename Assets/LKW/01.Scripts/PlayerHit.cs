using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private SpriteRenderer _spriterenderer;

    private void Awake()
    {
        _spriterenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
    }

    public void ChangeNotHitBody()
    {
        if (gameObject.layer != 8)
        {
            gameObject.layer = LayerMask.NameToLayer("NotHitBody");
        }
    }

    public void HitBlink()
    {
        StartCoroutine(BlinkCoroutine());
    }

    private IEnumerator BlinkCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        _spriterenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _spriterenderer.color = new Color(1, 1, 1, 1);

        for (int i = 0; i< 3; i++)
        {
            yield return new WaitForSeconds(0.2f);
            _spriterenderer.color = new Color(1, 1, 1, 0.4f);
            yield return new WaitForSeconds(0.2f);
            _spriterenderer.color = new Color(1, 1, 1, 1);
        }
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
}
