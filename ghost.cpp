#include "ghost.h"
void test_lr() {
  srand(0);
  
  double learning_rate = 0.1;
  int n_epochs = 500;

  int train_N = 6;
  int test_N = 2;
  int n_in = 6;
  int n_out = 2;


  // training data
  int train_X[6][6] = {
    {1, 1, 1, 0, 0, 0},
    {1, 0, 1, 0, 0, 0},
    {1, 1, 1, 0, 0, 0},
    {0, 0, 1, 1, 1, 0},
    {0, 0, 1, 1, 0, 0},
    {0, 0, 1, 1, 1, 0}
  };

  int train_Y[6][2] = {
    {1, 0},
    {1, 0},
    {1, 0},
    {0, 1},
    {0, 1},
    {0, 1}
  };


  // construct LogisticRegression
  LogisticRegression classifier(train_N, n_in, n_out);


  // train online
  for(int epoch=0; epoch<n_epochs; epoch++) {
    for(int i=0; i<train_N; i++) {
      classifier.train(train_X[i], train_Y[i], learning_rate);
    }
    // learning_rate *= 0.95;
  }


  // test data
  int test_X[2][6] = {
    {1, 0, 1, 0, 0, 0},
    {0, 0, 1, 1, 1, 0}
  };

  double test_Y[2][2];


  // test
  for(int i=0; i<test_N; i++) {
    classifier.predict(test_X[i], test_Y[i]);
    for(int j=0; j<n_out; j++) {
      cout << test_Y[i][j] << " ";
    }
    cout << endl;
  }

}
int main(int argc, char* argv[])

{

	//cout << "hello world!" << endl;
    // cout << argc << endl;
    // cout << argv[0] << endl;
    // cout << argv[1] << endl;

    mgr_logic* pLogic = mgr_logic::GetInstance();
    pLogic->Init();
    cout<<pLogic->logic<<endl;

    // string mystr;
    // cout << "What's your name? ";
    // getline (cin, mystr);
    // cout << "Hello " << mystr << ".\n";
    
	struct game *rh = (struct game *)malloc(sizeof(*rh));
    cout<<sizeof(*rh)<<endl;
    //struct game *g = new game();
	//int a=4;
    //Hello h;
    //h.print();
    //cout<<g<<endl;
    //cout<<g->age<<endl;
    //cin>>a;
   	//#ifdef _HH
    //cout<<a<<endl;
	//#endif
    //Study s;
    //s.queue();
    //s.vect();
    //s.vects();
    //s.compare();
    //s.lists();
    //s.maps();
    //s.maps1();


    // int x = 5, y = 10;  
    // s.swap1(x,y);  
    // printf("x = %d, y = %d", x, y); 
    // s.swap2(&x,&y);  
    // printf("x = %d, y = %d", x, y); 

    // int x=1, y=3, z=7;
    // s.duplicate (x, y, z);
    // cout << "x=" << x << ", y=" << y << ", z=" << z;


    //Learn l;
    //l.test();
    //l.test1();
    //l.test2();
    //l.test4();

    //pluto test begin
    // Study s;
    // s.pluto_alltype_test();
    //pluto test end
    test_lr();

    putchar('\n');
	system("pause");
	return 0;


}

