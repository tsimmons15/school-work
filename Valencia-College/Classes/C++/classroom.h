#include "professor.h"
#include "timeSlot.h"

class Classroom
{
    private:
        int bldgNum;
        int roomNum;
        int capacity;
        int currEnrolled;
        Professor classProf;
        TimeSlot classTime;
        
    public:
        //Private Accessors:
        int getBldgNum( )
        {
            return bldgNum;
        }
        int getRoomNum( )
        {
            return roomNum;
        }
        int getCapacity( )
        {
            return capacity;
        }
        int getCurrEnrolled( )
        {
            return currEnrolled;
        }
        int getProfID( )
        {
            return classProf.getProfID();
        }
        string getProfName ( )
        {
            return classProf.getName();
        }
        string getProfDept ( )
        {
            return classProf.getDepartment();
        }
        int getStart( )
        {
            return classTime.getStart();
        }
        int getStop()
        {
            return classTime.getStop();
        }
        string getDays()
        {
            return classTime.getDays();
        }
        
        //Private Mutators:
        void setBldgNum( int newNum )
        {
             bldgNum = newNum;
        }
        void setRoomNum ( int newNum )
        {
            roomNum = newNum;
        }
        void setCapacity( int newNum )
        {
            capacity = newNum;
        }
        void setCurrEnrolled( int newNum )
        {
            currEnrolled = newNum;
        }
        void setProfID ( int newID )
        {
            classProf.setProfID(newID);
        }
        void setProfName ( string newName )
        {
            classProf.setName( newName );
        }
        void setProfDepartment ( string newDept )
        {
            classProf.setDepartment( newDept );
        }
        void setStart( int newStart )
        {
            classTime.setStart(newStart);
        }
        void setStop ( int newStop )
        {
            classTime.setStop( newStop );
        }
        void setDays ( string newDays )
        {
            classTime.setDays(  newDays );
        }
        
        
        //Constructors:
        Classroom ( )
        : bldgNum(0), roomNum(0), capacity(25), currEnrolled(0), classProf(Professor()), classTime(TimeSlot())
        {
        }
        
        Classroom( int setBldg, int setRoom, int setCapacity, int setEnrolled, Professor prof, TimeSlot time )
        : bldgNum(setBldg), roomNum(setRoom), capacity(setCapacity), currEnrolled(setEnrolled), classProf(prof), classTime(time)
        {
            
        }
        //Private Handlers:
        
        
};
