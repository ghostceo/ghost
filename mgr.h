#include <iostream>
using namespace std;
#ifndef MGR_H_
#define MGR_H_
	struct logic_thread;
	class mgr_logic
	{
	public:
	    mgr_logic(void);
	    ~mgr_logic(void);
	    static mgr_logic* GetInstance();
	    int Init();
	    // bool Run();
	    // void Fini();
	    int logic;
	    logic_thread*     m_pLogic;
	private:
	    static mgr_logic* m_pInstance;		// --singleton instance
	};
#endif
