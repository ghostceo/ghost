#include <windows.h>
#include <winsock2.h>
#include <stdlib.h>
#include <stdio.h>
#include <iostream>
#include "pluto.h"

#pragma  comment(lib,"ws2_32.lib")
using namespace std;

class CNetMsgHead
{
public:
    int msgid;
    CNetMsgHead() : msgid(0) {}

    int	GetHeadSize(){ return sizeof(CNetMsgHead); };
};

#define BEGIN_MAKE_MSG_CLASS(HostCmd , x ) class Msg_##x : public CNetMsgHead \
{\
public:\
    Msg_##x() {\
    msgid = HostCmd;  } \
    Msg_##x& operator=( const Msg_##x& v ) {\
    memcpy(this, &v,sizeof(Msg_##x) );\
    return *this; }\
    void* GetData() {\
    return (void*)this; }
#define END_MAKE_MSG_CLASS(HostCmd, x ) };

BEGIN_MAKE_MSG_CLASS(13500, ToList)
int Num;
END_MAKE_MSG_CLASS(13500, ToList)