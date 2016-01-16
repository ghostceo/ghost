#include <deque>  
#include <vector> 
#include <iostream>
#include <cstdio>
#include <string>
#include <list>
#include <map> 
using namespace std;
#ifndef LEARN_H_
#define LEARN_H_

	template <class T> T GetMax (T a, T b) {

	    T result;

	    result = (a>b)? a : b;

	    return (result);

	};

	template <class T> class pairs {
	    T value1, value2;
		public:
		    pairs (T first, T second) {

		        value1=first;

		        value2=second;

		    }

		    T getmax ();

	};

	//注意1T定义2T返回类型3T传入类型
	template <class T> T pairs<T>::getmax (){

		    T retval;

		    retval = value1>value2? value1 : value2;

		    return retval;

	};

	class Learn {
		public:
			int addition (int a, int b);
			int subtraction (int a, int b);
			void test();
			void test1();
			void test2();
			// double betsy(int);
			// double pam(int);
			// void estimate(int lines, double (*pf)(int));
			// void test3();
			void swapr(int& a, int& b);
			void swapp(int* p, int* q);
			void swapv(int  a, int  b);
			void test4();
	};

	class CRectangle {
    	int width, height;
  		public:
    		void set_values (int, int);
    		int area (void) {return (width * height);}
	};

	class CVector {
      	public:
        	int x,y;
        	CVector () {};
        	CVector (int,int);
        	CVector operator + (CVector);
    };

#endif
