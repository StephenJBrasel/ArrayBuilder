// ArrayBuilder.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "DynArray.h"
#include "Arr.h"

//This would be a really great read-aloud on National Talk Like a Pirate Day.

int main()
{
    unsigned int len = 5;
    // Testing constructor
    Arr<int>* ar = new Arr<int>(len);
    std::cout << ar << "\n";
    // Testing Bracket [] operator
    for (unsigned int i = 0; i < len; i++) {
        (*ar)[i] = i+1;
    }
    // Testing size() method.
    for (unsigned int i = 0; i < ar->size(); i++) {
        std::cout << (*ar)[i];
    }
    std::cout << "\n";

    // Testing for consts.
    Arr<int>* arConst = new Arr<int>(len);
    for (size_t i = 0; i < len; i++)
    {
        const int j = i;
        (*arConst)[i] = j;
    }
    for (unsigned int i = 0; i < arConst->size(); i++) {
        std::cout << "Const " << (*arConst)[i] << " ";
    }
    /*const int i0 = 0;
    const int i1 = 1;
    const int i2 = 2;
    const int i3 = 3;
    const int i4 = 4;
    const int i5 = 5;
    (*arConst)[0] = i0;
    (*arConst)[1] = i1;
    (*arConst)[2] = i2;
    (*arConst)[3] = i3;
    (*arConst)[4] = i4;*/
    
    /*std::cout << (*arConst)[i0];
    std::cout << (*arConst)[i1];
    std::cout << (*arConst)[i2];
    std::cout << (*arConst)[i3];
    std::cout << (*arConst)[i4];*/
    // Testing for exceptions (exceptions worked, but go ahead and try it)
    //std::cout << (*arConst)[i5];
    std::cout << "\n";


    // Testing Copy Constructor
    Arr<int>* arCopy = new Arr < int>(*ar);
    for (unsigned int i = 0; i < ar->size(); i++) {
        std::cout << (*ar)[i];
    }
    std::cout << "\n";
    for (unsigned int i = 0; i < arCopy->size(); i++) {
        std::cout << (*arCopy)[i];
    }
    std::cout << "\n";
    //Testing constructing by value
    (*arCopy)[2] = 9;
    for (unsigned int i = 0; i < ar->size(); i++) {
        std::cout << (*ar)[i];
    }
    std::cout << "\n";
    for (unsigned int i = 0; i < arCopy->size(); i++) {
        std::cout << (*arCopy)[i];
    }
    std::cout << "\n";

    //Testing assignment operator
    arCopy = ar;
    for (unsigned int i = 0; i < arCopy->size(); i++) {
        std::cout << (*arCopy)[i];
    }
    std::cout << "\n";

    //Testing clear() method
    std::cout << arConst->size() << "\n";
    arConst->clear();
    std::cout << arConst->size() << "\n";

    //Testing search() method

    for (unsigned int i = 0; i < ar->size(); i++) {
        std::cout << (*ar)[i];
    }
    std::cout << "\n";
    std::cout << ar->search(3) << "\n";
    (*ar)[1] = 3;
    for (unsigned int i = 0; i < ar->size(); i++) {
        std::cout << (*ar)[i];
    }
    std::cout << "\n";
    std::cout << ar->search(3) << "\n";
    std::cout << ar->search(30) << "\n";


    std::cout << "\nHello World!\n";

    //Testing destructor
}

