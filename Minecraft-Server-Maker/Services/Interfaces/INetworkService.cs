namespace Minecraft_Server_Maker.Services.Interfaces;

public interface INetworkService
{
	Task<string> GetPublicIpAsync();
	string GetLocalIp();
}