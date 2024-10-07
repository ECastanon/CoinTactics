using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlipAllCoins : MonoBehaviour, IPointerClickHandler
{
    private CoinMaster CoinMaster;

    public List<RotateCoin> coins = new List<RotateCoin>();
    public List<Vector2> coinLocations = new List<Vector2>();

    private void Start()
    {
        CoinMaster = GameObject.Find("CoinMaster").GetComponent<CoinMaster>();
        foreach (RotateCoin coin in coins)
        {
            coinLocations.Add(coin.transform.position);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CoinMaster.coinResults = "";
        for (int i = 0; i < coins.Count; i++)
        {
            //Reset Coin Position
            coins[i].transform.position = coinLocations[i];
            //Reset Coin Rotation
            float rotation = Random.Range(0, 360);
            coins[i].transform.rotation = Quaternion.Euler(0, 0, rotation);

            //Flip Coins
            coins[i].coinIsFlipped = true;
            coins[i].currentCFI = coins[i].CoinFlipInterval;
            coins[i].posToMoveTo = new Vector2(coins[i].transform.position.x + Random.Range(-10, 10), coins[i].transform.position.y + 95 + Random.Range(-30, 30));
            coins[i].halfDist = coins[i].transform.position.y + ((coins[i].posToMoveTo.y - coins[i].transform.position.y) / 2);
        }
    }
}
