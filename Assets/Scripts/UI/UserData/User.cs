using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Vivox;
using UnityEngine;
using UnityEngine.UI;

public class User : MonoBehaviour
{
    public VivoxParticipant Participant;
    private GameData _gameData = new();
    public GameData Data => _gameData;

    [SerializeField] Image User_Img;
    [SerializeField] TMP_Text user_name;
    [SerializeField] TMP_Text skill_name;
    public GameObject ready;
    public void SetupItem(VivoxParticipant participant /*,string skill*/)
    {
        Participant = participant;
        user_name.text = "닉네임 : " + participant.DisplayName;
        //skill_name.text = skill;
    }
    public void ToggleReady()
    {
        if(ready.activeSelf)
            ready.SetActive(false);
        else
            ready.SetActive(true);
    }

    public void SetImage()
    {
        User_Img.sprite = Main.ResourceManager.GetResource<Sprite>($"{Main.GameManager.CharacterType}.sprite");
    }
}
