#include <stdio.h>
#include <fcntl.h>
#include <sys/ioctl.h>
#include <linux/i2c.h>
#include <linux/i2c-dev.h>

//ADR1_ADDR is Arduino 1's address
//Likewise for ADDR2_ADDR, but with Arduino 2
//I2C_BUS is the bus we're using to interface with the Arduino's
//WRITE_SIZE is the size of the buffer
//  used to write to the I2C bus
//READ_SIZE is the count of the number of
//  registers we're interested in for the Arduino's
#define ARD1_ADDR 		    0x10
#define ARD2_ADDR 		    0x20
#define I2C_BUS 		    "/dev/i2c-1"
#define LOOKUP_FILE         "./lookup.txt"
#define WRITE_SIZE		    1
#define READ_SIZE		    1
#define FUNC_NAME_LENGTH    50
#define ALL_CLEAR

//Error code format: abcdef
//a is the device, from the set of {(1, COMP), (2, BeagleBoneBlack), (3, ArduinoF), (4, ArduinoR)}
//b is the sub-device, from the set of {(1, I2C), (2, Battery), (3, Motor1), (4, Motor2), (5, Motor3), (6, Motor4),(7, Laser)
// (8, Servo), (9, Linear Actuator), (A, Solenoid), (B, Sonar), (C, IMUF), (D, IMUR), (E, Depth Sensor), (F, LEDS)}
//cd is the function number from the set of {(01, main), (02, lookup), (..., Fill in later...)}
//ef is the specific error number from the set

//Prototypes
short 8bit_to_16bit(unsigned char upper, unsigned char lower);
int 16bit_to_32bit(short upper, short lower);

int main(int argc, char **argv)
{
	//The i2c_bus is a reference to the bus which contains the Arduinos
	int i2c_bus;
	char writeBuffer[WRITE_SIZE] = {0x00};
	char readBuffer[READ_SIZE]   = {0x00};

	//If the file is able to be opened
	if ((file = open(I2C_BUS, O_RDWR)) < 0) {
		//BeagleBone Black is throwing an I2C read error from main
		return 0x210101;
	}

	//Check to see if we're able to connect to the Arduino at ADR1_ADDR
	if (ioctl(i2c_bus, I2C_SLAVE, ADR1_ADDR) < 0) {
		//I2C read error
		return 0x210101;
	}

	writeBuffer[0] = 0x00;
	if (write(file, writeBuffer, WRITE_SIZE) != WRITE_SIZE) {
		//I2C write error
		return 0x210102;
	}

	if (read(file, readBuffer, BUFFER_SIZE) != BUFFER_SIZE) {
		//I2C read error
		return 0x210101;
	}

	close(file);
	//All clear, explicitly
	return 0x000000;
}

//Will return the code for the function to be called
//  Used in I2C communication
//If return >=0, function was found and returned
// Otherwise, function was not found
short lookup(char *func_name) {
    //Possibly read into global array once after first call...
    char *function;
    FILE *f;

    if ((f = fopen(LOOKUP_FILE, "r")) == NULL) {
        return 0x2
    }
	//If they are not equal, strcpy will return ~T
	//  While they are not equal, move to the next function
	while (strcpy(names[function++], func_name));

	//If function went past the bounds of the array before finding a match,
	//  set function to a clearer error flag
	if (function == func_count)
		function = -1;

	return function;
}


//I2C bus allows byte-length communication,
//  whereas BB and Arduino data types might be
//  bigger than a single byte
//8bit_to_16bit(uchar, uchar) converts from two 8 bit values to a 16 bit short
short 8bit_to_16bit(unsigned char upper, unsigned char lower)
{
	//Shift the upper-byte over by 8 bits, and add the lower byte into the 2 byte short
	return ((short)upper << 8) | (short)lower;
}

//Same as above, but for 16 -> 32 bit
int 16bit_to_32bit(short upper, short lower)
{
	//Shift the upper-byte over by 16 bits (2 bytes),
	//  and add the lower 16 bits into the 4 byte int
	return ((int)upper << 16) | (int)lower);
}
