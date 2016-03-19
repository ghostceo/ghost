#include "Server.h"
const int BUF_LEN = 1024;

void recv(PVOID pt)
{
	CSocket* csocket = (CSocket*)pt;
	cout << "run here waita" << endl;
	if (csocket != NULL)
	{
		cout << "run here waitb" << endl;
		int count = csocket->Receive(BUF_LEN);
		if (count == 0)
		{
			cout << "run here waitc" << endl;
			ClientList* list = ClientList::GetInstance();
			list->Remove(csocket);
			cout << "one user leave,num online:" << list->Count() << endl;
			_endthread(); //用户下线，终止接收数据线程
		}
	}
}

void sends(PVOID pt)
{
	ClientList* list = (ClientList*)pt;
	while (1)
	{
		char* buf = new char[BUF_LEN];
		cin >> buf;
		int bufSize = 0;
		while (buf[bufSize++] != '\0');
		for (int i = list->Count() - 1; i >= 0; i--)
		{
			(*list)[i]->Send(buf, bufSize);
		}
		delete buf;
	}
}

DWORD WINAPI Fun1Proc(LPVOID lpParameter);

int main(int argc, char* argv[])
{
	SServer server;
	bool isStart = server.Start(2345);
	if (isStart)
	{
		cout << "server start success..." << endl;
	}
	else
	{
		cout << "server start error" << endl;
	}
	ClientList* list = ClientList::GetInstance();
	_beginthread(sends, 0, list);//启动一个线程广播数据
	while (1)
	{
		cout << "run here wait" << endl;
		CSocket* csocket = server.Accept();

		list->Add(csocket);
		cout << "new user come, num online:" << list->Count() << endl;
		_beginthread(recv, 0, csocket);//启动一个接收数据的线程
	}
	cout << "run here" << endl;
	getchar();
	return 0;
	
	// HANDLE hThread1;
	// hThread1 = CreateThread(NULL, 0, Fun1Proc, NULL, 0, NULL);
	// CloseHandle(hThread1);
	// cout << "main thread is running" << endl;
	// getchar();
	// return 0;
}

DWORD WINAPI Fun1Proc(LPVOID lpParameter){
	cout << "thread1 is running" << endl;
	return 0;
}
