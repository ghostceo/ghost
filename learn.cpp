#include "learn.h" 
int Learn::addition(int a,int b){
	return (a+b);
}

int Learn::subtraction(int a,int b){
	return (a-b);
}

void CRectangle::set_values (int a, int b) {
    width = a;
    height = b;
}

void Learn::test(){
	CRectangle a, *b, *c;
    CRectangle * d = new CRectangle[2];
    b= new CRectangle;
    c= &a;
    a.set_values (1,2);
    b->set_values (3,4);
    d->set_values (5,6);
    d[1].set_values (7,8);
    cout << "a area: " << a.area() << endl;
    cout << "*b area: " << b->area() << endl;
    cout << "*c area: " << c->area() << endl;
    cout << "d[0] area: " << d[0].area() << endl;
    cout << "d[1] area: " << d[1].area() << endl;
}


CVector::CVector (int a, int b) {
    x = a;
    y = b;
}

CVector CVector::operator+ (CVector param) {
    CVector temp;
    temp.x = x + param.x;
    temp.y = y + param.y;
    return (temp);
}

// double Learn::betsy(int lns) {
//     return 0.05 * lns;
// }

// double Learn::pam(int lns) {
//     return 0.03 * lns * 0.004 *lns *lns;
// }

// void Learn::estimate(int lines, double (*pf)(int)) {
//     cout << lines << "lines will take";
//     cout << (*pf)(lines) << "hour(s)\n";
// }

void Learn::test1(){
	CVector a (3,1);
    CVector b (1,2);
    CVector c;
    c = a + b;
    cout << c.x << "," << c.y;
}

void Learn::test2(){
	int i=5, j=6, k;

    long l=10, m=5, n;

    k=GetMax(i,j);

    n=GetMax(l,m);

    cout << k << endl;

    cout << n << endl;

    //注意传入类型要写
    pairs<int> myobject(100, 75);
    cout<< myobject.getmax()<<endl;
}


// void Learn::test3() {
//     int code;
//     cout << "How mang lines of code do you need?";
//     cin >> code;
//     cout << "Here`s Betsy`s estimate:";
//     estimate(code,betsy);
//     cout << "Here`s Pam`s estimate:";
//     estimate(code,pam);
// }