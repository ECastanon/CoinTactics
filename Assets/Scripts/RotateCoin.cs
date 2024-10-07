using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class RotateCoin : MonoBehaviour
{
    private List<Image> coinsprites = new List<Image>();
    private CoinMaster CoinMaster;
    private Image image;
    private int coinindex;
    private float timer;

    [HideInInspector]public bool coinIsFlipped;
    [HideInInspector] public Vector2 posToMoveTo;
    [HideInInspector] public float halfDist;

    public int CoinFlipInterval;
    public float CoinFlipSpeed;
    [HideInInspector] public int currentCFI;

    private void Start()
    {
        CoinMaster = GameObject.Find("CoinMaster").GetComponent<CoinMaster>();

        float rotation = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(0, 0, rotation);

        image = GetComponent<Image>();
        foreach (Transform child in GameObject.Find("CoinImages").transform)
        {
            coinsprites.Add(child.GetComponent<Image>());
        }
    }
    private void Update()
    {
        if (coinIsFlipped)
        {
            AdjustScale();
            //Check when coin reaches destination
            if (Vector2.Distance(transform.position, posToMoveTo) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, posToMoveTo, Time.deltaTime * (CoinFlipSpeed + Random.Range(0, 10)));
            }
            else
            {
                //Continue flipping until either Heads or Tails is reached
                if (coinsprites[coinindex].gameObject.name.Contains("HEADS"))
                {
                    currentCFI = 0;
                    image.sprite = coinsprites[coinindex].sprite;

                    Debug.Log("OUTCOME WAS: HEADS!!!");
                    CoinMaster.SendCoinResults("H");
                    coinIsFlipped = false;
                }
                if (coinsprites[coinindex].gameObject.name.Contains("TAILS"))
                {
                    currentCFI = 0;
                    image.sprite = coinsprites[coinindex].sprite;

                    Debug.Log("OUTCOME WAS: TAILS!!!");
                    CoinMaster.SendCoinResults("T");
                    coinIsFlipped = false;
                }
            }
        }

        if (currentCFI == 0)
        {
            return;
        }

        image.sprite = coinsprites[coinindex].sprite;

        if(timer > currentCFI)
        {
            coinindex++;

            if (coinindex >= coinsprites.Count)
            {
                coinindex = 0;
            }
            timer = 0;
        }
        else
        {
            timer += 1;
        }
    }

    private void AdjustScale()
    {
        //As the coin gets closer to the half way point, value decreases
        float scaleValue = 1;
        if (transform.position.y > halfDist)
        {
            scaleValue = halfDist / transform.position.y;
        }
        else
        {
            scaleValue = transform.position.y / halfDist;
        }

        //Original scale = 2
        //Max scale = 4.5
        transform.localScale = new Vector2(2 + (2.5f * scaleValue), 2 + (2.5f * scaleValue));
    }
}
