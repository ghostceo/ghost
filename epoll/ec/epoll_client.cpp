 #include "epoll_client.h"

int main(int argc, char* argv[])
{
    int sclient = socket(AF_INET, SOCK_STREAM, 0);  
    struct sockaddr_in server_addr;  
    memset(&server_addr, 0, sizeof(&server_addr));
    sockaddr_in serAddr;
    serAddr.sin_family = AF_INET;
    serAddr.sin_port = htons(8888);
    serAddr.sin_addr.s_addr = inet_addr("192.168.253.120"); 
    if (connect(sclient, (sockaddr *)&serAddr, sizeof(serAddr)) == -1)
    {
        printf("connect error !");
        return 0;
    }
    const char * sendData = "hello TCP server I am client!\n";
    send(sclient, sendData, strlen(sendData), 0);

    char recData[255];
    int ret = recv(sclient, recData, 255, 0);
    cout << "Result:" << ret << endl;
    if(ret > 0)
    {
        recData[ret] = 0x00;
        printf(recData);
    }
    return 0;
}