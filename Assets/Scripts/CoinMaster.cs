using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMaster : MonoBehaviour
{
    public string coinResults;

    public List<GameObject> players = new List<GameObject>();

    public void SendCoinResults(string result)
    {
        coinResults += result;
        if (coinResults.Length > 4)
        {
            string first4 = coinResults.Substring(0, 4);
            coinResults = first4;
        }
        if(coinResults.Length == 4)
        {
            int h_count = coinResults.Split('H').Length - 1;

            Debug.Log("Result Sent!");

            foreach (GameObject player in players)
            {
                player.GetComponent<CoinResults>().outcome = h_count;
                player.GetComponent<CoinResults>().PlayCoinResult();
            }
        }
    }
}
