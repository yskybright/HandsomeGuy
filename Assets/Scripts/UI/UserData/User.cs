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
    public void SetupItem(VivoxParticipant participant /*,string skill*/)
    {
        Participant = participant;
        user_name.text = "닉네임 : " + participant.DisplayName;
        //skill_name.text = skill;
    }
}
