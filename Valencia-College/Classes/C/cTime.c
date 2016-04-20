#include <stdio.h>
#include <stdlib.h>

int main()
{
    int now = 0, seconds = 0, minutes = 0, hours = 0, days = 0, weeks = 0, months = 0, years = 0;
    int i = 0;
    now = time(NULL);
    seconds = now;
    minutes = 60;
    hours = 60 * minutes;
    days = 24 * hours;
    weeks = 7 * days;
    months = 30.42 * days;
    years = 12 * months;
    
    int yearsPassed = 0, monthsPassed = 0, weeksPassed = 0, daysPassed = 0, hoursPassed = 0, minutesPassed = 0;
    do
    {
        now = time(NULL);
        seconds = now;
        
        yearsPassed = now / years;
        //printf("The number of years... %i\n", yearsPassed);
        now -= years * yearsPassed;
        monthsPassed = (now / months);
        //printf("The number of months... %i\n", monthsPassed);
        now -= months * monthsPassed;
        weeksPassed = (now / weeks);
        //printf("The number of weeks... %i\n", weeksPassed);
        now -= (weeksPassed - 1) * weeks;
        daysPassed = (now/days);
        //printf("The number of days... %i\n", daysPassed);
        now -= days * daysPassed;
        hoursPassed = (seconds/hours) % 24 - 4;
        //printf("The number of hours...%i\n", hoursPassed);
        now -= hours * hoursPassed;
        minutesPassed = (seconds/minutes) % 60;
        //printf("The number of minutes... %i\n", minutesPassed);
        now -= minutes * minutesPassed;
        //printf("The number of seconds... %i\n", seconds % 60);
        
        
        printf("The time: %02i:%02i:%02i", hoursPassed, minutesPassed, seconds % 60);
        printf(" %02i/%02i/%4i\n", daysPassed, monthsPassed + 1, yearsPassed + 1970);
        while (i++ < 25555555);
        system("cls");
        i = 0;
    } while (1);
    system("pause");
    return 0;
}
