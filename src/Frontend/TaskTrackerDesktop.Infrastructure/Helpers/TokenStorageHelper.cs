using System;
using System.Text.Json;
using TaskTrackerDesktop.Core.Models;
using Windows.Security.Credentials;

namespace TaskTrackerDesktop.Infrastructure.Helpers;

internal sealed class TokenStorageHelper
{
    private const string ResourceName = "TaskTrackerDesktop";
    private const string AccessTokenKey = "AccessToken";
    private const string RefreshTokenKey = "RefreshToken";
    private const string UserKey = "CurrentUser";

    private readonly PasswordVault _vault = new();

    public string? AccessToken => GetString(AccessTokenKey);

    public string? RefreshToken => GetString(RefreshTokenKey);

    public UserModel? CurrentUser => GetUser();

    public bool HasTokens => !string.IsNullOrEmpty(AccessToken) && !string.IsNullOrEmpty(RefreshToken);

    public void SaveTokens(string accessToken, string refreshToken)
    {
        Remove(AccessTokenKey);
        Remove(RefreshTokenKey);

        _vault.Add(new PasswordCredential(
            ResourceName,
            AccessTokenKey,
            accessToken));

        _vault.Add(new PasswordCredential(
            ResourceName,
            RefreshTokenKey,
            refreshToken));
    }

    public void SaveUser(UserModel user)
    {
        Remove(UserKey);

        var json = JsonSerializer.Serialize(user);

        _vault.Add(new PasswordCredential(
            ResourceName,
            UserKey,
            json));
    }

    public void Clear()
    {
        Remove(AccessTokenKey);
        Remove(RefreshTokenKey);
        Remove(UserKey);
    }

    private string? GetString(string key)
    {
        try
        {
            return _vault.Retrieve(ResourceName, key)?.Password;
        }
        catch (Exception)
        {
            return null;
        }
    }

    private UserModel? GetUser()
    {
        var json = GetString(UserKey);

        if (string.IsNullOrEmpty(json))
            return null;

        try
        {
            return JsonSerializer.Deserialize<UserModel>(json);
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private void Remove(string key)
    {
        try
        {
            var credential = _vault.Retrieve(ResourceName, key);

            if (credential is not null)
                _vault.Remove(credential);
        }
        catch (Exception)
        {
            
        }
    }
}
