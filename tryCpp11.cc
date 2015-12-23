#include <iostream>
#include <memory>
  
  int main()
  {
      std::shared_ptr<int> pInt(new int(5));
      std::cout << *pInt << std::endl;
     return 0;
 }
