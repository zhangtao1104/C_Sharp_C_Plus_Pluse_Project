//
//  Bridge.hpp
//  c_sharp_to_c_plus
//
//  Created by 张涛 on 2020/12/13.
//  Copyright © 2020 张涛. All rights reserved.
//

#ifndef Bridge_hpp
#define Bridge_hpp
#include <stdio.h>

typedef struct People {
    int age;
    const char *name;
} People;

typedef struct PeopleList {
    People people1;
    People people2;
} PeopleList;

typedef struct Peoples {
    int count;
    People *people;
} Peoples;

typedef void(*Func_Pointer)(int, bool, const char*);

Func_Pointer callback1, callback2;
/**
 Api test.
 */
extern "C" int startLogService();

extern "C" int getSumValue(int value1, int value2);

extern "C" int setPeople(People people);

extern "C" int modifyPeople(People *people);

extern "C" int setPeopleList(PeopleList peopleList);

extern "C" int modifyPeopleList(PeopleList *peopleList);

extern "C" int setPeoples(Peoples peoples);

extern "C" int modifyPeoples(Peoples *peoples);

extern "C" void initCallback(Func_Pointer funcPointer, Func_Pointer funcPointer2);

extern "C" void testCallback();
#endif /* Bridge_hpp */
