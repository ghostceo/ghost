#include "ghost.h"
void test_lr() {
    srand(0);
  
    double learning_rate = 0.1;
    int n_epochs = 500;

    int train_N = 6;
    int test_N = 2;
    int n_in = 6;
    int n_out = 2;


    // training data
    int train_X[6][6] = {
        {1, 1, 1, 0, 0, 0},
        {1, 0, 1, 0, 0, 0},
        {1, 1, 1, 0, 0, 0},
        {0, 0, 1, 1, 1, 0},
        {0, 0, 1, 1, 0, 0},
        {0, 0, 1, 1, 1, 0}
    };

    int train_Y[6][2] = {
        {1, 0},
        {1, 0},
        {1, 0},
        {0, 1},
        {0, 1},
        {0, 1}
    };


    // construct LogisticRegression
    LogisticRegression classifier(train_N, n_in, n_out);


    // train online
    for(int epoch=0; epoch<n_epochs; epoch++) {
        for(int i=0; i<train_N; i++) {
            classifier.train(train_X[i], train_Y[i], learning_rate);
        }
        // learning_rate *= 0.95;
    }


    // test data
    int test_X[2][6] = {
        {1, 0, 1, 0, 0, 0},
        {0, 0, 1, 1, 1, 0}
    };

    double test_Y[2][2];


    // test
    for(int i=0; i<test_N; i++) {
        classifier.predict(test_X[i], test_Y[i]);
        for(int j=0; j<n_out; j++) {
            cout << test_Y[i][j] << " ";
        }
        cout << endl;
    }

}

DWORD WINAPI ThreadFun(LPVOID pM)  
{  
    printf("Sub Thread ID is:%d say Hello World\n", GetCurrentThreadId());  
    return 0;  
} 

//子线程函数  
unsigned int __stdcall ThreadFun1(PVOID pM)  
{  
    printf("Thread ID:%4d say:Hello World\n", GetCurrentThreadId());  
    return 0;  
} 

int main(int argc, char* argv[])

{

    //#define TEMPLATE_TEST
    #ifdef TEMPLATE_TEST
    	cout << "\a" << endl;
        int i,j=3;
        long l=2.1;
        i = GetMin <int, long> (j,l); //i=GetMin(j,l)
        cout << i << endl;
    #endif

    //#define  THREAD_TEST1
    #ifdef THREAD_TEST1
        printf("Thread demo1\n");  
        HANDLE handle = CreateThread(NULL, 0, ThreadFun, NULL, 0, NULL);  
        WaitForSingleObject(handle, INFINITE);
    #endif 

    //#define  THREAD_TEST2
    #ifdef THREAD_TEST2
        printf("Thread demo2\n");  
        const int THREAD_NUM = 5;  
        HANDLE handle[THREAD_NUM];  
        for (int i = 0; i < THREAD_NUM; i++)  
            handle[i] = (HANDLE)_beginthreadex(NULL, 0, ThreadFun1, NULL, 0, NULL);  
        WaitForMultipleObjects(THREAD_NUM, handle, TRUE, INFINITE);
    #endif 


    //#define ARGS_TEST
    #ifdef ARGS_TEST
        cout << argc << endl;
        cout << argv[0] << endl;
        cout << argv[1] << endl;
    #endif

    //#define INSTANCE_TEST
    #ifdef INSTANCE_TEST
        mgr_logic* pLogic = mgr_logic::GetInstance();
        pLogic->Init();
        cout<<pLogic->logic<<endl;
    #endif
    
	//struct game *rh = (struct game *)malloc(sizeof(*rh));
    //cout<<sizeof(*rh)<<endl;
    
    //#define DEEP_TEST
    #ifdef DEEP_TEST
        test_lr();
    #endif

    //#define STRING_TEST
    #ifdef STRING_TEST
        string mystr;
        cout << "What's your name? ";
        getline (cin, mystr);
        cout << "Hello " << mystr << ".\n";
    #endif
    
    //#define STRUCT_TEST
    #ifdef STRUCT_TEST
    	struct game *g = new game();
        struct game g1;
        g1.age=1;
        g->age=2;
    	int a=4;
        Hello h;
        h.print();
        cout<<g<<endl;
        cout<<&g1<<endl;
        cout<<g->age<<endl;
        cout<<g1.age<<endl;
        cin>>a;
        cout<<a<<endl;
    #endif

    //#define STORE_TEST
    #ifdef STORE_TEST
        Study s;
        s.queue();
        s.vect();
        s.vects();
        s.compare();
        s.lists();
        s.maps();
        s.maps1();
     #endif
    

    //#define ADRESS_TEST
    #ifdef ADRESS_TEST
        int x = 5, y = 10; 
        Study s; 
        s.swap1(x,y);  
        printf("x = %d, y = %d\n", x, y); 
        s.swap2(&x,&y);  
        printf("x = %d, y = %d\n", x, y); 

        int a=1, b=3, c=7;
        s.duplicate (a, b, c);
        cout << "a=" << a << ", b=" << b << ", c=" << c <<endl;
    #endif


    //#define ClASS_TEST
    #ifdef ClASS_TEST
        Learn l;
        l.test();
        l.test1();
        l.test2();
        l.test4();
    #endif

    //#define PROTO_TEST
    #ifdef PROTO_TEST
        //pluto test begin
        Study s;
        s.pluto_alltype_test();
        //pluto test end
    #endif

    //#define NORMAL_END
    #ifdef NORMAL_END
        putchar('\n');
	    system("pause");
	    return 0;
    #endif

    //#define SOCKET_TEST
    #ifdef SOCKET_TEST
        //初始化WSA
        WORD sockVersion = MAKEWORD(2,2);
        WSADATA wsaData;
        if(WSAStartup(sockVersion, &wsaData)!=0)
        {
            return 0;
        }
     
        //创建套接字
        SOCKET slisten = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
        if(slisten == INVALID_SOCKET)
        {
            printf("socket error !");
            return 0;
        }
     
        //绑定IP和端口
        sockaddr_in sin;
        sin.sin_family = AF_INET;
        sin.sin_port = htons(8888);
        sin.sin_addr.S_un.S_addr = INADDR_ANY; 
        if(bind(slisten, (LPSOCKADDR)&sin, sizeof(sin)) == SOCKET_ERROR)
        {
            printf("bind error !");
        }
     
        //开始监听
        if(listen(slisten, 5) == SOCKET_ERROR)
        {
            printf("listen error !");
            return 0;
        }
     
        //循环接收数据
        SOCKET sClient;
        sockaddr_in remoteAddr;
        int nAddrlen = sizeof(remoteAddr);
        char revData[255]; 
        while (true)
        {
            printf("wait link...\n");
            sClient = accept(slisten, (SOCKADDR *)&remoteAddr, &nAddrlen);
            if(sClient == INVALID_SOCKET)
            {
                printf("accept error ！");
                continue;
            }
            printf("acceot a link:%s \r\n", inet_ntoa(remoteAddr.sin_addr));
             
            //接收数据
            int ret = recv(sClient, revData, 255, 0);       
            if(ret > 0)
            {
                revData[ret] = 0x00;
                printf(revData);
            }
     
            //发送数据
            // const char * sendData = "hello TCP Client I am Server\n";
            // send(sClient, sendData, strlen(sendData), 0);
            CPluto c1;
            c1.Encode(120);
            c1 << (uint8_t) 120;
            c1 << (uint16_t) 120;
            c1 << (uint32_t) 120;
            c1 << (uint64_t) 120;
            c1 << (int8_t)  120;
            c1 << (int16_t) 120;
            c1 << (int32_t) 120;
            c1 << (int64_t) 120;
            c1 << "abcddef";
            c1 << EndPluto;
            //PrintHexPluto(c1);
            cout<<c1.GetLen()<<endl;
            send(sClient, c1.GetBuff(), c1.GetLen(), 0);
            closesocket(sClient);
        }
         
        closesocket(slisten);
        WSACleanup();
    #endif

    //#define READER_TEST
    #ifdef READER_TEST
        char* pszEtcFile = "F:\\death\\ghost\\cfg.ini";
        CCfgReader* m_cfg;
        m_cfg = new CCfgReader(pszEtcFile);
        string strLuaPath = m_cfg->GetValue("init", "lua_path");
        cout<<strLuaPath<<endl;
    #endif

    #define PARSER_TEST
    #ifdef PARSER_TEST
        const char* pszEtcFile = "F:\\death\\ghost\\cfg.ini";
        CCfgReader* m_cfg;
        m_cfg = new CCfgReader(pszEtcFile);
        CDefParser m_defParser;
        m_defParser.init(m_cfg->GetValue("init", "def_path").c_str());
        // m_defParser.ReadDbCfg(m_cfg);
        // cout<<m_defParser.GetDbCfg().m_strHost<<endl;
        return 0;
    #endif
}

