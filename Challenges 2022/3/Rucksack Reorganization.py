def checkItem(mystring):
    checkstring = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
    mid = len(mystring) // 2
    left = mystring[0:mid]
    right = mystring[mid:]
    for item in left:
        if item in right:
            position = checkstring.index(item) + 1
    return position

def readFilePart1():
    total = 0
    f = open("Challenges 2022/3/input.txt", "r")
    for line in f:
        value = checkItem(line)
        total += value
    f.close()
    return total

def readFilePart2():
    total = 0
    count = 0
    checkArray = []
    f = open("Challenges 2022/3/input.txt", "r")
    for line in f:
        if count < 3:
            data = line.split("\n")
            checkArray.append(data[0])
            if count == 2: 
                total += checkItemP2(checkArray)
                count = 0
                checkArray = []
            else:
                count += 1
    f.close()
    return total

def checkItemP2(dataArray):
    checkstring = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
    for item in dataArray[0]:
        if item in dataArray[1] and item in dataArray[2]:
            position = checkstring.index(item) + 1
    return position

print("Part 1: " + str(readFilePart1()))
print("Part 2: " + str(readFilePart2()))