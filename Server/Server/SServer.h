#ifndef SSERVER_H
#define SSERVER_H
#include <windows.h>
#include "SocketEnum.h"
#include "CSocket.h"
class SServer
{
public:
	//启动服务器
	bool Start(int port);
	//接收客户端请求
	CSocket* Accept(); 
	void SetSocketError(SocketEnum::SocketError error);
	~SServer();
	void Close();
	bool ShutDown(SocketEnum::ShutdownMode mode);
private: 
	SOCKET ssocket;
	char* buffer;
	struct sockaddr_in serverAddress;
	SocketEnum::SocketError socketError;
	bool isStart;
	WSADATA wsa;
};
#endif