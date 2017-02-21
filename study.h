#include <deque>
#include <vector>
#include <iostream>
#include <cstdio>
#include <string>
#include <list>
#include <map>    
using namespace std;
typedef list<string> LISTSTR; 
#ifndef STUDY_H_
#define STUDY_H_ 
	class Study {
		public:
			void print();
			void queue();
			void compare();
			void vect();
			void vects();
			void lists();
			void maps();
			void maps1();
			void swap1(int a, int b);   //传值
			void swap2(int *a, int *b);   //传址
			void duplicate(int& a, int& b, int& c);
			void pluto_alltype_test();
	};
	class A  {  
	    public:  
		    int n;  
		public:  
		    A(int n)  
		    {  
		        this->n = n;  
		    }   
	};
	class Student  {  
		public:  
		    string m_strNO;  
		    string m_strName;  
		    string m_strSex;  
		    string m_strDate;
		    void Display();  
		public:  
		    Student(string strNO,string strName,string strSex,string strDate)  
		    {  
		        m_strNO = strNO;  
		        m_strName = strName;  
		        m_strSex = strSex;  
		        m_strDate = strDate;  
		    }  
		};  
  
	class StudCollect  {  
	    vector<Student> m_vStud;  
		public:  
		    void Add(Student &s); 
		    Student* Find(string strNO);  
	};   

	struct RoleTemp
		{
			int	   rid;
			int    age;
			string name;
		};

#endif
