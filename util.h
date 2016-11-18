#ifndef __UTIL__HEAD__
#define __UTIL__HEAD__

#ifdef _WIN32
	#pragma warning (disable:4786)
	#pragma warning (disable:4503)
	#pragma warning (disable:4819)	
	#pragma warning (disable:4996)
#endif

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>
#include <ctype.h>
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <map>
#include <algorithm>
#include <list>
#include "exception.h"

#ifdef _WIN32
	#define snprintf _snprintf
	#define vsnprintf _vsnprintf
	#define strcasecmp(a,b) strcmp(a,b)
#else
	#include <stdint.h>
	#include <fcntl.h>
	#include <unistd.h>
	#include <dirent.h>
	#include <sys/time.h>
#endif

using std::cout;
using std::endl;
using std::string;
using std::vector;
using std::map;
using std::ios;
using std::list;

//#ifdef _WIN32
//  using std::unordered_map;
//  using std::unordered_multimap;
//#endif
//#ifdef _AIX_XLC
//  //��makefile���涨�������
//  //#define __IBMCPP_TR1__
//  using std::tr1::unordered_map;
//  using std::tr1::unordered_multimap;
//#endif

    extern string& Ltrim(string& s);
    extern string& Rtrim(string& s);

    inline string& Trim(string& s)
    {
        return Rtrim(Ltrim(s));
    }

    //ɾ���ַ�����ߵĿո�
    extern char* Ltrim(char* p);

    //ɾ���ַ����ұߵĿո�
    extern char* Rtrim(char* p);

    //ɾ���ַ������ߵĿո�
    inline char* Trim(char* s)
    {
        return Rtrim(Ltrim(s));
    }

    //�Ƚ�һ���ַ����Ĵ�д�Ƿ�ƥ��һ����д���ַ���
    extern bool UpperStrCmp(const char* src, const char* desc);

    //���շָ���nDelim����ַ���
    extern list<string> SplitString(const string& s1, int nDelim);
    extern void SplitString(const string& s1, int nDelim, list<string>& ls);
    extern void SplitStringToVector(const string& s1, int nDelim, vector<string>& ls);
    extern void SplitStringToMap(const string& s1, int nDelim1, char nDelim2, map<string, string>& dict);

    //�滻string�е�һ�γ��ֵ�ĳ������
    extern string& xReplace(string& s1, const char* pszSrc, const char* pszRep);

    //�ж�һ���ַ����Ƿ�ȫ���������ַ����
    extern bool IsDigitStr(const char* pszStr);

    //�����ļ�strFileName�Ƿ����
    extern bool IsFileExist(const char* pszFileName);
    extern bool IsFileExist(const string& strFileName);

    //���һ��Ŀ¼�Ƿ���ڣ�����������򴴽�
    extern void CheckDir(const char* pszDirName, bool bLog = false);

    //�ж�һ�������ļ���ȡ��·��������Ƿ��·���ָ��������û�������
    extern string FormatPathName(const string& strPath);

#define FORMATPATHNAME(x) { x = formatPathName(x);}


    //��������һ��ָ������
    template <typename TP,
             template <typename ELEM,
             typename ALLOC = std::allocator<ELEM>
             > class TC
             >
    void ClearContainer(TC<TP, std::allocator<TP> >& c1)
    {
        while(!c1.empty())
        {
            typename TC<TP>::iterator iter = c1.begin();
            delete *iter;
            *iter = NULL;
            c1.erase(iter);
        }
    }

    //��������һ��map,�ڶ�������Ϊָ��
    template<typename T1, typename T2,
             template <class _Kty,
             class _Ty,
             class _Pr = std::less<_Kty>,
             class _Alloc = std::allocator<std::pair<const _Kty, _Ty> >
             > class M
             >
    void ClearMap(M<T1, T2, std::less<T1>, std::allocator<std::pair<const T1, T2> > >& c1)
    {
        typename M<T1, T2>::iterator iter = c1.begin();
        for(; iter!=c1.end(); ++iter)
        {
            delete iter->second;
            iter->second = NULL;
        }
        c1.clear();
    }

    //template<typename T1, typename T2>
    //void clearMap(unordered_multimap<T1, T2>& c1)
    //{
    //  typename unordered_multimap<T1, T2>::iterator iter = c1.begin();
    //  for(; iter!=c1.end(); ++iter)
    //  {
    //      delete iter->second;
    //      iter->second = NULL;
    //  }
    //  c1.clear();
    //}


    extern const char g_cPathSplit[2];  //·���ָ���

    //����ָ�����ٶȡ�ʱ��Ρ��ƶ����룬У������ƶ��Ƿ�����
#ifndef _WIN32
    bool CheckSpeed(uint16_t speed, uint32_t timeDiff, float dis);
#endif

    extern void GetCurTime(string& strCurTime);
    extern string GetNextTime(const string& strLastTime);
    extern void GetYesterday(string& strYesterday);
    extern bool DayDiff(const string& strDayTime, int nClock);
    extern void GetDateTime(char* pszDT, size_t nLen);
#ifndef _WIN32
    extern uint32_t _GetTickCount();
    extern uint64_t _GetTickCount64();
#else	
	inline long _GetTickCount64()
	{
		return 0;
	}
#endif

    //linux����gettimeofday������ʱ��
    class CGetTimeOfDay
    {
        public:
            CGetTimeOfDay();
            ~CGetTimeOfDay();

        private:
            void GetTime(struct timeval* tv);

        public:
            //��ȡ��ǰʱ����ϴε�����ʱ��
            int GetLapsedTime();
            void SetNowTime();

        private:
            struct timeval* m_v;

    };

#ifdef _WIN32
    class MyLock
    {
        //CRITICAL_SECTION m_Lock ;
    public :
        MyLock( ){ /*InitializeCriticalSection(&m_Lock);*/ } ;
        ~MyLock( ){ /*DeleteCriticalSection(&m_Lock);*/ } ;
        void Lock( ){ /*EnterCriticalSection(&m_Lock);*/ } ;
        void Unlock( ){ /*LeaveCriticalSection(&m_Lock);*/ } ;
    };
#else
    class MyLock
    {
        pthread_mutex_t m_Mutex; 
    public :
        MyLock( ){ pthread_mutex_init( &m_Mutex , NULL );} ;
        ~MyLock( ){ pthread_mutex_destroy( &m_Mutex) ; } ;
        void Lock( ){ pthread_mutex_lock(&m_Mutex); } ;
        void Unlock( ){ pthread_mutex_unlock(&m_Mutex); } ;
    };
#endif

#endif
