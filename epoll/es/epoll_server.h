#include  <stdio.h> 
#include  <stdlib.h>  
#include  <iostream>   
#include  <unistd.h>   
#include  <fcntl.h>   
#include  <errno.h>  
#include  <sys/types.h>  
#include  <sys/socket.h>   
#include  <sys/epoll.h>   
#include  <netinet/in.h>   
#include  <arpa/inet.h>  
#include  <string.h>
using namespace std;  

class epoll_server  
{  
    public:  
        epoll_server();  
        virtual ~epoll_server();  
        bool init(int port, int sock_count);  
        bool init(const char* ip, int port, int sock_count);  
        int epoll_server_wait(int time_out);  
        int accept_new_client();  
        int recv_data(int sock, char* recv_buf);  
        int send_data(int sock, char* send_buf, int buf_len);  
        void run(int time_out);  
  
    private:  
        int m_listen_sock;  
        int m_epoll_fd;  
        int m_max_count;  
        struct epoll_event *m_epoll_events;  
}; 