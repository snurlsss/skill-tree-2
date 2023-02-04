using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootProperties : MonoBehaviour
{
    bool connectUp;
    bool connectLeft;
    bool connectRight;
    bool connectDown;

    [SerializeField] private SpriteRenderer spriteRenderer;
    public Sprite[] rootSprites = new Sprite[15];

    // Start is called before the first frame update
    void Start()
    {
        UpdateSprite();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSprite(bool up, bool left, bool right, bool down)
    {
        if (up == true)
        {
            if (left == true)
            {
                if (right == true)
                {
                    if (down == true) // ULRD
                    {
                        spriteRenderer.sprite = rootSprites[0];
                    }
                    else // ULR-
                    {
                        spriteRenderer.sprite = rootSprites[1];
                    }
                }
                else
                {
                    if (down == true) // UL-D
                    {
                        spriteRenderer.sprite = rootSprites[2];
                    }
                    else // UL--
                    {
                        spriteRenderer.sprite = rootSprites[3];
                    }
                }
            }
            else
            {
                if (right == true)
                {
                    if (down == true) // U-RD
                    {
                        spriteRenderer.sprite = rootSprites[4];
                    }
                    else // U-R-
                    {
                        spriteRenderer.sprite = rootSprites[5];
                    }
                }
                else
                {
                    if (down == true) // U--D
                    {
                        spriteRenderer.sprite = rootSprites[6];
                    }
                    else // U---
                    {
                        spriteRenderer.sprite = rootSprites[7];
                    }
                }
            }
        }
        else
        {
            if (left == true)
            {
                if (right == true)
                {
                    if (down == true) // -LRD
                    {
                        spriteRenderer.sprite = rootSprites[8];
                    }
                    else // -LR-
                    {
                        spriteRenderer.sprite = rootSprites[9];
                    }
                }
                else
                {
                    if (down == true) // -L-D
                    {
                        spriteRenderer.sprite = rootSprites[10];
                    }
                    else // -L--
                    {
                        spriteRenderer.sprite = rootSprites[11];
                    }
                }
            }
            else
            {
                if (right == true)
                {
                    if (down == true) // --RD
                    {
                        spriteRenderer.sprite = rootSprites[12];
                    }
                    else // --R-
                    {
                        spriteRenderer.sprite = rootSprites[13];
                    }
                }
                else
                {
                    if (down == true) // ---D
                    {
                        spriteRenderer.sprite = rootSprites[14];
                    }
                    else // ----
                    {

                    }
                }
            }
        }
    }

    void UpdateSprite()
    {

    }
}
