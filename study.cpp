#include "study.h"  
void Study::print() {
    cout<<"Hello, welcome to Redhat Linux os!"<<endl;
}

//deque双向队列是一种双向开口的连续线性空间，可以高效的在头尾两端插入和删除元素
void Study::queue() {
    deque<int> d;
    //d.assign(2,7);
    deque<int>::iterator pos;  
    d.push_back(10);
    //cout<<d[0];   
    d.push_back(20);  
    d.push_back(30);
    for (pos = d.begin(); pos != d.end(); pos++)  
        printf("%d ", *pos);  
    putchar('\n'); 
 
    cout<<"Start Queue:"<<endl;  
    for(int i = 0; i < d.size(); i++)  
    {  
        cout<<d.at(i)<<"\t";  
    }  
    cout<<endl;  
    d.push_front(5);  
    d.push_front(3);  
    d.push_front(1);  
  
    cout<<"after push_front(5.3.1):"<<endl;  
    for(int i = 0;i < d.size();i++)  
    {  
        cout<<d.at(i)<<"\t";  
    }  
    cout<<endl;  
    d.pop_front();  
    d.pop_front();  
    cout<<"after pop_front() two times:"<<endl;  
    for(int i = 0;i < d.size();i++)  
    {  
        cout<<d.at(i)<<"\t";  
    }  
    cout<<endl;
}

void Study::compare() {
    vector<int>v(2);  
    v[0]=10;  
    int *p = &v[0];  
    cout<<"vector第一个元素迭代指针*p="<<*p<<endl;  
    v.push_back(20);  
    cout<<"vector容量变化后原vector第1个元素迭代指针*p="<<*p<<endl;  
  
    deque<int> d(2);  
    d[0]=10;  
    int *q = &d[0];  
    cout<<"deque第一个元素迭代指针*q="<<*q<<endl;  
    d.push_back(20);  
    cout<<"deque容量变化后第一个元素迭代器指针*q="<<*q<<endl;  
}

void Study::vect() {
    // 初始化示例
    // //int型vector  
    // vector<int> vecInt;  
  
    // //float型vector  
    // vector<float> vecFloat;  
  
    // //自定义类型，保存类A的vector  
    // vector<A> vecA;  
  
    // //自定义类型，保存指向类A的指针的vector  
    // vector<A*> vecPointA;




    //代码用了4种方法建立vector并对其初始化
    //int型vector,包含3个元素  
    // vector<int> vecIntA(3);  
      
    // //int型vector,包含3个元素且每个元素都是9  
    // vector<int> vecIntB(3,9);  
  
    // //复制vecIntB到vecIntC  
    // vector<int> vecIntC(vecIntB);  
      
    // int iArray[]={2,4,6};  
    // //创建vecIntD  
    // vector<int> vecIntD(iArray,iArray+3);  
  
    //打印vectorA,此处也可以用下面注释内的代码来输出vector中的数据  
    /*for(int i=0;i<vecIntA.size();i++) 
    { 
        cout<<vecIntA[i]<<"     "; 
    }*/  
  
    // cout<<"vecIntA:"<<endl;  
    // for(vector<int>::iterator it = vecIntA.begin();it!=vecIntA.end();it++)  
    // {  
    //     cout<<*it<<"     ";  
    // }  
    // cout<<endl;  
  
    // //打印vecIntB  
    // cout<<"VecIntB:"<<endl;  
    // for(vector<int>::iterator it = vecIntB.begin() ;it!=vecIntB.end();it++)  
    // {  
    //     cout<<*it<<"     ";  
    // }  
    // cout<<endl;  
  
    // //打印vecIntC  
    // cout<<"VecIntB:"<<endl;  
    // for(vector<int>::iterator it = vecIntC.begin() ;it!=vecIntC.end();it++)  
    // {  
    //     cout<<*it<<"     ";  
    // }  
    // cout<<endl;  
  
    // //打印vecIntD  
    // cout<<"vecIntD:"<<endl;  
    // for(vector<int>::iterator it = vecIntD.begin() ;it!=vecIntD.end();it++)  
    // {  
    //     cout<<*it<<"     ";  
    // }  
    // cout<<endl;



    //增加及获得元素示例
    //  //int型vector,包含3个元素  
    // vector<A> vecClassA;  
  
    // A a1(1);  
    // A a2(2);  
    // A a3(3);  
  
    // //插入1 2 3  
    // vecClassA.push_back(a1);  
    // vecClassA.push_back(a2);  
    // vecClassA.push_back(a3);  
      
      
    // int nSize = vecClassA.size();  
  
    // cout<<"vecClassA:"<<endl;  
  
    // //打印vecClassA,方法一：  
    // for(int i=0;i<nSize;i++)  
    // {  
    //     cout<<vecClassA[i].n<<"     ";  
    // }  
    // cout<<endl;  
  
    // //打印vecClassA,方法二：    
    // for(int i=0;i<nSize;i++)  
    // {  
    //     cout<<vecClassA.at(i).n<<"     ";  
    // }  
    // cout<<endl;  
  
    // //打印vecClassA,方法三：  
    // for(vector<A>::iterator it = vecClassA.begin();it!=vecClassA.end();it++)  
    // {  
    //     cout<<(*it).n<<"     ";  
    // }  
    // cout<<endl;  



    // //int型vector,包含3个元素  
    // vector<A*> vecClassA;  
  
    // A *a1 = new A(1);  
    // A *a2 = new A(2);  
    // A *a3 = new A(3);  
  
    // //插入1 2 3  
    // vecClassA.push_back(a1);  
    // vecClassA.push_back(a2);  
    // vecClassA.push_back(a3);  
      
      
    // int nSize = vecClassA.size();  
  
    // cout<<"vecClassA:"<<endl;  
  
    // //打印vecClassA,方法一：  
    // for(int i=0;i<nSize;i++)  
    // {  
    //     cout<<vecClassA[i]->n<<"\t";  
    // }  
    // cout<<endl;  
  
    // //打印vecClassA,方法二：    
    // for(int i=0;i<nSize;i++)  
    // {  
    //     cout<<vecClassA.at(i)->n<<"\t";  
    // }  
    // cout<<endl;  
  
    // //打印vecClassA,方法三：  
    // for(vector<A*>::iterator it = vecClassA.begin();it!=vecClassA.end();it++)  
    // {  
    //     cout<<(**it).n<<"\t";  
    // }  
    // cout<<endl;  
    // delete a1; delete a2;delete a3;



    // //修改元素示例
    // //int型vector,包含3个元素  
    // vector<int> vecIntA;  
  
    // //插入1 2 3  
    // vecIntA.push_back(1);  
    // vecIntA.push_back(2);  
    // vecIntA.push_back(3);  
      
    // int nSize = vecIntA.size();  
  
    // //通过引用修改vector  
    // cout<<"通过数组修改，第二个元素为8："<<endl;  
    // vecIntA[1]=8;  
  
    // cout<<"vecIntA:"<<endl;  
    // //打印vectorA  
    // for(vector<int>::iterator it = vecIntA.begin();it!=vecIntA.end();it++)  
    // {  
    //     cout<<*it<<"     ";  
    // }  
    // cout<<endl;  
      
    // //通过引用修改vector  
    // cout<<"通过引用修改，第二个元素为18："<<endl;  
    // int &m = vecIntA.at(1);  
    // m=18;  
  
    // cout<<"vecIntA:"<<endl;  
    // //打印vectorA  
    // for(vector<int>::iterator it = vecIntA.begin();it!=vecIntA.end();it++)  
    // {  
    //     cout<<*it<<"     ";  
    // }  
    // cout<<endl;  
  
    // //通过迭代器修改vector  
    // cout<<"通过迭代器修改，第二个元素为28"<<endl;  
    // vector<int>::iterator itr = vecIntA.begin()+1;  
    // *itr = 28;  
  
    // cout<<"vecIntA:"<<endl;  
    // //打印vectorA  
    // for(vector<int>::iterator it = vecIntA.begin();it!=vecIntA.end();it++)  
    // {  
    //     cout<<*it<<"     ";  
    // }  
    // cout<<endl;  



    // 删除向量示例
    //int型vector,包含3个元素  
    vector<int> vecIntA;  
  
    //循环插入1 到10  
    for(int i=1;i<=10;i++)  
    {  
        vecIntA.push_back(i);  
    }  
      
    vecIntA.erase(vecIntA.begin()+4);  
          
    cout<<"删除第5个元素后的向量vecIntA:"<<endl;  
    //打印vectorA  
    for(vector<int>::iterator it = vecIntA.begin();it!=vecIntA.end();it++)  
    {  
        cout<<*it<<"\t";  
    }  
    cout<<endl;  
  
    //删除第2-5个元素  
    vecIntA.erase(vecIntA.begin()+1,vecIntA.begin()+5);  
  
    cout<<"删除第2-5个元素后的vecIntA:"<<endl;  
    //打印vectorA  
    for(vector<int>::iterator it = vecIntA.begin();it!=vecIntA.end();it++)  
    {  
        cout<<*it<<"\t";  
    }  
    cout<<endl;  
  
    //删除最后一个元素  
    vecIntA.pop_back();  
  
    cout<<"删除最后一个元素后的vecIntA:"<<endl;  
    //打印vectorA  
    for(vector<int>::iterator it = vecIntA.begin();it!=vecIntA.end();it++)  
    {  
        cout<<*it<<"\t";  
    }  
    cout<<endl;  
}

void Study::vects() {
    Student s1("1001","zhangsan","boy","1988-10-10");     
    Student s2("1002","lisi","boy","1988-8-25");  
    Student s3("1003","wangwu","boy","1989-2-14");  
  
    StudCollect s; 
    s.Add(s1);  
    s.Add(s2);  
    s.Add(s3);  
  
    Student* ps = s.Find("1002");  
    if(ps)  
        ps->Display();
}


void Student::Display()  {  
    cout<<m_strNO<<"\t";  
    cout<<m_strName<<"\t";  
    cout<<m_strSex<<"\t";  
    cout<<m_strDate<<"\t";  
}

//注意传值 传址
void StudCollect::Add(Student &s)  {  
        //cout<<&s<<endl;//输出地址
        //cout<<s.m_strNO<<endl;
        m_vStud.push_back(s);  
}  

Student* StudCollect::Find(string strNO)  {  
    bool bFind = false;  
    int i;  
    for(i = 0;i < m_vStud.size();i++)  
    {  
        Student& s = m_vStud.at(i);  
        if(s.m_strNO == strNO)  
        {  
            bFind = true;  
            break;  
        }  
    }  
    Student* s = NULL;  
    if(bFind)  
        s = &m_vStud.at(i);  
    return s;  
} 

void Study::lists() {
    LISTSTR test;
    test.push_back("back");
    test.push_back("middle");
    test.push_back("front");


    cout<<test.front()<<endl;
    cout<<*test.begin()<<endl;


    cout<<test.back()<<endl;
    cout<<*(test.rbegin())<<endl;


    test.pop_front();
    test.pop_back();


    cout<<test.front()<<endl;
}


void Study::maps(){
    map<char,int> mymap;  
  
    mymap.insert(pair<char,int>('a',10));  
    mymap.insert(pair<char,int>('z',200));  
  
    pair<map<char,int>::iterator,bool> ret;  
    ret = mymap.insert(pair<char,int>('z',500));  
    if (ret.second == false)  
    {  
        cout<<"element 'z' already existed";  
        cout<<"with a value of "<<ret.first->second<<'\n';  
    }  
  
    map<char,int>::iterator it = mymap.begin();  
    mymap.insert(it,pair<char,int>('b',300));  
    mymap.insert(it,pair<char,int>('c',400));  
  
    map<char,int> anothermap;  
    anothermap.insert(mymap.begin(),mymap.find('c'));  
  
    cout<<"mymap contains :\n";  
    for (it = mymap.begin();it!= mymap.end();it++)  
    {  
        cout<<it->first<<"=>"<<it->second<<'\n';  
    }  
  
    cout<<"anothermap contains :\n";  
    for (it = anothermap.begin();it!= anothermap.end();it++)  
    {  
        cout<<it->first<<"=>"<<it->second<<'\n';  
    }  
}


void Study::maps1() {
    map<char,int> mymap;  
    map<char,int>::iterator it;  
      
    mymap['a'] = 10;  
    mymap['b'] = 20;  
    mymap['c'] = 30;  
    mymap['d'] = 40;  
    mymap['e'] = 50;  
    mymap.insert(pair<char,int>('f',60));  
  
    cout<<"initial mymap contains :\n";  
    for (it = mymap.begin();it!= mymap.end();it++)  
    {  
        cout<<it->first<<"=>"<<it->second<<'\n';  
    }  
  
    it = mymap.find('b');  
    mymap.erase(it);  
  
    mymap.erase('c');  
  
    it = mymap.find('e');  
    mymap.erase(it,mymap.end());  
  
    cout<<"now mymap contains :\n";  
    for (it = mymap.begin();it!= mymap.end();it++)  
    {  
        cout<<it->first<<"=>"<<it->second<<'\n';  
    }  
}


void Study::swap1(int a, int b) {
    int temp;  
    temp = a;  
    a = b;  
    b = temp;
}

void Study::swap2(int *a, int *b) {
    int temp;  
    temp = *a;  
    *a = *b;  
    *b = temp;
}

void Study::duplicate (int& a, int& b, int& c) {
    a*=2;
    b*=2;
    c*=2;
}