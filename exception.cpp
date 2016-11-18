#include "exception.h"

CException::CException(int nCode, const string& strMsg)
        :m_nCode(nCode), m_strMsg(strMsg)
    {
    }


    CException::CException(int nCode, const char* pszMsg)
        :m_nCode(nCode), m_strMsg(pszMsg)
    {
    }


    //CException::CException(int nCode, const char* pszMsg, ...)
    //          :m_nCode(nCode)
    //{
    //  char szTmp[256];
    //  memset(szTmp, 0, sizeof(szTmp));
    //  va_list ap;
    //  va_start(ap, pszMsg);
    //  _vsnprintf(szTmp, sizeof(szTmp), pszMsg, ap);
    //  va_end(ap);
    //
    //  m_strMsg.assign(szTmp);
    //}


    CException::~CException()
    {

    }


void ThrowException(int n, const char* pszMsg, ...)
    {
        char szTmp[512];
        memset(szTmp, 0, sizeof(szTmp));
        va_list ap;
        va_start(ap, pszMsg);
        vsnprintf(szTmp, sizeof(szTmp)-1, pszMsg, ap);
        va_end(ap);

        throw CException(n, szTmp);
    }
