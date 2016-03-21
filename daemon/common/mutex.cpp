#include "mutex.h"

CMutex::CMutex(pthread_mutex_t& m) : m_m(m)
{
}

CMutex::~CMutex()
{
}

void CMutex::Lock()
{
    pthread_mutex_lock(&m_m);
}

void CMutex::UnLock()
{
	if (!(m_m)) return;			// ��ֵ����ʱ�����п���Ϊ�գ����³�����ֹ�������� lock �� unlock ����� ������ͨ��
    pthread_mutex_unlock(&m_m);
}

CMutexGuard::CMutexGuard(pthread_mutex_t& m):mm(m)
{
    mm.Lock();
}

CMutexGuard::~CMutexGuard()
{
    mm.UnLock();
}
