using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Vivox;
using Unity.Services.Authentication;
using UnityEngine;
using System.Threading.Tasks;

public class VivoxManager
{
    private string _server = "https://unity.vivox.com/appconfig/14568-vivox-50837-udash";
    private string _domain = "mtu1xp.vivox.com";
    private string _issuer = "14568-vivox-50837-udash";
    private string _tokenKey = "iJVdGUKNdH5wEEffmtre001BUyvhPDAU";
    private string _channelName = "lobbyChannel";
    private string _userName => Main.GameManager.NickName;

    LoginOptions options;
    async Task InitializeAsync()
    {
        InitializationOptions options = new InitializationOptions();
        options.SetVivoxCredentials(_server, _domain, _issuer, _tokenKey);
        await UnityServices.InitializeAsync(options);
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        await VivoxService.Instance.InitializeAsync();

        //참가자 관련
        VivoxService.Instance.ParticipantAddedToChannel += OnParticipantAdded;
        VivoxService.Instance.ParticipantRemovedFromChannel += OnParticipantRemoved;

        //메시지 관련
        VivoxService.Instance.ChannelMessageReceived += OnChannelMessageReceived;
    }
    private void OnDestroy()
    {
        VivoxService.Instance.ParticipantAddedToChannel -= OnParticipantAdded;
        VivoxService.Instance.ParticipantRemovedFromChannel -= OnParticipantRemoved;
        VivoxService.Instance.ChannelMessageReceived -= OnChannelMessageReceived;

    }
    public async Task LoginToVivoxAsync()
    {
        options = new LoginOptions();
        options.DisplayName = _userName;
        await VivoxService.Instance.LoginAsync(options);
    }
    public async Task LogoutOfVivoxAsync()
    {
        await VivoxService.Instance.LogoutAsync();
    }
    public async Task JoinGroupChannelAsync(string channelName)
    {
        string channelToJoin = channelName;

        await VivoxService.Instance.JoinGroupChannelAsync(_channelName, ChatCapability.TextAndAudio);
    }
    public async Task LeaveEchoChannelAsync(string channelName)
    {
        string channelToLeave = channelName;
        await VivoxService.Instance.LeaveChannelAsync(_channelName);
    }

    void OnParticipantAdded(VivoxParticipant participant)
    {
        //UI.InputUser(participant);
        //UI.InputChat($"{participant.DisplayName} 님이 접속했습니다.");
    }
    void OnParticipantRemoved(VivoxParticipant participant)
    {
        //UI.DeleteUser(participant);
        //UI.InputChat($"{participant.DisplayName} 님이 떠났습니다.");
    }
    void OnChannelMessageReceived(VivoxMessage message)
    {
        //UI.InputChat(message.MessageText);
        //UI.StartCoroutine(UI.SendScrollRectToBottom());
    }
    public void SendChatMessage(string msg)
    {
        msg = $"{_userName} : " + msg;
        VivoxService.Instance.SendChannelTextMessageAsync(_channelName, msg);
    }
}
