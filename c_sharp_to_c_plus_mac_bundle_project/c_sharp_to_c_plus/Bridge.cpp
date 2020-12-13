//
//  Bridge.cpp
//  c_sharp_to_c_plus
//
//  Created by 张涛 on 2020/12/13.
//  Copyright © 2020 张涛. All rights reserved.
//

#include "Bridge.hpp"
#include "LogHelper.h"

#ifndef __cplusplus
extern "C"
#endif
/**
 Api call sample.
 */
LogHelper& logger = LogHelper::getInstance();;

int startLogService() {
    logger.startLogService("./wrapper_log.txt");
    return 100;
}

int getSumValue(int value1, int value2) {
    return value1 + value2;
}

int setPeople(People people) {
    logger.writeLog("Call setPeople from C#: age: %d, name: %s\r\n", people.age, people.name);
    return 100;
}

int modifyPeople(People *people) {
    logger.writeLog("Call modfiyPeople from C#: age: %d, name: %s\r\n", people->age, people->name);
    people->age = 30;
    people->name = "I am C++";
    return 100;
}

int setPeoples(Peoples peoples) {
    for (int i = 0; i < peoples.count; i ++) {
        logger.writeLog("Call setPeoples from C#: age: %d, name: %s\r\n", peoples.people[i].age, peoples.people[i].name);
    }
    return 100;
}

int modifyPeoples(Peoples *peoples) {
    logger.writeLog("Call modfiyPeople from C#: count: %d\r\n", peoples->count);
    for (int i = 0; i < peoples->count; i ++) {
        peoples->people[i].age = 30;
        peoples->people[i].name = "I am people list from C++";
    }
    return 100;
}

int setPeopleList(PeopleList peopleList) {
    logger.writeLog("Call setPeopleList People1 age: %d, name: %s, People2 age: %d, name: %s\r\n", peopleList.people1.age, peopleList.people1.name, peopleList.people2.age, peopleList.people2.name);
    return 100;
}

int modifyPeopleList(PeopleList *peopleList) {
    logger.writeLog("Call modifyPeopleList from C#.\r\n");
    peopleList->people1.age = 30;
    peopleList->people1.name = "I am people1 from C++";
    
    peopleList->people2.age = 30;
    peopleList->people2.name = "I am people2 from C++";
    
    return 100;
}

void initCallback(Func_Pointer funcPointer, Func_Pointer funcPointer2) {
    callback1 = funcPointer;
    callback2 = funcPointer2;
}

void testCallback() {
    callback1(1, true, "I am callback1 from C++");
    callback2(2, false, "I am callback2 from C++");
}
#ifndef __cplusplus
}
#endif
