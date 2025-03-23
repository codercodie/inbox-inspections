using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;
    string leaderboardKey = "IILB";
    int score;


    public void SubmitScore(string playerName, int score)
    {
        LootLockerSDKManager.SubmitScore(playerName, score, leaderboardKey, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Could not submit score!");
                Debug.Log(response.errorData.ToString());
                return;
            }
            Debug.Log("Successfully submitted score!");

        });
    }

    public void ShowLeaderboard()
    {
        int count = 10;

        LootLockerSDKManager.GetScoreList(leaderboardKey, count, 0, (response) =>
        {
            if (!response.success)
            {
                Debug.Log("Could not get score list!");
                leaderboardText.text = "Failed to load leaderboard.";
                return;
            }

            leaderboardText.text = "Leaderboard:\n";

            foreach (var entry in response.items)
            {
                leaderboardText.text += $"{entry.rank}. {entry.member_id} - {entry.score}\n";
            }

            Debug.Log("Successfully got score list!");
        });
    }
}

