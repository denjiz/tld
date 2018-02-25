import sys
from os import listdir
import os

dir = sys.argv[1]
list = listdir(dir)
for i in range(len(list)):
	oldFilename = dir + "\\" + list[i]
	newFilename = dir + "\\" + str(i+1) + ".jpg"
	os.rename(oldFilename, newFilename)