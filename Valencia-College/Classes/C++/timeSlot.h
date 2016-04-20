class TimeSlot
{
    private:
        int start;
        int stop;
        string days;
        
    public:
        //Private Accessors:
        int getStart( )
        {
            return start;
        }
        int getStop( )
        {
            return stop;
        }
        string getDays( )
        {
            return days;
        }
        
        //Private Mutators:
        void setStart( int setStart )
        {
            start = setStart;
        }
        
        void setStop ( int setStop )
        {
            stop = setStop;
        }
        
        void setDays ( string setDays )
        {
            days.assign (setDays);
        }
        
        //Constructors:
        TimeSlot ( )
        {
            start = 000;
            stop = 000;
            days.assign( "None" );
        }
            
        TimeSlot( int setStart, int setStop, string setDays )
        {
            start = setStart;
            stop = setStop;
            days.assign ( setDays );
            
        }
        
};
