# RandomJelly
Makes a random number stream to file based on live jellyfish. 
This is a project i started just out of curiosity and wanting to learn stuff like: webcrawling, bitmaps, theory behind random nuber generators 
### Shout to monterey bay aquarium for having awesome livestreams of wildlife to inspire this little project!

## Disclaimers

### This project is not yet available for easy distribution or use 

### This is not an efficient way to generate random numbers, api methods are far simpler 
#### Most of my code is not efficient, bitmap.getPixel(x,y) for example can be made more efficient.
### Most code, comments etc. Is written in a mix of norwegian/english/nonsense (sorry)

### This is still technically a Pseudorandom number generator
#### Even when the seed is generated by jellyfish 

## Implementaion 
### Step 1: Run the program, if there is a image of jellyfish skip to step 
### Step 2: Selenium will open youtube link to livestream 
### Step 3: After saving screenshot, crop the screenshot to videoframe 
### Step 4: Using bitmap, go through 64 squares of the image.
### Step 5: If the square contains rgb values equal to jelyfysh colors, return a "1" to a binary string, else it returns a "0"
### Step 6: The 64bit string is then used as a seed/state in A Linear Feedback Shift Register. For a 64 bit LFSR in C# i "borrowed" from : https://github.com/xudonax/LFSR-RNG-CS Shoutout to that guy as well! 
### Step 7: Each state after bitshift is then written to a output.txt file which result in the stream for random numbers. 

