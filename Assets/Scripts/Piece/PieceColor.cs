using UnityEngine;

public class PieceColor : MonoBehaviour
{
    [SerializeField]
    private Sprite blueColor;
    [SerializeField]
    private Sprite redColor;
    [SerializeField]
    private Sprite greenColor;
    [SerializeField]
    private Sprite purpleColor;
    [SerializeField]
    private Sprite goldColor;
    [SerializeField]
    private Sprite greyColor;
    [SerializeField]
    private Sprite brownColor;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        ChooseColor();
    }

    private void ChooseColor()
    {
        //TODO
        // set spriteRenderer.sprite to a random sprite that is present above

        //spriteRenderer.sprite = ???;
        switch (Random.Range(0, 7)) {
            case 0:
                spriteRenderer.sprite = blueColor;
                break;
            case 1:
                spriteRenderer.sprite = redColor;
                break;
            case 2:
                spriteRenderer.sprite = greenColor;
                break;
            case 3:
                spriteRenderer.sprite = purpleColor;
                break;
            case 4:
                spriteRenderer.sprite = goldColor;
                break;
            case 5:
                spriteRenderer.sprite = greyColor;
                break;
            case 6:
                spriteRenderer.sprite = brownColor;
                break;
        }
    }
}
