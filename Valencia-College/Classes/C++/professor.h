#include <string>
#include <iostream>

using namespace std;

class Professor
{
    private:
        int profID;
        string name;
        string department;
        
    public:
        //Private Accessors:
        int getProfID( )
        {
            return profID;
        }
        string getName( )
        {
            return name;
        }
        string getDepartment( )
        {
            return department;
        }
        
        //Private Mutators:
        void setProfID( int newID )
        {
            profID = newID;
        }
        void setName ( string newName )
        {
            name = newName;
        }
        void setDepartment ( string newDepartment )
        {
            department.assign ( newDepartment );
        }
        
        //Constructors:
        Professor ( )
        {
            profID = 0;
            name.assign ( "Blank" );
            department.assign( "None" );
        }
        Professor( int ID, string setName, string setDepartment)
        {
            profID = ID;
            name.assign(setName);
            department.assign(setDepartment);
        }
        
        //Private Handlers:
        
        
};
