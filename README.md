# Skipper2-Asset-Replacer

This is a tool to replace image data in Skipper and Skeeto 2 in order to mod the game in various ways.

## BEFORE YOU USE

This tool modifies game files, BACK YOUR GAME FILES UP BEFORE YOU USE THIS TOOL, we will implement a backup option soon but you should still take your own precautions when using the tool, only use it on files on your drive, not on the game disc itself.

Skipper and Skeeto 2 uses 256-Color BMP files, always use these files when using the tool, the program will warn you if there are issues such as too many/few colors, or file size mismatches. Often times files will vary by a number of bytes, sometimes this can be ignored without any issues but be wary.

**You may need to run the tool as administrator, or else it may not be able to write to the game files.**

## HOW TO USE

In the tool, open your mm2.dat file (likely located in "Program Files (x86)\Skipper2\"), and the window should display the first image in the game file, in most cases the observatory.
You can cycle through the images using the left and right buttons, or by inputting an index in the top right textbox and clicking the 'Goto' button.

When you have found the image that you want to replace, simply click the 'replace' button and open the image that you want to replace it with, the tool will then overwrite the bytes in mm2.dat and you should be able to launch the game.

## To Do

- [x] Game image display
- [x] Image replacing
- [x] File size check
- [x] 256-Color check
- [ ] Backup option
- [ ] Add names describing each image, rather than just numbers
- [ ] Audio replacing?

## Extras

Check out the [Speedrun Leaderboard](https://www.speedrun.com/skipper2) for the game
Join our [Discord server](https://discord.gg/jGgXAWT)
