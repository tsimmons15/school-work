#include "classroom.h"

#include <iostream>
#include <algorithm>
#include <ctime>
#include <Windows.h>
#include <string.h>
#include <fstream>

using namespace std;


//Function and Class declarations below:

char menuControl();
void printMenu(Classroom Classes[], int arrSize);
void assignMenu(Classroom Classes[], int arrSize);
void alterEntity(Classroom Classes[], int arrSize);
void helpMain( );
void printHelp( );
void classHelp( );
void entityHelp( );
void newSemester( Classroom Classes[], int arrSize );
void professorDisplay( Classroom Classes[], int arrSize );
void classroomDisplay( Classroom Classes[], int arrSize );
void timeDisplay( Classroom Classes[], int arrSize );
int* displaySort( Classroom Classes[], int arrSize );
void assignClass( Classroom Classes[], int arrSize );
void changeClass( Classroom Classes[], int arrSize );
void dropClass( Classroom Classes[], int arrSize );
void innitTest ( Classroom Classes[], int arrSize );
void removeClassroom( Classroom Classes[], int arrSize );
void removeProfessor ( Classroom Classes[], int arrSize );
bool conflictCheck( Classroom Classes[], int arrSize , int bldg, int room, int start, int stop, string days, int ID );

int main()
{
    Classroom Classes[10];
    Professor Prof;
    TimeSlot time;
    char choice = '1';
    char trash = ' ';
    char cont = 'n';
    string days[9] = { "MWF", "TR", "MW", "MF", "M", "W", "F", "T", "R" };
    string semester;
    
    //Recommend class cancellation if too few students in class.
    innitTest( Classes, 10 );
    
    displaySort( Classes, 10);
    
        do
        {
            system("cls");
    
            cout << "Greetings! Welcome to the Valencia College Class/Course Conflict Compiler." << endl;
            
            choice = menuControl();
            
            switch (choice)
            {
                case '1':
                    system("cls");
                    printMenu( Classes, 10 );
                    break;
                case '2':
                    system("cls");
                    assignMenu( Classes, 10 );
                    break;
                case '3':
                    system("cls");
                    alterEntity( Classes, 10 );
                    break;
                case '4':
                    system("cls");
                    newSemester( Classes, 10 );
                    break;
                default:
                    helpMain( );
                    break;
            }
        
        cout << endl << "Do you wish to make another selection?\n";
        cout << "Enter [Y]es, or [N]o: ";
        cin >> cont;
        cont = tolower(cont);
        
    } while (cont == 'y');
    
    cout << "Thank you for using the VCC/CCC!";

    system("pause");
    return 0;
}

char menuControl()
{
    char choice =' ';
    
    cout << "1 - Print a schedule.\n";
    cout << "2 - Assign a class slot.\n";
    cout << "3 - Add/Remove a Professor/Class.\n";
    cout << "4 - Start New Semester.\n";
    cout << "5 - Help. \n";
    cin >> choice;
    choice = tolower(choice);
    
    while (choice != '1' && choice != '2' && choice != '3' && choice != '4' && choice != '5')
    {
        system("cls");
        
        cout << "Selection (" << choice << ") invalid. Please select the number corresponding to your selection from the list below.\n";
        cout << "1 - Print a schedule.\n";
        cout << "2 - Assign a class slot.\n";
        cout << "3 - Add/Remove a Professor/Class.\n";
        cout << "4 - Start New Semester.\n";
        cout << "5 - Help. \n";
        cin >> choice;
        choice = tolower(choice);
    }
    
    return choice;
}

void printMenu( Classroom Classes[], int arrSize )
{
    char choice = ' ';
    
    cout << "From here you have the option of printing either a professor, or classroom, schedule.\n";
    
    cout << "1 - Print a Professor's schedule.\n";
    cout << "2 - Print a Classroom's schedule.\n";
    cout << "3 - Print what classes occur at a time interval.\n";
    cout << "4 - Help.\n";
    
    cin >> choice;
    choice = tolower(choice);
    
    switch (choice)
    {
        case '1':
             system("cls");
             professorDisplay( Classes, 10 );
             break;
        case '2':
             system("cls");
             classroomDisplay( Classes, 10 );
             break;
        case '3':
             system("cls");
             timeDisplay( Classes, 10 );
             break;
        default :
             printHelp();
             break;
    }
}

void assignMenu( Classroom Classes[], int arrSize )
{
    char choice = ' ';
    
    cout << "This menu will allow you to re-/assign a Professor's class, as well as allow for the dropping of a course offered, to free up a room.\n";
    
    cout << "1 - Assign Class to Professor.\n";
    cout << "2 - Change Class roomnumber.\n";
    cout << "3 - Free up classroom.\n";
    cout << "4 - Help.\n";
    
    cin >> choice;
    choice = tolower(choice);
    
    while (choice != '1' && choice != '2' && choice != '3' && choice != '4')
    {
        cout << "Selection (" << choice << ") invalid. Please select the number corresponding to your selection from the list below.\n";
        
        cout << "1 - Assign Class to Professor.\n";
        cout << "2 - Change Class roomnumber.\n";
        cout << "3 - Free up classroom.\n";
        cout << "4 - Help.\n";
    
        cin >> choice;
        choice = tolower(choice);
    }
    
    switch (choice)
    {
        case '1':
             system("cls");
             assignClass( Classes, arrSize );
             break;
        case '2':
             system("cls");
             changeClass(Classes, arrSize);
             break;
        case '3':
             system("cls");
             dropClass(Classes, arrSize);
             break;
        default:
            classHelp();
            break;
    }
}

void alterEntity( Classroom Classes[], int arrSize )
{
    char choice = ' ';
    
    cout << "This menu will allow you to hire/fire a Professor, or build/demolish a Classroom.\n";
    
    cout << "1 - Remove a Professor.\n";
    cout << "2 - Remove a Classroom.\n";
    cout << "3 - Help.\n";
    
    cin >> choice;
    choice = tolower(choice);
    
    while (choice != '1' && choice != '2' && choice != '3' && choice != '4' && choice != '5')
    {
        cout << "Selection (" << choice << ") invalid. Please select the number corresponding to your selection from the list below.\n";
        
        cout << "1 - Remove a Professor.\n";
        cout << "2 - Remove a Classroom.\n";
        cout << "3 - Help.\n";
    
        cin >> choice;
        choice = tolower(choice);
    }
    
    switch (choice)
    {
        case '1':
             system("cls");
             removeProfessor(Classes, arrSize);
             break;
        case '2':
             system("cls");
             removeClassroom( Classes, arrSize );
             break;
        default:
            entityHelp();
            break;
    }
}

void helpMain()
{
    system("cls");
    
    cout << "1 - Prints out a schedule (either a professor or a classroom) showing what times a class is occupied by what professor.\n";
    cout << "Inside: 1 - Print a Professor's schedule.\n";
    cout << "        2 - Print a Classroom's schedule.\n";
    cout << "2 - Assign a professor to a classroom and time slow, or free-up/drop a course if it has too few students.\n";
    cout << "Inside: 1 - Assign Class to Professor.\n";
    cout << "        2 - Change Class roomnumber.\n";
    cout << "        3 - Free-up Classroom.\n";
    cout << "3 - Add/Remove Professor/Class.\n";
    cout << "Inside: 1 - Add a Professor.\n";
    cout << "        2 - Remove a Professor.\n";
    cout << "        3 - Add a Classroom.\n";
    cout << "        4 - Remove a Classroom.\n";
    
    cout << "\n\n";
}

void professorDisplay( Classroom Classes[], int arrSize )
{
    int profID;
    int x;
    bool profFlag = false;
    
    cout << "Enter the ID of the professor you wish to see the schedule for:";
    cin >> profID;
    
    for (x = 0; x < arrSize; x++)
    {
        if (Classes[x].getProfID() == profID)
        {
            cout << "Name: " << Classes[x].getProfName() << endl;
            cout << "Department: " << Classes[x].getProfDept() << endl;
            cout << "Classroom: " << Classes[x].getBldgNum() << "-" << Classes[x].getRoomNum() << endl;
            cout << "Time: " << Classes[x].getStart() << "-" << Classes[x].getStop() << endl;
            cout << "On: " << Classes[x].getDays() << endl << endl;
            profFlag = true;
        }
    }
    
    if (profFlag)
    {
        cout << "Note - All times are in 24-Hour Format. Ex: 1300 is 1:00 PM.\n";
    }
    else
    {
        cout << "There were no professors with that ID.\n";
    }
}

void classroomDisplay( Classroom Classes[], int arrSize )
{
    int room;
    int bldg;
    int x;
    bool classFlag = false;
    
    cout << "Enter the room (Bldg# Room#) of the professor you wish to see the schedule for:";
    cin >> bldg >> room;
    
    for (x = 0; x < arrSize; x++)
    {
        if (Classes[x].getBldgNum() == bldg && Classes[x].getRoomNum() == room)
        {
            cout << "Name: " << Classes[x].getProfName() << endl;
            cout << "Department: " << Classes[x].getProfDept() << endl;
            cout << "Classroom: " << Classes[x].getBldgNum() << "-" << Classes[x].getRoomNum() << endl;
            cout << "Time: " << Classes[x].getStart() << "-" << Classes[x].getStop() << endl;
            cout << "On: " << Classes[x].getDays() << endl << endl;
            classFlag = true;
        }
    }
    
    if (classFlag)
    {
        cout << "Note - All times are in 24-Hour Format. Ex: 1300 is 1:00 PM.\n";
    }
    else
    {
        cout << "There are no classrooms with that number.\n";
    }
    
}
void timeDisplay( Classroom Classes[], int arrSize )
{
    int start;
    int stop;
    int x;
    string days;
    bool timeFlag = false;
    
    cout << "Enter the hours (in 24-Hour format) you wish to look for (Start Stop):";
    cin >> start >> stop;
    
    cout << endl;
    
    cout << "What combination of days( no spaces ):";
    cin >> days;
    
    
    for (x = 0; x < arrSize; x++)
    {
        if (Classes[x].getStart() >= start && Classes[x].getStop() <= stop && Classes[x].getDays().compare(days) == 0)
        {
            cout << "Name: " << Classes[x].getProfName() << endl;
            cout << "Department: " << Classes[x].getProfDept() << endl;
            cout << "Classroom: " << Classes[x].getBldgNum() << "-" << Classes[x].getRoomNum() << endl;
            cout << "Time: " << Classes[x].getStart() << "-" << Classes[x].getStop() << endl;
            cout << "On: " << Classes[x].getDays() << endl << endl;
            timeFlag = true;
        }
    }
    
    if (timeFlag)
    {
        cout << "Note - All times are in 24-Hour Format. Ex: 1300 is 1:00 PM.\n";
    }
    else
    {
        cout << "There are no classrooms with that number.\n";
    }
    
}

int* displaySort( Classroom Classes[], int arrSize )
{
    int x;
    int y;
    Classroom temp;
    
    
    for (x = arrSize - 1; x > 0; x--)
    {
        for (y = 0; y <= x - 1; y++)
        {
            if (Classes[y].getStart() > Classes[y+1].getStart())
            {
                temp.setProfID(Classes[y+1].getProfID());
                temp.setProfName(Classes[y+1].getProfName());
                temp.setProfDepartment(Classes[y+1].getProfDept());
                temp.setStart(Classes[y+1].getStart());
                temp.setStop(Classes[y+1].getStop());
                temp.setDays(Classes[y+1].getDays());
                temp.setBldgNum(Classes[y+1].getBldgNum());
                temp.setRoomNum(Classes[y+1].getRoomNum());
                temp.setCapacity(Classes[y+1].getCapacity());
                temp.setCurrEnrolled(Classes[y+1].getCurrEnrolled());
                Classes[y+1].setProfID( Classes[y].getProfID() );
                Classes[y+1].setProfName ( Classes[y].getProfName() );
                Classes[y+1].setProfDepartment ( Classes[y].getProfDept() );
                Classes[y+1].setStart ( Classes[y].getStart() );
                Classes[y+1].setStop ( Classes[y].getStop() );
                Classes[y+1].setDays ( Classes[y].getDays() );
                Classes[y+1].setBldgNum ( Classes[y].getBldgNum() );
                Classes[y+1].setRoomNum ( Classes[y].getRoomNum() );
                Classes[y+1].setCapacity ( Classes[y].getCapacity() );
                Classes[y+1].setCurrEnrolled ( Classes[y].getCurrEnrolled() );
                Classes[y].setProfID( temp.getProfID() );
                Classes[y].setProfName ( temp.getProfName() );
                Classes[y].setProfDepartment ( temp.getProfDept() );
                Classes[y].setStart ( temp.getStart() );
                Classes[y].setStop ( temp.getStop() );
                Classes[y].setDays ( temp.getDays() );
                Classes[y].setBldgNum ( temp.getBldgNum() );
                Classes[y].setRoomNum ( temp.getRoomNum() );
                Classes[y].setCapacity ( temp.getCapacity() );
                Classes[y].setCurrEnrolled ( temp.getCurrEnrolled() );
            }
        }
    }
}

void debugDisplay( Classroom Classes[], int arrSize)
{
    int x;
    
    for (x = 0; x < arrSize; x++ )
    {
        cout << "Name: " << Classes[x].getProfName() << endl;
        cout << "Department: " << Classes[x].getProfDept() << endl;
        cout << "Classroom: " << Classes[x].getBldgNum() << "-" << Classes[x].getRoomNum() << endl;
        cout << "Time: " << Classes[x].getStart() << "-" << Classes[x].getStop() << endl;
        cout << "On: " << Classes[x].getDays() << endl << endl;
    }
}

void printHelp()
{
    system("cls");
    
    cout << "1 - Print out a Professor's schedule, showing what classroom the Professor need be in at a given moment in time.\n";
    cout << "2 - Print out a Classroom's schedule, showing what Professor will be in the class at what time.\n";
    cout << "3 - Print out a schedule of classes which are going on at a given time interval.\n";
    
    cout << "\n\n";
}

 void assignClass( Classroom Classes[], int arrSize )
{
    int bldg, room, capacity;
    int start, stop;
    int ID;
    int x;
    int pos = -1;
    string days;
    string name;
    string department;
    bool conflictFlag = false;
    
    for (x = 0; x < arrSize; x++ )
    {
        if (Classes[x].getBldgNum() == 0 && pos == -1)
        {
            pos = x;
            cout << "x is now set to: " << x << endl;
        }
    }
    
    cout << "What will be the new classes building and room number? (Bldg Room) ";
    cin >> bldg >> room;
    
    cout << "What is the classes capacity: ";
    cin >> capacity;
    
    cout << "What time will the class meet? (24-Hour format, Start Stop) ";
    cin >> start >> stop;
    
    cout << "What days will the class meet? (MWF, TR, MW, MF, M, T, W, R, F) ";
    cin.ignore(1000, '\n');
    cin >> days;
    
    cout << "What is the name of the Professor?";
    cin.ignore(1000, '\n');
    getline(cin, name);
    
    cout << "What is the Professor's ID: ";
    cin >> ID;
    
    cout << "What is the Professor's Department: ";
    cin.ignore(1000, '\n');
    getline(cin, department);
    
    //debugDisplay( Classes, arrSize );
    
    conflictFlag = conflictCheck( Classes, arrSize, bldg, room, start, stop, days, ID );
    
    if (!conflictFlag)
    {
        Classes[x].setBldgNum( bldg );
        Classes[x].setRoomNum( room );
        Classes[x].setCapacity( capacity );
        Classes[x].setStart( start );
        Classes[x].setStop( stop );
        Classes[x].setDays( days );
        Classes[x].setProfName( name );
        Classes[x].setProfID( ID );
        Classes[x].setProfDepartment( department );
    }
    
    displaySort( Classes, arrSize );
}

void changeClass( Classroom Classes[], int arrSize )
{
    int bldg, room, capacity;
    int start, stop;
    int ID;
    int x;
    string days;
    string name;
    string dept;
    char choice;
    bool conflictFlag = false;
    
    debugDisplay(Classes, arrSize );
    
    cout << "Which is the classroom number of the class you wish to change (Bldg Room): ";
    cin >> bldg >> room;
    
    cout << "What time frame does the class occur on (Start Stop, in 24-Hour format): ";
    cin >> start >> stop;
    
    cout << "On what days? (MWF, MW, MF, TR, M, T, W, R, F):";
    cin >> days;
    
    for (x = 0; x < arrSize; x++ )
    {
        if (Classes[x].getBldgNum() == bldg && Classes[x].getRoomNum() == room && Classes[x].getStart() == start && Classes[x].getStop() == stop && Classes[x].getDays().compare(days) == 0)
        {
            cout << "What do you wish to change?\n";
            cout << "1 - Professor\n";
            cout << "2 - Classroom\n";
            cout << "3 - Time\n";
            cout << "4 - Quit\n";
            cin >> choice;
            
            switch(choice)
            {
                case '1':
                    cout << "What is the new Professor's name: ";
                    cin.ignore(1000, '\n');
                    getline(cin, name);
                    cout << endl;
                    
                    cout << "What is the new Professor's ID: ";
                    cin >> ID;
                    cout << endl;
                    
                    cout << "What is the new Professor's department: ";
                    cin.ignore(1000, '\n');
                    getline(cin, dept);
                    cout << endl;
                    
                    conflictFlag = conflictCheck( Classes, arrSize, Classes[x].getBldgNum(), Classes[x].getRoomNum(), Classes[x].getStart(), Classes[x].getStop(), Classes[x].getDays(), ID );
                    
                    if (!conflictFlag)
                    {
                        Classes[x].setProfName( name );
                        Classes[x].setProfID( ID );
                        Classes[x].setProfDepartment( dept );
                    }
                    
                    break;
                case '2':
                    cout << "What is the new classroom number (Bldg Room): ";
                    cin >> bldg >> room;
                    cout << endl;
                    
                    cout << "What is the new classroom capacity: ";
                    cin >> capacity;
                    cout << endl;
                    
                    conflictFlag = conflictCheck( Classes, arrSize, bldg, room, Classes[x].getStart(), Classes[x].getStop(), Classes[x].getDays(), Classes[x].getProfID() );
                    
                    if (!conflictFlag)
                    {
                        Classes[x].setBldgNum( bldg );
                        Classes[x].setRoomNum( room );
                        Classes[x].setCapacity( capacity );
                    }
                    
                    break;
                case '3':
                    cout << "What is the new time (Start Stop, in 24-Hour format): ";
                    cin >> start >> stop;
                    Classes[x].setStart( start );
                    cout << endl;
                    
                    cout << "What days will this be (MWF, TR, MW, MF, M, T, W, R, F): ";
                    cin.ignore(1000, '\n');
                    cin >> days;
                    cout << endl;
                    
                    conflictFlag = conflictCheck( Classes, arrSize, Classes[x].getBldgNum(), Classes[x].getRoomNum(), start, stop, days, Classes[x].getProfID() );
                    
                    if (!conflictFlag)
                    {
                        Classes[x].setStart( start );
                        Classes[x].setStop( stop );
                        Classes[x].setDays( days );
                    }
                    
                    break;
                default:
                    system("cls");
                    break;
            }
        }
    }
}
void dropClass( Classroom Classes[], int arrSize )
{
    int bldg, room;
    int start, stop;
    int x;
    string days;
    
    cout << "Which is the classroom number of the class you wish to change (Bldg Room): ";
    cin >> bldg >> room;
    
    cout << "What time frame does the class occur on (Start Stop, in 24-Hour format): ";
    cin >> start >> stop;
    
    cout << "On what days? (MWF, MW, MF, TR, M, T, W, R, F):";
    cin >> days;
    
    for (x = 0; x < arrSize; x++ )
    {
        if (Classes[x].getBldgNum() == bldg && Classes[x].getRoomNum() == room && Classes[x].getStart() == start && Classes[x].getStop() == stop && Classes[x].getDays().compare(days) == 0)
        {
            Classes[x].setProfID ( 0 );
            Classes[x].setProfName ( "Blank" );
            Classes[x].setProfDepartment ( "None" );
            Classes[x].setStart ( 0 );
            Classes[x].setStop ( 0 );
            Classes[x].setDays ("None");
            Classes[x].setBldgNum ( 0 );
            Classes[x].setRoomNum ( 0 );
            Classes[x].setCapacity ( 20 );
            Classes[x].setCurrEnrolled ( 0 );
        }
    }
}

void classHelp()
{
    system("cls");
    
    cout << "1 - Assign a Class to the Professor's schedule.\n";
    cout << "2 - Change the room a class is located in, if there is a better classroom for the Professor's class.\n";
    cout << "3 - Drop/cancel a class if there are too few students registered for a class.\n";
    
    cout << "\n\n";
}

void removeProfessor( Classroom Classes[], int arrSize )
{
    int profID;
    int x;
    
    cout << "What is the ID of the professor you wish to remove: ";
    cin >> profID;
    
    for ( x = 0; x < arrSize ; x++ )
    {
        if (Classes[x].getProfID() == profID )
        {
            Classes[x].setProfID ( 0 );
            Classes[x].setProfName ( "Blank" );
            Classes[x].setProfDepartment ( "None" );
            Classes[x].setStart ( 0 );
            Classes[x].setStop ( 0 );
            Classes[x].setDays ("None");
            Classes[x].setBldgNum ( 0 );
            Classes[x].setRoomNum ( 0 );
            Classes[x].setCapacity ( 20 );
            Classes[x].setCurrEnrolled ( 0 );
        }
    }
}

void removeClassroom( Classroom Classes[], int arrSize )
{
    int bldg, room;
    int x;
    
    cout << "Which is the classroom number of the class you wish to change (Bldg Room): ";
    cin >> bldg >> room;
    
    
    for (x = 0; x < arrSize; x++ )
    {
        if (Classes[x].getBldgNum() == bldg && Classes[x].getRoomNum() == room )
        {
            Classes[x].setProfID ( 0 );
            Classes[x].setProfName ( "Blank" );
            Classes[x].setProfDepartment ( "None" );
            Classes[x].setStart ( 0 );
            Classes[x].setStop ( 0 );
            Classes[x].setDays ("None");
            Classes[x].setBldgNum ( 0 );
            Classes[x].setRoomNum ( 0 );
            Classes[x].setCapacity ( 20 );
            Classes[x].setCurrEnrolled ( 0 );
        }
    }
}

void entityHelp( )
{
    system("cls");
    
    cout << "1 - Add a Professor to the teaching rotation.\n";
    cout << "2 - Remove a Professor from the teaching rotation.\n";
    cout << "3 - Add a Classroom to the class rotation.\n";
    cout << "4 - Remove a Classroom from the class rotation.\n";
    
    cout << "\n\n";
}

void newSemester( Classroom Classes[], int arrSize )
{
    int x;
    
    for (x = 0; x < arrSize; x++ )
    {
        Classes[x].setProfID ( 0 );
        Classes[x].setProfName ( "Blank" );
        Classes[x].setProfDepartment ( "None" );
        Classes[x].setStart ( 0 );
        Classes[x].setStop ( 0 );
        Classes[x].setDays ("None");
        Classes[x].setBldgNum ( 0 );
        Classes[x].setRoomNum ( 0 );
        Classes[x].setCapacity ( 20 );
        Classes[x].setCurrEnrolled ( 0 );
    }
}


bool conflictCheck( Classroom Classes[], int arrSize , int bldg, int room, int start, int stop, string days, int ID )
{
    int x;
    bool conflictFlag = false;
    
    for (x = 0; x < arrSize; x++)
    {
        if (Classes[x].getBldgNum() == bldg && Classes[x].getRoomNum() == room && Classes[x].getStart() == start && Classes[x].getStop() == stop && Classes[x].getProfID() == ID )
        {
            cout << "Class already exists.\n";
            cout << "Possibly choose another room.\n";
            conflictFlag = true;
            
        }
        else if ( Classes[x].getBldgNum() == bldg && Classes[x].getRoomNum() == room && Classes[x].getStart() == start && Classes[x].getStop() == stop && Classes[x].getProfID() != ID )
        {
            cout << "The Professor selected is in a class at this time.\n";
            cout << "Change the time presented, or select a different professor.\n";
            conflictFlag = true;
        }
        
    }
    
    return conflictFlag;
}

















void innitTest ( Classroom Classes[], int arrSize )
{
    Classes[2].setProfID ( 1234 );
    Classes[2].setProfName ( "Joseph Smith" );
    Classes[2].setProfDepartment ( "History" );
    Classes[2].setStart ( 1330 );
    Classes[2].setStop ( 1530 );
    Classes[2].setDays ("MWF");
    Classes[2].setBldgNum ( 8 );
    Classes[2].setRoomNum ( 114 );
    Classes[2].setCapacity ( 20 );
    Classes[2].setCurrEnrolled ( 5 );
    Classes[7].setProfID ( 1234 );
    Classes[7].setProfName ( "Joseph Smith" );
    Classes[7].setProfDepartment ( "History" );
    Classes[7].setStart ( 1700 );
    Classes[7].setStop ( 1800 );
    Classes[7].setDays ("MWF");\
    Classes[7].setBldgNum ( 8 );
    Classes[7].setRoomNum ( 114 );
    Classes[7].setCapacity ( 20 );
    Classes[7].setCurrEnrolled ( 5 );
    Classes[9].setProfID ( 1234 );
    Classes[9].setProfName ( "Joseph Smith" );
    Classes[9].setProfDepartment ( "History" );
    Classes[9].setStart ( 1130 );
    Classes[9].setStop ( 1300 );
    Classes[9].setDays ("MWF");
    Classes[9].setBldgNum ( 8 );
    Classes[9].setRoomNum ( 114 );
    Classes[9].setCapacity ( 20 );
    Classes[9].setCurrEnrolled ( 5 );
    Classes[9].setProfID ( 1234 );
}

void save()
{
    int profID;
    string profName;
    string profDept;
    int timeStart;
    int timeStop;
    string timeDays;
    int bldgNum;
    int roomNum;
    int capacity;
    int currEnrolled;
    string test;
    int stor;
    
    ifstream semesterRead ("semester.txt");
    if (semesterRead.is_open())
    {
        cout << "semester.txt detected. Reading\n";
        /*while (  )
        {
            
        
        }*/
        
        
    }
    else
    {
        cout << "semester.txt wasn't found.\n";
    }
}
