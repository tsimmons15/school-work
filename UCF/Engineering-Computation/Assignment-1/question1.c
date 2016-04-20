#include <msp430.h> 
#include  <msp430g2553.h>    // header for MSP430 G2553 chip
unsigned int i = 0;  // counter as a global variable
unsigned short timer = 1;

void part_a(void) {
	P1OUT &= 0xBE;  // initialize LED1 and LED2 to off
	for (;;) { //empty for loop is an infinite loop
		P1OUT ^= 0x41;  // invert the state of LED1 and LED2
		for(i=0; i< 20000; i++);  // create a delay between toggles
	}
}

void part_b(void) {
	P1OUT &= 0xBF;  // initialize LED1 to off and LED2 to on
	for (;;) { //empty for loop is an infinite loop
		P1OUT ^= 0x41;  // invert the state of LED1 and LED2
		for(i=0; i< 20000; i++);  // create a delay between toggles
	}
}

void part_c(void) {
	P1OUT &= 0xFF;  // initialize LED1 and LED2 to off
	for (;;) { //empty for loop is an infinite loop
		//Binary count to ensure that LED1 blinks twice as fast as LED1
		//00 -> 01 -> 10 -> 11 -> 00
		//If x1, toggle both
		//Else toggle LED1
		if (P1OUT & 0x01)
			P1OUT ^= 0x01;
		else
			P1OUT ^= 0x41;

		// create a delay between toggles
		for(i=0; i< 20000; i++);
	}
}

/*
 * main.c
 */
int main(void) {
    WDTCTL = WDTPW | WDTHOLD;	// Stop watchdog timer
    P1DIR |= 0x41;  //01000001 Sets 0 and 6 to output
    part_c();
	return 0;
}
