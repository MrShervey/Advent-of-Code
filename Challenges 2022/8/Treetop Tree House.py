import copy

def readfile():
    valueArray = []
    f = open("Challenges 2022/8/input.txt", "r")
    for line in f:
        lineArray = []
        for x in range(len(line)-1):  
            lineArray.append(int(line[x]))
        valueArray.append(lineArray)
    return valueArray

def setValidArray(forestArray):
    validArray = copy.deepcopy(forestArray)
    for row in range(len(forestArray)):
        for column in range(len(forestArray[0])):
            if row == 0 or row == len(forestArray)-1:
                validArray[row][column] = True
            elif column == 0 or column == len(forestArray[0])-1:
                validArray[row][column] = True
            else:
                validArray[row][column] = False
    newArray = checkTrees(validArray, forestArray)
    return newArray

def checkTrees(validArray,forestArray):
    #right
    end = len(forestArray[0])-1
    for row in range(1,len(forestArray)):
        valid = True
        count = 0
        while valid and count < end:
            if forestArray[row][count+1] < forestArray[row][count] and forestArray[row][count+1] != True:
                validArray[row][count+1] = True
            elif forestArray[row][count+1] != forestArray[row][count] and forestArray[row][count+1] != True:
                valid = False
            count += 1

    #left
    end = 0
    for row in range(1,len(forestArray)):
        valid = True
        count = len(forestArray[0])-1
        while valid and count > end:
            if forestArray[row][count-1] < forestArray[row][count] and forestArray[row][count-1] != True:
                validArray[row][count-1] = True
            elif forestArray[row][count-1] != forestArray[row][count] and forestArray[row][count-1] != True:
                valid = False
            count -= 1

    #up
    end = 0
    for column in range(1,len(forestArray)):
        valid = True
        count = len(forestArray)-1
        while valid and count > end:
            if forestArray[count-1][column] < forestArray[count][column] and forestArray[count-1][column] != True:
                validArray[count-1][column] = True
            elif forestArray[count-1][column] != forestArray[count][column] and forestArray[count-1][column] != True:
                valid = False
            count -= 1

    #down
    end = len(forestArray)-1
    for column in range(1,len(forestArray[0])):
        valid = True
        count = 0
        while valid and count < end:
            if forestArray[count+1][column] < forestArray[count][column] and forestArray[count+1][column] != True:
                validArray[count+1][column] = True
            elif forestArray[count+1][column] != forestArray[count][column] and forestArray[count+1][column] != True:
                valid = False
            count += 1
    return validArray



completedArray = (setValidArray(readfile()))
count = 0
for row in range(len(completedArray)):
    for column in range(len(completedArray[0])):
        if completedArray[row][column] == True:
            count+=1
print(count)
