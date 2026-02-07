using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using Minecraft_Server_Maker.Services.Interfaces;

namespace Minecraft_Server_Maker.Services;

public class NetworkService : INetworkService
{
	private readonly HttpClient _httpClient = new();

	public async Task<string> GetPublicIpAsync()
	{
		try
		{
			return await _httpClient.GetStringAsync("https://api.ipify.org");
		}
		catch
		{
			return "No internet connection";
		}
	}

	public string GetLocalIp()
	{
		try
		{
			using Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0);
			_socket.Connect("8.8.8.8", 65530);
			return (_socket.LocalEndPoint as IPEndPoint)?.Address.ToString() ?? "127.0.0.1";
		}
		catch
		{
			return "127.0.0.1";
		}
	}
}