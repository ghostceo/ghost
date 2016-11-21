 #include "epoll_server.h"

epoll_server::epoll_server()  
{  
    m_listen_sock = 0;  
    m_epoll_fd = 0;  
    m_max_count = 0;  
    m_epoll_events = NULL;  
}  
  
epoll_server::~epoll_server()  
{  
    if (m_listen_sock > 0)  
    {  
        close(m_listen_sock);  
    }  
  
    if (m_epoll_fd > 0)  
    {  
        close(m_epoll_fd);  
    }  
}  
  
  
bool epoll_server::init(int port , int sock_count)  
{  
    m_max_count = sock_count;     
    struct sockaddr_in server_addr;  
    memset(&server_addr, 0, sizeof(&server_addr));  
    server_addr.sin_family = AF_INET;  
    server_addr.sin_port = htons(port);  
    server_addr.sin_addr.s_addr = htonl(INADDR_ANY);          
  
    m_listen_sock = socket(AF_INET, SOCK_STREAM, 0);  
    if(m_listen_sock == -1)  
    {  
        cout<<"a"<<endl;  
    }  
      
    if(bind(m_listen_sock, (struct sockaddr*)&server_addr, sizeof(server_addr)) == -1)  
    {  
        cout<<"b"<<endl;   
    }  
      
    if(listen(m_listen_sock, 5) == -1)  
    {  
        cout<<"c"<<endl;  
    }  
  
    m_epoll_events = new struct epoll_event[sock_count];  
    if (m_epoll_events == NULL)  
    {  
        cout<<"d"<<endl;   
    }  
  
    m_epoll_fd = epoll_create(sock_count);  
    struct epoll_event ev;  
    ev.data.fd = m_listen_sock;  
    ev.events  = EPOLLIN;  
    epoll_ctl(m_epoll_fd, EPOLL_CTL_ADD, m_listen_sock, &ev);  
}  
  
bool epoll_server::init(const char* ip, int port , int sock_count)  
{     
    m_max_count = sock_count;  
    struct sockaddr_in server_addr;  
    memset(&server_addr, 0, sizeof(&server_addr));  
    server_addr.sin_family = AF_INET;  
    server_addr.sin_port = htons(port);  
    server_addr.sin_addr.s_addr = inet_addr(ip);          
  
    m_listen_sock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);  
    if(m_listen_sock == -1)  
    {  
        cout<<"e"<<endl;   
    }  
      
    if(bind(m_listen_sock, (struct sockaddr*)&server_addr, sizeof(server_addr)) == -1)  
    {  
        cout<<"f"<<endl;  
    }  
      
    if(listen(m_listen_sock, 5) == -1)  
    {  
        cout<<"g"<<endl; 
    }  
  
    m_epoll_events = new struct epoll_event[sock_count];  
    if (m_epoll_events == NULL)  
    {  
        cout<<"h"<<endl; 
    }  
  
    m_epoll_fd = epoll_create(sock_count);  
    struct epoll_event ev;  
    ev.data.fd = m_listen_sock;  
    ev.events  = EPOLLIN;  
    epoll_ctl(m_epoll_fd, EPOLL_CTL_ADD, m_listen_sock, &ev);  
}  
  
int epoll_server::accept_new_client()  
{  
    sockaddr_in client_addr;  
    memset(&client_addr, 0, sizeof(client_addr));  
    socklen_t clilen = sizeof(struct sockaddr);   
    int new_sock = accept(m_listen_sock, (struct sockaddr*)&client_addr, &clilen);  
    struct epoll_event ev;  
    ev.data.fd = new_sock;  
    ev.events  = EPOLLIN;  
    epoll_ctl(m_epoll_fd, EPOLL_CTL_ADD, new_sock, &ev);  
    return new_sock;  
}  
  
int epoll_server::recv_data(int sock, char* recv_buf)  
{  
    char buf[1024] = {0};  
    int len = 0;  
    int ret = 0;  
    while(ret >= 0)  
    {  
        ret = recv(sock, buf, sizeof(buf), 0);  
        if(ret <= 0)  
        {  
            struct epoll_event ev;  
            ev.data.fd = sock;  
            ev.events  = EPOLLERR;  
            epoll_ctl(m_epoll_fd, EPOLL_CTL_DEL, sock, &ev);  
            close(sock);  
            break;  
        }  
        else if(ret < 1024)  
        {  
            memcpy(recv_buf, buf, ret);  
            len += ret;   
            struct epoll_event ev;  
            ev.data.fd = sock;  
            ev.events  = EPOLLOUT;  
            epoll_ctl(m_epoll_fd, EPOLL_CTL_MOD, sock, &ev);  
            break;  
        }  
        else  
        {  
            memcpy(recv_buf, buf, sizeof(buf));  
            len += ret;  
        }  
    }  
  
    return ret <= 0 ? ret : len;  
}  
  
int epoll_server::send_data(int sock, char* send_buf, int buf_len)  
{  
    int len = 0;  
    int ret = 0;  
    while(len < buf_len)  
    {  
        ret = send(sock, send_buf + len, 1024, 0);  
        if(ret <= 0)  
        {  
            struct epoll_event ev;  
            ev.data.fd = sock;  
            ev.events  = EPOLLERR;  
            epoll_ctl(m_epoll_fd, EPOLL_CTL_DEL, sock, &ev);  
            close(sock);  
            break;  
        }  
        else  
        {  
            len += ret;  
        }  
  
        if(ret < 1024)  
        {  
            break;  
        }  
    }  
  
    if(ret > 0)  
    {  
        struct epoll_event ev;  
        ev.data.fd = sock;  
        ev.events  = EPOLLIN;  
        epoll_ctl(m_epoll_fd, EPOLL_CTL_MOD, sock, &ev);  
    }  
  
    return ret <= 0 ? ret : len;  
}  
  
int epoll_server::epoll_server_wait(int time_out)  
{  
    int nfds = epoll_wait(m_epoll_fd, m_epoll_events, m_max_count, time_out);  
}  
  
void epoll_server::run(int time_out)  
{  
    char *recv_buf = new char[65535];  
    char *send_buf = new char[65535];  
    while(1)  
    {  
        int ret = epoll_server_wait(time_out);  
        if(ret == 0)  
        {  
            cout<<"time out"<<endl;  
            continue;  
        }  
        else if(ret == -1)  
        {  
            cout<<"error"<<endl;  
        }  
        else  
        {  
            for(int i = 0; i < ret; i++)  
            {  
                if(m_epoll_events[i].data.fd == m_listen_sock)  
                {  
                    if(m_epoll_events[i].events & EPOLLIN)  
                    {  
                        int new_sock = accept_new_client();  
                    }  
                }  
                else  
                {  
                    if(m_epoll_events[i].events & EPOLLIN)  
                    {  
                        int recv_count = recv_data(m_epoll_events[i].data.fd, recv_buf);  
                        cout<<recv_buf<<endl;  
                        strcpy(send_buf, recv_buf);  
                        memset(recv_buf, 0, sizeof(recv_buf));  
                    }  
                    else if(m_epoll_events[i].events & EPOLLOUT)  
                    {  
                        int send_count = send_data(m_epoll_events[i].data.fd, send_buf, strlen(send_buf));  
                        memset(send_buf, 0, sizeof(send_buf));  
                    }  
                      
                }  
            }  
        }  
    }  
}  
  
int main(int argc, char *argv[])  
{  
    epoll_server my_epoll;  
    my_epoll.init("192.168.253.120",8888, 10);  
    //my_epoll.init("127.0.0.1", 12345, 10);  
    my_epoll.run(2000);  
    return  0;  
}  