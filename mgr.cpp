#include "mgr.h"
	mgr_logic * mgr_logic::m_pInstance = NULL;
	mgr_logic::mgr_logic(void)
	{
	}

	mgr_logic::~mgr_logic(void)
	{
	}

	mgr_logic* mgr_logic::GetInstance()
	{
	    if ( !m_pInstance )
	        m_pInstance = new mgr_logic;
	    return m_pInstance;
	}

	int mgr_logic::Init()
	{
	    logic = 120;
    	return 0;
	}

	// bool mgr_logic::Run()
	// {
	//     if (m_pLogic) 
	//     {
	//         logic_thread_run(m_pLogic);
	//         return true;
	//     }
	//     return false;
	// }

	// void mgr_logic::Fini()
	// {
	//     if (m_pLogic) 
	//     {
	//         logic_thread_del(m_pLogic);
	//         m_pLogic = NULL;
	//     }
	// }

