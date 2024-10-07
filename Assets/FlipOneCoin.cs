using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlipOneCoin : MonoBehaviour
{
    public int coinNumber;
    RotateCoin rc;
    private CoinMaster CoinMaster;

    private void Start()
    {
        CoinMaster = GameObject.Find("CoinMaster").GetComponent<CoinMaster>();
        rc = GetComponent<RotateCoin>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("WAS CLICKED");
        FlipCoin();
    }
    public void FlipCoin()
    {
        //Checks if the reflip counter exists
        if (GameObject.Find("Re-Flips").GetComponent<ReflipCounter>() != null)
        {
            ReflipCounter rfc = GameObject.Find("Re-Flips").GetComponent<ReflipCounter>();

            if (rfc.flipsRemaining > 0 && rc.coinIsFlipped)
            {
                //Removes the coin's previous outcome
                StringBuilder strBuilder = new StringBuilder(CoinMaster.coinResults);
                strBuilder.Remove(coinNumber, 1);

                //Reset Coin Position
                transform.position = GameObject.Find("Panel").GetComponent<FlipAllCoins>().coinLocations[coinNumber];
                //Reset Coin Rotation
                float rotation = Random.Range(0, 360);
                transform.rotation = Quaternion.Euler(0, 0, rotation);

                //Flip Coins
                rc.coinIsFlipped = true;
                rc.currentCFI = rc.CoinFlipInterval;
                rc.posToMoveTo = new Vector2(transform.position.x + Random.Range(-10, 10), transform.position.y + 95 + Random.Range(-30, 30));
                rc.halfDist = transform.position.y + ((rc.posToMoveTo.y - transform.position.y) / 2);
            }
        }
    }
}
