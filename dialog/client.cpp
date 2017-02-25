#include "client.h"

int decode_test(const char* s, uint32_t n) {
    char* m_szBuff = new char[n];
    int m_unLen = 6;
    memcpy(m_szBuff, s, n);
    uint16_t nu = sz_to_uint16((unsigned char*)m_szBuff + m_unLen);
    cout<<nu<<endl;
    return 0;
}

int main(int argc, char* argv[])
{
    WORD sockVersion = MAKEWORD(2,2);
    WSADATA data; 
    if(WSAStartup(sockVersion, &data) != 0)
    {
        return 0;
    }

    SOCKET sclient = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(sclient == INVALID_SOCKET)
    {
        printf("invalid socket !");
        return 0;
    }

    sockaddr_in serAddr;
    serAddr.sin_family = AF_INET;
    serAddr.sin_port = htons(2345);
    serAddr.sin_addr.S_un.S_addr = inet_addr("192.168.5.119"); 
    if (connect(sclient, (sockaddr *)&serAddr, sizeof(serAddr)) == SOCKET_ERROR)
    {
        printf("connect error !");
        closesocket(sclient);
        return 0;
    }
    const char * sendData = "hello TCP server I am client!\n";
    send(sclient, sendData, strlen(sendData), 0);

    char recData[255];
    int ret = recv(sclient, recData, 255, 0);
    cout << "Result:" << ret << endl;
    if(ret > 0)
    {
        // recData[ret] = 0x00;
        // printf(recData);

        CPluto c2(recData, ret);
        c2.Decode();
        uint8_t u8;
        uint16_t u16;
        uint32_t u32;
        uint64_t u64;
        int8_t i8;
        int16_t i16;
        int32_t i32;
        int64_t i64;
        string s;
        //charArrayDummy cc;
        // float32_t f32;
        // float64_t f64; 

        c2 >> u8 >> u16 >> u32 >> u64 >> i8 >> i16 >> i32 >> i64>>s;//>>cc;
        cout<<u8<<endl;
        cout<<u16<<endl;
        cout<<u32<<endl;
        cout<<u64<<endl;
        cout<<i8<<endl;
        cout<<i16<<endl;
        cout<<i32<<endl;
        cout<<i64<<endl;
        cout<<s<<endl;
        //cout<<cc.m_l<<endl;
        decode_test(recData, ret);
    }
    closesocket(sclient);
    WSACleanup();
    return 0;
}

    
