using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// bliblioteka do reklam
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

    public void ShowRewardedAd()
    {
        Debug.Log("Showing Rewarded Ad");
        // check if the advertisement is ready (rewardedVideo)
        // if so Show(rewardedVideo)

        // delegaty i eventy ! C# !
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("rewardedVideo", options);
        }

        // f12 - idz do zrodla
        //ShowOptions()
        //Advertisement.Show()
    }

    void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                // wedle prowadzacego kurs, classy menagerskie powinny sie komunikowac tylko ze soba, a nie w tym wypadku z playerem
                // FindObjectOfType<Player>().AddRewardedGems();
                GameManager.Instance.Player.AddGems(100f);
                UIManager.Instance.OpenShop(GameManager.Instance.Player.amountOfDiamonds);
                Debug.Log("You finished the ad, here's 100 Gems!");
                break;
            case ShowResult.Failed:
                Debug.Log("You skipped the ad! No Gems for you!");
                break;
            case ShowResult.Skipped:
                Debug.Log("The Video failed, it must not have been ready");
                break;
        }
    }
}
