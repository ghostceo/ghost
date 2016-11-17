#include "ghost.h"

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

    #define PROTO_TEST
    #ifdef PROTO_TEST
        //pluto test begin
        Study s;
        s.pluto_alltype_test();
        //pluto test end
    #endif

    putchar('\n');
	system("pause");
	return 0;


}

